using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GRADEXPO.Models
{
    public class ExposFromJson
    {
       

        public class Expos
        {
            public List<GRADEXPO.Models.Expos> Expo { get; set; }
        }

        public class RootObject
        {
            public Expos Expos { get; set; }
        }
        public class Values
        {
            public List<GRADEXPO.Models.Expos> value { get; set; }
        }
    }
}