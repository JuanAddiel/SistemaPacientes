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
        Task<ViewModel> GetByIdAsync(int id);
        Task<ViewModel> AddAsync(SaveViewModel saveViewModel);
        Task<ViewModel> UpdateAsync(int id, SaveViewModel saveViewModel);
        Task<bool> DeleteAsync(int id);
    }
}
