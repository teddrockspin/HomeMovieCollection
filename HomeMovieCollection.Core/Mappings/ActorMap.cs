using FluentNHibernate.Mapping;
using HomeMovieCollection.Core.Objects;

namespace HomeMovieCollection.Core.Mappings
{
    class ActorMap : ClassMap<Actor>
    {

        public ActorMap()
        {
            Id(x => x.ActorId);

            Map(x => x.Description)
                .Length(5000);

            Map(x => x.FirstName)
                .Length(100)
                .Not.Nullable();

            Map(x => x.LastName)
                .Length(100)
                .Not.Nullable();

            Map(x => x.UrlSlug)
                .Length(500)
                .Not.Nullable();

            HasManyToMany(x => x.Movies)
                 .Cascade.All().Inverse()
                 .Table("MovieActorsMap");
        }
    }
}
