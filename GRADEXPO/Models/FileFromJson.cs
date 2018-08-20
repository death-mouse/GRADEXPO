using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GRADEXPO.Models
{
    public class FileFromJson
    {
        public class File
        {
            public DateTimeOffset dateTime { get; set; }
            public string filename { get; set; }
            public Int32 authorId { get; set; }
            public string content { get; set; }
            public Int32 fileId { get; set; }
        }

        public class Values
        {
            public List<File> value { get; set; }
        }
    }
}