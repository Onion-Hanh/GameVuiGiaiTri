﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonStorage.Paging
{
    public class PagerDTO
    {
        public int TotalItems { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public int StartPage { get; set; }
        public int EndPage { get; set; }

        public PagerDTO()
        {

        }
        public PagerDTO(int totalItems, int page, int pageSize)
        {
            int totalPages = (int)Math.Ceiling((decimal)totalItems / (decimal)pageSize);
            int currentPage = page;

            //int startPage = currentPage - 5;
            //int endPage = currentPage + 4;

            //if (startPage <= 0)
            //{
            //    endPage = endPage - (startPage - 1);
            //    startPage = 1;
            //}
            //if (endPage > totalPages)
            //{
            //    endPage = totalPages;
            //    if (endPage > 5)
            //    {
            //        startPage = endPage - 4;
            //    }
            //}
            int startPage = 1;
            int endPage = totalPages;

            TotalItems = totalItems;
            CurrentPage = currentPage;
            PageSize = pageSize;
            TotalPages = totalPages;
            StartPage = startPage;
            EndPage = endPage;
        }
    }
}
