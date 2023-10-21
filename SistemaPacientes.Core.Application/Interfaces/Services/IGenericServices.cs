using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPacientes.Core.Application.Interfaces.Services
{
    public interface IGenericServices<SaveViewModel,ViewModel>
        where SaveViewModel : class
        where ViewModel : class
    {
        Task<ICollection<ViewModel>> GetAllAsync();
        Task<SaveViewModel> GetByIdAsync(int id);
        Task<SaveViewModel> AddAsync(SaveViewModel saveViewModel);
        Task UpdateAsync(SaveViewModel saveViewModel);
        Task DeleteAsync(int id);
    }
}
