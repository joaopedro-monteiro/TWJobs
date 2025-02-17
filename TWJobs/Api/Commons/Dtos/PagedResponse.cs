﻿using System.Text.Json.Serialization;

namespace TWJobs.Api.Commons.Dtos
{
    public class PagedResponse<T> : ResourceResponse
    {
        public ICollection<T>? Items { get; set; }
        [JsonIgnore]
        public int PageNumber { get; set; }
        [JsonIgnore]
        public int PageSize { get; set; }
        [JsonIgnore]
        public int FirstPage { get; set; }
        [JsonIgnore]
        public int LastPage { get; set; }
        [JsonIgnore]
        public int TotalPages { get; set; }
        [JsonIgnore]
        public int TotalElements { get; set; }
        [JsonIgnore]
        public bool HasPreviousPage { get; set; }
        [JsonIgnore]
        public bool HasNextPage { get; set; }
    }
}
