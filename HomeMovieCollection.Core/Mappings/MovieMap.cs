using FluentNHibernate.Mapping;
using HomeMovieCollection.Core.Objects;

namespace HomeMovieCollection.Core.Mappings
{
    class MovieMap : ClassMap<Movie>
    {
        public MovieMap()
        {
            Id(x => x.MovieId);

            Map(x => x.Title)
                .Length(200)
                .Not.Nullable();

            Map(x => x.Summary)
                .Length(500);

            Map(x => x.Description)
                .Length(5000);

            Map(x => x.Director)
                .Length(100);

            Map(x => x.Cover)
                .Length(250);

            Map(x => x.Format)
                .Length(100);

            Map(x => x.Region)
                .Length(500);

            Map(x => x.UrlSlug)
                .Length(500);

            Map(x => x.ReleaseDate);

            Map(x => x.RunTime);

            Map(x => x.AddedOn)
                .Not.Nullable();

            Map(x => x.Modified);

            Map(x => x.Rating);

            //HasManyToMany(x => x.Genres)
            //    .Table("MovieGenresMap");

            References(x => x.Genre)
                .Column("GenreId")
                .Not.Nullable();

            HasManyToMany(x => x.Actors)
                 .Table("MovieActorsMap");
        }
    }
}
