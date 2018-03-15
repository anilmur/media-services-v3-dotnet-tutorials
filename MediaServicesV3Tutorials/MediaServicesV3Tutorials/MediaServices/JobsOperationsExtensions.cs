// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// </auto-generated>

namespace Microsoft.Media.Encoding.Rest.ArmClient
{
    using Microsoft.Rest;
    using Microsoft.Rest.Azure;
    using Microsoft.Rest.Azure.OData;
    using Models;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Extension methods for JobsOperations.
    /// </summary>
    public static partial class JobsOperationsExtensions
    {
            /// <summary>
            /// List Jobs
            /// </summary>
            /// <remarks>
            /// Lists all of the Jobs for the Transform.
            /// </remarks>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='transformName'>
            /// The Transform name.
            /// </param>
            /// <param name='odataQuery'>
            /// OData parameters to apply to the operation.
            /// </param>
            public static IPage<Job> List(this IJobsOperations operations, string transformName, ODataQuery<Job> odataQuery = default(ODataQuery<Job>))
            {
                return operations.ListAsync(transformName, odataQuery).GetAwaiter().GetResult();
            }

            /// <summary>
            /// List Jobs
            /// </summary>
            /// <remarks>
            /// Lists all of the Jobs for the Transform.
            /// </remarks>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='transformName'>
            /// The Transform name.
            /// </param>
            /// <param name='odataQuery'>
            /// OData parameters to apply to the operation.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<IPage<Job>> ListAsync(this IJobsOperations operations, string transformName, ODataQuery<Job> odataQuery = default(ODataQuery<Job>), CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.ListWithHttpMessagesAsync(transformName, odataQuery, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Get Job
            /// </summary>
            /// <remarks>
            /// Gets a Job.
            /// </remarks>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='transformName'>
            /// The Transform name.
            /// </param>
            /// <param name='jobName'>
            /// The Job name.
            /// </param>
            public static Job Get(this IJobsOperations operations, string transformName, string jobName)
            {
                return operations.GetAsync(transformName, jobName).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Get Job
            /// </summary>
            /// <remarks>
            /// Gets a Job.
            /// </remarks>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='transformName'>
            /// The Transform name.
            /// </param>
            /// <param name='jobName'>
            /// The Job name.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<Job> GetAsync(this IJobsOperations operations, string transformName, string jobName, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.GetWithHttpMessagesAsync(transformName, jobName, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Create Job
            /// </summary>
            /// <remarks>
            /// Creates a Job.
            /// </remarks>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='transformName'>
            /// The Transform name.
            /// </param>
            /// <param name='jobName'>
            /// The Job name.
            /// </param>
            /// <param name='parameters'>
            /// </param>
            public static Job CreateOrUpdate(this IJobsOperations operations, string transformName, string jobName, Job parameters)
            {
                return operations.CreateOrUpdateAsync(transformName, jobName, parameters).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Create Job
            /// </summary>
            /// <remarks>
            /// Creates a Job.
            /// </remarks>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='transformName'>
            /// The Transform name.
            /// </param>
            /// <param name='jobName'>
            /// The Job name.
            /// </param>
            /// <param name='parameters'>
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<Job> CreateOrUpdateAsync(this IJobsOperations operations, string transformName, string jobName, Job parameters, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.CreateOrUpdateWithHttpMessagesAsync(transformName, jobName, parameters, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Delete Job
            /// </summary>
            /// <remarks>
            /// Deletes a Job.
            /// </remarks>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='transformName'>
            /// The Transform name.
            /// </param>
            /// <param name='jobName'>
            /// The Job name.
            /// </param>
            public static void Delete(this IJobsOperations operations, string transformName, string jobName)
            {
                operations.DeleteAsync(transformName, jobName).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Delete Job
            /// </summary>
            /// <remarks>
            /// Deletes a Job.
            /// </remarks>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='transformName'>
            /// The Transform name.
            /// </param>
            /// <param name='jobName'>
            /// The Job name.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task DeleteAsync(this IJobsOperations operations, string transformName, string jobName, CancellationToken cancellationToken = default(CancellationToken))
            {
                (await operations.DeleteWithHttpMessagesAsync(transformName, jobName, null, cancellationToken).ConfigureAwait(false)).Dispose();
            }

            /// <summary>
            /// Cancel Job
            /// </summary>
            /// <remarks>
            /// Cancel a Job.
            /// </remarks>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='transformName'>
            /// The Transform name.
            /// </param>
            /// <param name='jobName'>
            /// The Job name.
            /// </param>
            public static void CancelJob(this IJobsOperations operations, string transformName, string jobName)
            {
                operations.CancelJobAsync(transformName, jobName).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Cancel Job
            /// </summary>
            /// <remarks>
            /// Cancel a Job.
            /// </remarks>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='transformName'>
            /// The Transform name.
            /// </param>
            /// <param name='jobName'>
            /// The Job name.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task CancelJobAsync(this IJobsOperations operations, string transformName, string jobName, CancellationToken cancellationToken = default(CancellationToken))
            {
                (await operations.CancelJobWithHttpMessagesAsync(transformName, jobName, null, cancellationToken).ConfigureAwait(false)).Dispose();
            }

            /// <summary>
            /// List Jobs
            /// </summary>
            /// <remarks>
            /// Lists all of the Jobs for the Transform.
            /// </remarks>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='nextPageLink'>
            /// The NextLink from the previous successful call to List operation.
            /// </param>
            public static IPage<Job> ListNext(this IJobsOperations operations, string nextPageLink)
            {
                return operations.ListNextAsync(nextPageLink).GetAwaiter().GetResult();
            }

            /// <summary>
            /// List Jobs
            /// </summary>
            /// <remarks>
            /// Lists all of the Jobs for the Transform.
            /// </remarks>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='nextPageLink'>
            /// The NextLink from the previous successful call to List operation.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<IPage<Job>> ListNextAsync(this IJobsOperations operations, string nextPageLink, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.ListNextWithHttpMessagesAsync(nextPageLink, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

    }
}