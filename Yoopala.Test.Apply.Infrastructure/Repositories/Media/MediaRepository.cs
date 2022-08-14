using System;
using System.Collections.Generic;
using System.Linq;
using Yoopala.Test.Apply.Infrastructure.Data.Models.Medias;

namespace Yoopala.Test.Apply.Infrastructure.Repositories.Medias
{
    public class MediaRepository : IRepository<Media>
    {
        private static readonly int currentIdValue = 0;
        // TODO 2 : Mettez des IDs aux Médias ci-desous
        private static readonly List<Media> _medias = new List<Media>()
        {
            new Media { Id = ++currentIdValue, Title = "Avengers: Endgame", Production = "Marvel Studios", Type = MediaType.Movie, ReleaseDate = DateTime.Parse("24/4/2019"), Description = "Film américain réalisé par Anthony et Joe Russo, sorti en 2019" },
            new Media { Id = ++currentIdValue, Title = "Retour vers le futur", Production = "Amblin Entertainment", Type = MediaType.Movie, ReleaseDate = DateTime.Parse("30/10/1985"), Description = "Film de science-fiction américain réalisé par Robert Zemeckis, sorti en 1985." },
            new Media { Id = ++currentIdValue, Title = "Le Roi lion", Production = "Walt Disney Pictures", Type = MediaType.Movie, ReleaseDate = DateTime.Parse("9/11/1994"), Description = "43e long-métrage d'animation et le 32e « Classique d'animation » des studios Disney. Sorti en 1994" },
            new Media { Id = ++currentIdValue, Title = "Tarzan", Production = "Walt Disney Pictures", Type = MediaType.Movie, ReleaseDate = DateTime.Parse("9/9/1999"), Description = "59e long-métrage d'animation et le 37e « Classique d'animation » des studios Disney. Sorti en 1999, il est inspiré du personnage créé par Edgar Rice Burroughs en 1912." },
            new Media { Id = ++currentIdValue, Title = "Le Monde de Dory", Production = "Walt Disney Pictures", Type = MediaType.Movie, ReleaseDate = DateTime.Parse("22/9/2016"), Description = "film d'animation réalisé par Andrew Stanton pour les studios Pixar, sorti en 2016. C'est un gros succès du box-office mondial. C'est la suite du film Le Monde de Nemo, sorti en 2003" },

            new Media { Id = ++currentIdValue, Title = "Hindenburg", Type = MediaType.Photo, ReleaseDate = DateTime.Parse("2/11/2018"), Description = "Les conséquences immédiates d’une attaque de napalm accidentelle est capturé par Nick Ut lors de la guerre du Vietnam en 1972" },
            new Media { Id = ++currentIdValue, Title = "Guerillero Heroico", Type = MediaType.Photo, ReleaseDate = DateTime.Parse("21/7/2018"), Description = "portrait, extrêmement connu dans la culture pop, de Che Guevara réalisé en 1960 par Alberto Korda" },

            new Media { Id = ++currentIdValue, Title = "Highway to Hell", Type = MediaType.Music, ReleaseDate = DateTime.Parse("27/7/1979"), Description = "Highway to Hell est le 6e album studio du groupe de hard rock australien, AC/DC. Il est sorti le 27 juillet 1979" },
            new Media { Id = ++currentIdValue, Title = "TNT", Type = MediaType.Music, ReleaseDate = DateTime.Parse("15/12/1975"), Description = "TNT est une chanson du groupe de hard rock australien AC/DC sortie en single en Océanie en 1976" },
            new Media { Id = ++currentIdValue, Title = "Hells Bells", Type = MediaType.Music, ReleaseDate = DateTime.Parse("25/7/1980"), Description = "Hells Bells est la première chanson de l'album Back in Black d'AC/DC. Cet album est le premier avec le chanteur Brian Johnson qui est sorti le 25 juillet 1980" },
        };




        public List<Media> GetAll(int currentPage, int rowsCount)
        {
            return _medias.OrderBy(media => media.Id)
                    .Skip((currentPage - 1) * rowsCount)
                    .Take(rowsCount)
                    .ToList();
        }
        /// <summary>
        /// Gets the count of rows
        /// </summary>
        /// <returns> the count of rows</returns>
        public int GetRowsCount()
        {
            return _medias.Count();
        }

        public List<Media> GetAll(Query<Media> query)
        {
            return _medias.AsQueryable().Where(query.GetCriteria()).ToList();
        }

        public Media First(Query<Media> query)
        {
            return _medias.AsQueryable().FirstOrDefault(query.GetCriteria());
        }
    }
}
