using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using Yoopala.Test.Apply.Common.Constants;
using Yoopala.Test.Apply.Infrastructure.Data.Models.Medias;
using Yoopala.Test.Apply.Infrastructure.Repositories.Medias;

namespace Yoopala.Test.Apply.WebApp.Services
{
    public class MediaService : IMediaService
    {
        private readonly IRepository<Media> _mediaRepository;
        private readonly ILogger _logger = LogManager.GetCurrentClassLogger();

        public MediaService(IRepository<Media> repository)
        {
            _mediaRepository = repository;
        }

        public List<Media> GetForIndex(int currentPage)
        {
            _logger.Info($"Getting all medias, with paging for current page : {currentPage}");
            if (currentPage == 0)
            {
                currentPage = 1;
            }
            return _mediaRepository
                .GetAll(currentPage, Constants.PagingRowsCount);
        }

        /// <summary>
        /// Gets the count of rows
        /// </summary>
        /// <returns> the count of rows</returns>
        public int GetRowsCount()
        {
            _logger.Info($"Getting totale rows count for media");
            return _mediaRepository.GetRowsCount();
        }

        public List<Media> GetForCustomSearch()
        {
            _logger.Info($"Begin Getting all medias using provided query");
            Query<Media> query = new Query<Media>();
            query.Add(_ => true);
            // TODO 4 : Faire en sorte de récupérer, en réutilisant cette Query : 
            // les films de Walt Disney sorties avant le 5 février 2000" ET les musiques d'avant le 3 juin 1980
            query.Add(media =>
            (media.Type == MediaType.Movie && media.Production == "Walt Disney sorties" && media.ReleaseDate <= new DateTime(2000, 2, 5))
            || (media.Type == MediaType.Music && media.ReleaseDate <= new DateTime(1980, 6, 3))
            );

            _logger.Info($"End Getting all medias using provided query");
            return _mediaRepository.GetAll(query);
        }

        /// <summary>
        /// Get details for a media
        /// </summary>
        /// <param name="mediaIndex">index of required entity</param>
        /// <returns>Dtails of a Media if found, null if not</returns>
        public Media GetForDetails(int mediaIndex)
        {
            _logger.Info($"Beging Getting details for a specefique media index :{mediaIndex}");
            Query <Media> query = new Query<Media>();
            query.Add(media =>media.Id == mediaIndex);
            _logger.Info($"End Getting details for a specefique media index :{mediaIndex}");
            return _mediaRepository.GetAll(query).FirstOrDefault();
        }
    }
}
