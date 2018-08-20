using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GRADEXPO.Models
{
    public class StandsFromJson
    {
        public class Stands
        {
            public List<Models.Stands> Stand { get; set; }
        }

        public class RootObject
        {
            public Stands Stands { get; set; }
        }

        public class Values
        {
            public List<Models.Stands> value { get; set; }
        }
    }
}