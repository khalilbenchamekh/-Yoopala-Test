using System;
using System.Collections.Generic;
using System.Linq;
using Yoopala.Test.Apply.Common.Constants;
using Yoopala.Test.Apply.Infrastructure.Data.Models.Medias;

namespace Yoopala.Test.Apply.WebApp.Models.Medias
{
    public class MediaPagingIndexViewModel
    {
        public IEnumerable<MediaIndexViewModel> Medias { get; set; }
        public int CurrentPage { get; set; }
        public int RowsCount { get; set; }
        public int MaxPageCount { get; private set; }

        public MediaPagingIndexViewModel(List<Media> media, int currentPage, int rowsCount)
        {
            ConvertFrom(media);
            CalculatePagination(currentPage, rowsCount);
        }

        private void ConvertFrom(List<Media> media)
        {
            Medias = media.Select(m => new MediaIndexViewModel(m)).ToList();

        }

        /// <summary>
        /// Calclates nesecary values for paging
        /// </summary>
        /// <param name="currentPage">the current page</param>
        /// <param name="rowsCount">the numer of rows available</param>
        private void CalculatePagination(int currentPage, int rowsCount)
        {
            CurrentPage = currentPage;
            RowsCount = rowsCount;
            var pageCount = (double)RowsCount / Constants.PagingRowsCount;
            MaxPageCount = (int)Math.Ceiling(pageCount);
        }
    }
}
