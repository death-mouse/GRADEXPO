using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GRADEXPO.Models
{
    public class ProjectFromJson
    {
        public class Project
        {
            public string description { get; set; }
            public string projectName { get; set; }
            public Int32 projectLogoFileId { get; set; }
            public Int32 projectId { get; set; }
        }

        public class Values
        {
            public List<Project> value { get; set; }
        }
    }
}