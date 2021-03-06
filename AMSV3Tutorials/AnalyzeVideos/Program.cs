﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Management.Media;
using Microsoft.Azure.Management.Media.Models;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Newtonsoft.Json;

namespace AnalyzeVideos
{
    class Program
    {
        private const string VideoAnalyzerTransformName = "MyVideoAnalyzerTransformName";
        private const string InputMP4FileName = @"ignite.mp4";
        private const string OutputFolder = @"Output";

        static void Main(string[] args)
        {
            ConfigWrapper config = new ConfigWrapper();

            try{
                IAzureMediaServicesClient client = CreateMediaServicesClient(config);
                
                Transform videoAnalyzerTransform = EnsureTransformExists(client, config.ResourceGroup, config.AccountName, VideoAnalyzerTransformName, new VideoAnalyzerPreset("en-US"));

                // Creating a unique suffix so that we don't have name collisions if you run the sample
                // multiple times without cleaning up.
                string uniqueness = Guid.NewGuid().ToString().Substring(0, 13);

                string jobName = "job-" + uniqueness;
                string outputAssetName = "output-" + uniqueness;
                string inputAssetName = "input-" +uniqueness;


                CreateInputAsset(client, config.ResourceGroup, config.AccountName, inputAssetName, InputMP4FileName);
                JobInput jobInput = new JobInputAsset(assetName: inputAssetName);

                Asset outputAsset = client.Assets.CreateOrUpdate(config.ResourceGroup, config.AccountName, outputAssetName, new Asset());

                Job job = SubmitJob(client, config.ResourceGroup, config.AccountName, VideoAnalyzerTransformName, jobName, jobInput, outputAssetName);

                job = WaitForJobToFinish(client, config.ResourceGroup, config.AccountName, VideoAnalyzerTransformName, jobName);

                if (job.State == JobState.Finished)
                {
                    Console.WriteLine("Job finished.");
                    if (!Directory.Exists(OutputFolder))
                        Directory.CreateDirectory(OutputFolder);

                    DownloadResults(client, config.ResourceGroup, config.AccountName, outputAssetName, OutputFolder);
                }
            }
            catch (ApiErrorException ex)
            {
                Console.WriteLine("{0}", ex.Message);

                Console.WriteLine("Code: {0}", ex.Body.Error.Code);
                Console.WriteLine("Message: {0}", ex.Body.Error.Message);
            }
                
        }

        private static IAzureMediaServicesClient CreateMediaServicesClient(ConfigWrapper config)
        {
            ArmClientCredentials credentials = new ArmClientCredentials(config);

            return new AzureMediaServicesClient(config.ArmEndpoint, credentials)
            {
                SubscriptionId = config.SubscriptionId,
            };
        }

        private static Transform EnsureTransformExists(IAzureMediaServicesClient client, string resourceGroupName, string accountName, string transformName, Preset preset)
        {
            Transform transform = client.Transforms.Get(resourceGroupName, accountName, transformName);

            if (transform == null)
            {
                TransformOutput[] outputs = new TransformOutput[]
                {
                    new TransformOutput(preset),
                };


                transform = client.Transforms.CreateOrUpdate(resourceGroupName, accountName, transformName, outputs);
            }

            return transform;
        }

        private static Asset CreateInputAsset(IAzureMediaServicesClient client, string resourceGroupName, string accountName, string assetName, string fileToUpload)
        {
            Asset asset = client.Assets.CreateOrUpdate(resourceGroupName, accountName, assetName, new Asset());

            var response = client.Assets.ListContainerSas(
                resourceGroupName,
                accountName,
                assetName,
                permissions: AssetContainerPermission.ReadWrite, 
                expiryTime: DateTime.UtcNow.AddHours(4).ToUniversalTime()
            );

            var sasUri = new Uri(response.AssetContainerSasUrls.First());
            CloudBlobContainer container = new CloudBlobContainer(sasUri);
            var blob = container.GetBlockBlobReference(Path.GetFileName(fileToUpload));
            blob.UploadFromFile(fileToUpload);

            return asset;
        }

        private static Asset CreateOutputAsset(IAzureMediaServicesClient client, string resourceGroupName, string accountName, string assetName)
        {
            Asset input = new Asset();

            return client.Assets.CreateOrUpdate(resourceGroupName, accountName, assetName, input);
        }

        private static Job SubmitJob(IAzureMediaServicesClient client, string resourceGroupName, string accountName, string transformName, string jobName, JobInput jobInput, string outputAssetName)
        {
            JobOutput[] jobOutputs =
            {
                new JobOutputAsset(outputAssetName),
            };

            Job job = client.Jobs.Create(
                resourceGroupName,
                accountName,
                transformName,
                jobName,
                new Job
                {
                    Input = jobInput,
                    Outputs = jobOutputs,
                });

            return job;
        }

        private static Job WaitForJobToFinish(IAzureMediaServicesClient client,
            string resourceGroupName,
            string accountName,
            string transformName,
            string jobName)
        {
            int SleepInterval = 60 * 1000;

            Job job = null;

            while (true)
            {
                job = client.Jobs.Get(resourceGroupName, accountName, transformName, jobName);

                if (job.State == JobState.Finished || job.State == JobState.Error || job.State == JobState.Canceled)
                {
                    break;
                }

                Console.WriteLine($"Job is {job.State}.");
                for (int i = 0; i < job.Outputs.Count; i++)
                {
                    JobOutput output = job.Outputs[i];
                    Console.Write($"\tJobOutput[{i}] is {output.State}.");
                    if (output.State == JobState.Processing)
                    {
                        Console.Write($"  Progress: {output.Progress}");
                    }
                    Console.WriteLine();
                }
                System.Threading.Thread.Sleep(SleepInterval);
            }

            return job;
        }
        private static void DownloadResults(IAzureMediaServicesClient client,
          string resourceGroup,
          string accountName,
          string assetName,
          string resultsFolder)
        {
            AssetContainerSas assetContainerSas = client.Assets.ListContainerSas(
                    resourceGroup,
                    accountName,
                    assetName,
                    permissions: AssetContainerPermission.Read,
                    expiryTime: DateTime.UtcNow.AddHours(1).ToUniversalTime()
                    );

            Uri containerSasUrl = new Uri(assetContainerSas.AssetContainerSasUrls.FirstOrDefault());
            CloudBlobContainer container = new CloudBlobContainer(containerSasUrl);

            string directory = Path.Combine(resultsFolder, assetName);
            Directory.CreateDirectory(directory);

            Console.WriteLine("Downloading results to {0}.", directory);

            foreach (IListBlobItem blobItem in container.ListBlobs(null, true, BlobListingDetails.None))
            {
                if (blobItem is CloudBlockBlob)
                {
                    CloudBlockBlob blob = blobItem as CloudBlockBlob;
                    string filename = Path.Combine(directory, blob.Name);

                    blob.DownloadToFile(filename, FileMode.Create);
                }
            }

            Console.WriteLine("Download complete.");
        }

        static void CleanUp(IAzureMediaServicesClient client,
                string resourceGroupName,
                string accountName, 
                string transformName)
        {
            foreach (var job in client.Jobs.List(resourceGroupName, accountName, transformName))
            {
                client.Jobs.Delete(resourceGroupName, accountName, transformName, job.Name);
            }

            foreach (var asset in client.Assets.List(resourceGroupName, accountName))
            {
                client.Assets.Delete(resourceGroupName, accountName, asset.Name);
            }
        }

    }
}
