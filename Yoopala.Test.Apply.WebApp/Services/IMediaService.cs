using System.Collections.Generic;
using Yoopala.Test.Apply.Infrastructure.Data.Models.Medias;

namespace Yoopala.Test.Apply.WebApp.Services
{
    public interface IMediaService
    {
        List<Media> GetForIndex(int currentPage);
        int GetRowsCount();

        List<Media> GetForCustomSearch();

        Media GetForDetails(int mediaIndex);
    }
}
