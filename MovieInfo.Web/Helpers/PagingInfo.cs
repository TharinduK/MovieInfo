using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieInfo.Web.Helpers
{
    public class PagingInfo
    {
        public int TotalRecordCount { get; set; }
        public int TotalPageCount { get; set; }

        public int CurrentPageNumber { get; set; }
        public int PageSize { get; set; }

        public string PreviousPageLink { get; set; }

        public string NextPageLink { get; set; }

        public PagingInfo(int recCount, int pageCount, int currPage, int pageSize, string prevLink, string nextLink)
        {
            TotalRecordCount = recCount;
            TotalPageCount = pageCount;
            CurrentPageNumber = currPage;
            PageSize = pageSize;
            PreviousPageLink = prevLink;
            NextPageLink = nextLink;
        }

    }
}