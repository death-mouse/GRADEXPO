using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GRADEXPO.Models
{
    public class VisitFromJson
    {
        public class Visit
        {
            public Int32 standPhotoFileId { get; set; }
            public DateTimeOffset visitDateTime { get; set; }
            public Int32 visitId { get; set; }
            public Int32 expoId { get; set; }
            public Int32 standId { get; set; }
            public Int32 vendorId { get; set; }
            public string comment { get; set; }
            public Int32 authorId { get; set; }
            public string visitSummary { get; set; }
            public Int32 visitType { get; set; }
            public Int32 visitCardFileId { get; set; }
        }

        public class Values
        {
            public List<Visit> value { get; set; }
        }
    }
}