using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace HomeMovieCollection.Core.Objects
{
    public class Actor
    {
        public virtual int ActorId
        { get; set; }

        [Required(ErrorMessage = "First Name: Field is required")]
        [StringLength(500, ErrorMessage = "Last Name: Length should not exceed 100 characters")]

        public virtual string FirstName
        { get; set; }

        [Required(ErrorMessage = "Last Name: Field is required")]
        [StringLength(500, ErrorMessage = "Last Name: Length should not exceed 100 characters")]
        public virtual string LastName
        { get; set; }

        [Required(ErrorMessage = "UrlSlug: Field is required")]
        [StringLength(500, ErrorMessage = "UrlSlug: Length should not exceed 50 characters")]

        public virtual string UrlSlug
        { get; set; }

        public virtual string Description
        { get; set; }

        [JsonIgnore]
        public virtual IList<Movie> Movies
        { get; set; }
    }
}
