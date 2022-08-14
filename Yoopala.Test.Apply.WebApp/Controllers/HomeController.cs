using Microsoft.AspNetCore.Mvc;

namespace Yoopala.Test.Apply.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private const string TitleKey = "Title";
        private const string TitleValue = "Bienvenue";
        public IActionResult Index()
        {
            // TODO 1 : Faire en sorte d'afficher le mot "Bienvenue" sur cette page d'accueil sans modifier le code de la vue associée à cette methode
            ViewData[TitleKey] = TitleValue;
            return View();
        }
    }
}
