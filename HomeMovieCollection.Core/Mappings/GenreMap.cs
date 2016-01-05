using FluentNHibernate.Mapping;
using HomeMovieCollection.Core.Objects;

namespace HomeMovieCollection.Core.Mappings
{
    class GenreMap : ClassMap<Genre>
    {

        public GenreMap()
        {
            Id(x => x.GenreId);

            Map(x => x.Name)
                .Length(100)
                .Not.Nullable();

            Map(x => x.Description)
                .Length(200);

            Map(x => x.UrlSlug)
                .Length(50)
                .Not.Nullable();

            HasMany(x => x.Movies)
                .Inverse()
                .Cascade.All()
                .KeyColumn("GenreId");

            //HasManyToMany(x => x.Movies)
            //  .Cascade.All().Inverse()
            //  .Table("MovieActorsMap");

        }
    }
}
