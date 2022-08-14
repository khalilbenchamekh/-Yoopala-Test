using System;

namespace Yoopala.Test.Apply.Infrastructure.Data.Models.Medias
{
    public class Media
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Production { get; set; }
        public string Description { get; set; }
        public MediaType Type { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}
