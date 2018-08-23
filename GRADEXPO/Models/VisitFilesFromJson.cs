using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GRADEXPO.Models
{
    public class VisitFilesFromJson
    {
        public class VisitFiles
        {
            public Int32 fileId { get; set; }
            public Int32 visitId { get; set; }
        }

        public class Values
        {
            public List<VisitFiles> value { get; set; }
        }
    }
}