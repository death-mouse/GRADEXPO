using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GRADEXPO.Models
{
    public class SampleFromJson
    {
        public class Sample
        {
            public Int32 samplId { get; set; }
            public Int32 visitId { get; set; }
            public Int32 expoId { get; set; }
            public Int32 vendorId { get; set; }
            public string description { get; set; }
        }

        public class Values
        {
            List<Sample> value { get; set; }
        }
    }
}