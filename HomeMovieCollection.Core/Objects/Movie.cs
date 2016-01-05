using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HomeMovieCollection.Core.Objects
{
    public class Movie
    {
        [Required(ErrorMessage = "MovieId: Field is required")]
        public virtual int MovieId
        { get; set; }

        [Required(ErrorMessage = "Title: Field is required")]
        [StringLength(500, ErrorMessage = "Title: Length should not exceed 500 characters")]
        public virtual string Title
        { get; set; }

        public virtual string Summary
        { get; set; }

        public virtual string Description
        { get; set; }

        [Required(ErrorMessage = "Meta: Field is required")]
        [StringLength(1000, ErrorMessage = "Meta: UrlSlug should not exceed 50 characters")]

        public virtual string UrlSlug
        { get; set; }

        public virtual string Director
        { get; set; }

        public virtual string Cover
        { get; set; }

        public virtual string Format
        { get; set; }

        public virtual string Region
        { get; set; }

        public virtual int Rating
        { get; set; }

        public virtual DateTime ReleaseDate
        { get; set; }

        public virtual int? RunTime
        { get; set; }

        public virtual DateTime AddedOn
        { get; set; }

        public virtual DateTime? Modified
        { get; set; }

        public virtual IList<Actor> Actors
        { get; set; }

        public virtual Genre Genre
        { get; set; }

    }
}
