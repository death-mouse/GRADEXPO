using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using GRADEXPO.Models;
using Newtonsoft.Json;

namespace GRADEXPO.Repository
{
    public class ProjectRepository : IProjectRepository
    {
        public async Task<ProjectFromJson.Project> AddProjectAsync(ProjectFromJson.Project _project)
        {
            ProjectFromJson.Project result = null;
            switch (Properties.Settings.Default.GetDataFrom)
            {
                case "Json":
                   
                    string json = JsonConvert.SerializeObject(_project, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore });
                    string res = await HttpClient.Browser.ByMethodAsync(string.Format("{0}{1}", Properties.Settings.Default.BaseUrlApi, Properties.Settings.Default.postfixGetProject), json, "POST");
                    result = await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<ProjectFromJson.Project>(res));
                    break;
                default:
                    throw new System.Exception(string.Format("Приложение не умеет работать с типом данных {0}. Если вам нужно работать с такими типом данным, обратитесь к разработчику", Properties.Settings.Default.GetDataFrom));
            }
            return result;
        }

        public async Task DeleteProjectAsync(int _id)
        {
            switch (Properties.Settings.Default.GetDataFrom)
            {
                case "Json":
                    string res = await HttpClient.Browser.DeleteAsync(string.Format("{0}{1}({2})", Properties.Settings.Default.BaseUrlApi, Properties.Settings.Default.postfixGetProject, _id));
                    break;
                default:
                    throw new System.Exception(string.Format("Приложение не умеет работать с типом данных {0}. Если вам нужно работать с такими типом данным, обратитесь к разработчику", Properties.Settings.Default.GetDataFrom));
            }
        }

        public async Task<IEnumerable<ProjectFromJson.Project>> GeProjectsAsync()
        {
            List<ProjectFromJson.Project> projects = null;
            switch (Properties.Settings.Default.GetDataFrom)
            {
                case "Json":
                    
                    string json = await HttpClient.Browser.GetAsync(string.Format("{0}{1}", Properties.Settings.Default.BaseUrlApi, Properties.Settings.Default.postfixGetProject));
                    ProjectFromJson.Values rootObject = await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<ProjectFromJson.Values>(json));
                    projects = rootObject.value;
                    break;
                default:
                    throw new System.Exception(string.Format("Приложение не умеет работать с типом данных {0}. Если вам нужно работать с такими типом данным, обратитесь к разработчику", Properties.Settings.Default.GetDataFrom));
            }

            return projects;
        }

        public async Task<ProjectFromJson.Project> GetProjectAsync(int _id)
        {
            ProjectFromJson.Project project = null;
            switch (Properties.Settings.Default.GetDataFrom)
            {
                case "Json":

                    string json = await HttpClient.Browser.GetAsync(string.Format("{0}{1}({2})", Properties.Settings.Default.BaseUrlApi, Properties.Settings.Default.postfixGetProject, _id));
                    project = await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<ProjectFromJson.Project>(json));
                    break;
                default:
                    throw new System.Exception(string.Format("Приложение не умеет работать с типом данных {0}. Если вам нужно работать с такими типом данным, обратитесь к разработчику", Properties.Settings.Default.GetDataFrom));
            }

            return project;
        }

        public async Task<ProjectFromJson.Project> UpdateProjectAsync(ProjectFromJson.Project _project)
        {
            ProjectFromJson.Project project = null;
            switch (Properties.Settings.Default.GetDataFrom)
            {
                case "Json":

                    string json = JsonConvert.SerializeObject(_project, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore });
                    string res = await HttpClient.Browser.ByMethodAsync(string.Format("{0}{1}({2})", Properties.Settings.Default.BaseUrlApi, Properties.Settings.Default.postfixGetProject, _project.projectId), json, "PUT");
                    project = await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<ProjectFromJson.Project>(json));
                    break;
                default:
                    throw new System.Exception(string.Format("Приложение не умеет работать с типом данных {0}. Если вам нужно работать с такими типом данным, обратитесь к разработчику", Properties.Settings.Default.GetDataFrom));
            }

            return project;
        }
    }
}