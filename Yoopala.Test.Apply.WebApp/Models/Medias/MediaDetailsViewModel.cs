using Yoopala.Test.Apply.Infrastructure.Data.Models.Medias;

namespace Yoopala.Test.Apply.WebApp.Models.Medias
{
    /// <summary>
    /// View Model used to help viewing details of a media
    /// </summary>
    public class MediaDetailsViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Production { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public string ReleaseDate { get; set; }

        public MediaDetailsViewModel(Media media)
        {
            ConvertFrom(media);
        }

        /// <summary>
        /// Convert a Media to MediaDetailsViewModel
        /// </summary>
        /// <param name="media">the media to convert</param>
        private void ConvertFrom(Media media)
        {
            Id = media.Id;
            Title = media.Title;
            Production = media.Production;
            Description = media.Description;
            Type = media.Type.ToString();
            ReleaseDate = media.ReleaseDate.ToShortDateString();
        }
    }
}
