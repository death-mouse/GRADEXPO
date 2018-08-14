using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GRADEXPO.Models
{
    public class ExpoFromJson
    {
        public class Expos
        {
            public GRADEXPO.Models.Expos Expo { get; set; }
        }

        public class RootObject
        {
            public Expos Expos { get; set; }
        }
    }
}