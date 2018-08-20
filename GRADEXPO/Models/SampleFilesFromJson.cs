using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GRADEXPO.Models
{
    public class SampleFilesFromJson
    {
        public Int32 sampleId { get; set; }
        public Int32 fileId { get; set; }
    }

    public class Values
    {
        public List<SampleFilesFromJson> value { get; set; }
    }
}