using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeMovieCollection.Models
{
    public class JqInViewModel
    {

        public int rows { get; set; }
        public int page { get; set; }
        public string sidx { get; set; }
        public string sord { get; set; }

        public string sField { get; set; }
        public string sString { get; set; }

    }
}