using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Dream_Theater_Fan_Page.Models
{
    public class Pager
    {
        public int TotalItems { get; private set; }
        public int CurrentPage { get; private set; }
        public int PageSize { get; private set; }
        public int TotalPages { get; private set; }
        public int StartPage { get; private set; }
        public int EndPage { get; private set; }

        public Pager(int totalItems, int page, int pageSize = 10)
        {
            TotalItems = totalItems;
            CurrentPage = page;
            PageSize = pageSize;

            TotalPages = (int)Math.Ceiling((decimal)TotalItems / (decimal)PageSize);

            int maxPagesToShow = 10;
            StartPage = Math.Max(1, CurrentPage - maxPagesToShow / 2);
            EndPage = Math.Min(TotalPages, StartPage + maxPagesToShow - 1);


            if (EndPage - StartPage + 1 < maxPagesToShow)
            {
                StartPage = Math.Max(1, EndPage - maxPagesToShow + 1);
            }
        }
    }
}
