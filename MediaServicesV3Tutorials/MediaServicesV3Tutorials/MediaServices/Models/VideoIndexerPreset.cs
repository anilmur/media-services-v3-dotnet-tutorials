// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// </auto-generated>

namespace Microsoft.Media.Encoding.Rest.ArmClient.Models
{
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// A video indexer preset that analyzes the audio and video.
    /// </summary>
    [Newtonsoft.Json.JsonObject("#Microsoft.Media.VideoIndexerPreset")]
    public partial class VideoIndexerPreset : AudioIndexerPreset
    {
        /// <summary>
        /// Initializes a new instance of the VideoIndexerPreset class.
        /// </summary>
        public VideoIndexerPreset()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the VideoIndexerPreset class.
        /// </summary>
        /// <param name="audioLanguage">Gets or sets the audio language for the
        /// video. Typically in the format of "language code-country/region"
        /// (e.g: en-US)</param>
        public VideoIndexerPreset(string audioLanguage = default(string))
            : base(audioLanguage)
        {
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

    }
}