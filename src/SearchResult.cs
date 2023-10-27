﻿using HolidaySearchApplication.QueryModel;

namespace HolidaySearchApplication
{
    public class SearchResult<Data> where Data : ISearchResponseBase
    {
        public bool Success { get; set; }
        public string Error { get; set; } = string.Empty;
        public Data Value { get; set; }
    }
}