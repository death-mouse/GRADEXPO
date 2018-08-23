using GRADEXPO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace GRADEXPO.Repository
{
    public interface IProjectRepository
    {
        Task<ProjectFromJson.Project> UpdateProjectAsync(ProjectFromJson.Project _project);
        Task<ProjectFromJson.Project> GetProjectAsync(int _id);
        Task<ProjectFromJson.Project> AddProjectAsync(ProjectFromJson.Project _project);
        Task<IEnumerable<ProjectFromJson.Project>> GeProjectsAsync();
        Task DeleteProjectAsync(int _id);
    }
}