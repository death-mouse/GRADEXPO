using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GRADEXPO.Models
{
    public class ExpoFilesFromJson
    {
        public class ExpoFiles
        {
            public Int32 expoId { get; set; }
            public Int32 fileId { get; set; }
        }

        public class Values
        {
            public List<ExpoFiles> value { get; set; }
        }
    }
}