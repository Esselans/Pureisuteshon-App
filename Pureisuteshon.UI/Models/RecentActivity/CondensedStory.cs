﻿// Generated by Xamasoft JSON Class Generator
// http://www.xamasoft.com/json-class-generator

using Newtonsoft.Json;

namespace PlayStation_App.Models.RecentActivity
{

    public class CondensedStory
    {

        [JsonProperty("caption")]
        public string Caption { get; set; }

        [JsonProperty("targets")]
        public Target2[] Targets { get; set; }

        [JsonProperty("captionTemplate")]
        public string CaptionTemplate { get; set; }

        [JsonProperty("captionComponents")]
        public CaptionComponent2[] CaptionComponents { get; set; }

        [JsonProperty("storyId")]
        public string StoryId { get; set; }

        [JsonProperty("storyType")]
        public string StoryType { get; set; }

        [JsonProperty("source")]
        public Source2 Source { get; set; }

        [JsonProperty("smallImageUrl")]
        public string SmallImageUrl { get; set; }

        [JsonProperty("smallImageAspectRatio")]
        public string SmallImageAspectRatio { get; set; }

        [JsonProperty("largeImageUrl")]
        public string LargeImageUrl { get; set; }

        [JsonProperty("thumbnailImageUrl")]
        public string ThumbnailImageUrl { get; set; }

        [JsonProperty("date")]
        public string Date { get; set; }

        [JsonProperty("relevancy")]
        public double Relevancy { get; set; }

        [JsonProperty("commentCount")]
        public int CommentCount { get; set; }

        [JsonProperty("likeCount")]
        public int LikeCount { get; set; }

        [JsonProperty("titleId")]
        public string TitleId { get; set; }

        [JsonProperty("productId")]
        public string ProductId { get; set; }

        [JsonProperty("productUrl")]
        public string ProductUrl { get; set; }

        [JsonProperty("liked")]
        public bool Liked { get; set; }

        [JsonProperty("serviceProviderName")]
        public string ServiceProviderName { get; set; }

        [JsonProperty("hasComments")]
        public bool HasComments { get; set; }

        [JsonProperty("reshareable")]
        public bool Reshareable { get; set; }
    }

}
