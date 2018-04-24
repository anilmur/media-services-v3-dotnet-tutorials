// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// </auto-generated>

namespace Microsoft.Media.Encoding.Rest.ArmClient.Models
{
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// Class to specify configurations of Widevine in Streaming Policy
    /// </summary>
    public partial class StreamingPolicyWidevineConfiguration
    {
        /// <summary>
        /// Initializes a new instance of the
        /// StreamingPolicyWidevineConfiguration class.
        /// </summary>
        public StreamingPolicyWidevineConfiguration()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the
        /// StreamingPolicyWidevineConfiguration class.
        /// </summary>
        /// <param name="customLicenseAcquisitionUrlTemplate">The template for
        /// a customer service to deliver keys to end users.  Not needed if
        /// using the built in Key Delivery service.</param>
        public StreamingPolicyWidevineConfiguration(string customLicenseAcquisitionUrlTemplate = default(string))
        {
            CustomLicenseAcquisitionUrlTemplate = customLicenseAcquisitionUrlTemplate;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets the template for a customer service to deliver keys to
        /// end users.  Not needed if using the built in Key Delivery service.
        /// </summary>
        [JsonProperty(PropertyName = "customLicenseAcquisitionUrlTemplate")]
        public string CustomLicenseAcquisitionUrlTemplate { get; set; }

    }
}