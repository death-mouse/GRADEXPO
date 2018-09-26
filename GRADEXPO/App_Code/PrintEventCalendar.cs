using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GRADEXPO.ViewModels;

namespace GRADEXPO.App_Code
{
    public static class PrintEventCalendar
    {
        public static HtmlString CreateEventList(List<PlanVisitViewModel> planVisitModels)
        {
            string result = "";
            int count = planVisitModels.Count;
            int i = 1;
            foreach (PlanVisitViewModel visit in planVisitModels)
            {
                result += "{";
                result += string.Format("title: '{0}',", visit.Title);
                result += string.Format("start: '{0}',", visit.start.ToString("yyyy-MM-ddTHH:mm:ss"));
                //result += string.Format("end: '{0}',", visit.visitDateTime.UtcDateTime.ToString("yyyy-MM-ddTHH:mm:ss"));
                //result += "overlap: false,";
                //result += "rendering: 'background',";
                if(visit.type == 0)
                    result += "color: '#257e4a'";
                else
                    result += "color: '#3a87ad'";
                if (i == count)
                    result += "}";
                else
                    result += "},";
                i++;
            }
            return new HtmlString(result);
        }
    }
}