using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GRADEXPO.Models;

namespace GRADEXPO.App_Code
{
    public static class PrintEventCalendar
    {
        public static HtmlString CreateEventList(List<VisitFromJson.Visit> visitFromJsons)
        {
            string result = "";
            int count = visitFromJsons.Count;
            int i = 1;
            foreach (VisitFromJson.Visit visit in visitFromJsons)
            {
                result += "{";
                result += string.Format("title: '{0}',", visit.comment);
                result += string.Format("start: '{0}',", visit.visitDateTime.UtcDateTime.ToString("yyyy-MM-ddTHH:mm:ss"));
                //result += string.Format("end: '{0}',", visit.visitDateTime.UtcDateTime.ToString("yyyy-MM-ddTHH:mm:ss"));
                //result += "overlap: false,";
                //result += "rendering: 'background',";
                result += "color: '#257e4a'";
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