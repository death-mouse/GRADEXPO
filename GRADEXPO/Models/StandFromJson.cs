using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GRADEXPO.Models
{
    public class StandFromJson
    {
        public class Stands
        {
            public Models.Stands Stand { get; set; }
        }

        public class RootObject
        {
            public Stands Stands { get; set; }
        }
    }
}