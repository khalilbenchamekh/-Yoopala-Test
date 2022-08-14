using Yoopala.Test.Apply.WebApp.Resources;
using Yoopala.Test.Apply.Infrastructure.Data.Models.Medias;

namespace Yoopala.Test.Apply.WebApp.Models.Medias
{
    public class MediaIndexViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }

        public MediaIndexViewModel(Media media)
        {
            ConvertFrom(media);
        }

        private void ConvertFrom(Media media)
        {
            Id = media.Id;
            Title = media.Title;
            Type = media.Type.GetDisplayName();
            // TODO 8 : 
            // - Afficher le type litteral en français à l'aide d'un code déjà existant dans la solution et via "media.Type"
            // - Corriger l'affichage de celui pour "[[Music]]"

        }
    }
}
