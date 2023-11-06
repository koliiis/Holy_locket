using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Holy_locket.BLL.Services.Abstraction
{
    internal interface IPatientService : IDisposable
    {
        Task DeleteProject(int id);
        Task DeleteProject(Patien project);
        Task UpdateProject(ProjectDTO project);
        Task CreateProject(ProjectDTO project);
    }
}
