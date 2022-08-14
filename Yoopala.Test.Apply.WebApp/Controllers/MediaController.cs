using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using Yoopala.Test.Apply.Common.Constants;
using Yoopala.Test.Apply.WebApp.Models.Medias;
using Yoopala.Test.Apply.WebApp.Services;

namespace Yoopala.Test.Apply.WebApp.Controllers
{
    public class MediaController : Controller
    {
        private const string ErrorKey = "Error";
        private readonly IMediaService _mediaService;

        public MediaController(IMediaService mediaService)
        {
            _mediaService = mediaService ?? throw new ArgumentNullException(nameof(mediaService));
        }

        public IActionResult Index(int page)
        {
            // TODO 6 : Paginer par lot de 5 les résultats de cette page
            var rowsCount = _mediaService.GetRowsCount();
            var mediaDataList = _mediaService.GetForIndex(page);
            var mediasVM = new MediaPagingIndexViewModel(mediaDataList, page, rowsCount);
            return View(mediasVM);
        }

        public IActionResult CustomSearch()
        {
            var medias = _mediaService.GetForCustomSearch().Select(m => new MediaIndexViewModel(m)).ToList();
            return View(medias);
        }

        public IActionResult Details(int? key)
        {
            // TODO 5 : Réaliser la page Details à l'instar de la page Index ( MediaDetailsViewModel ) 
            // mais qui affichera cette fois TOUTES les informations des Médias et de façon graphiquement plus adapté
            MediaDetailsViewModel mediaView = null;
            if (key.HasValue)
            {
                var media = _mediaService.GetForDetails(key.Value);
                if (media != null)
                {
                    mediaView = new MediaDetailsViewModel(media);
                }
                else
                {
                    ViewData[ErrorKey] = ErrorConstants.MediaNotFound;
                }
            }
            else
            {
                ViewData[ErrorKey] = ErrorConstants.MediaIdRequired;
            }
            
            
            return View(mediaView);
        }
    }
}
