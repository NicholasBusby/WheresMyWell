using System.Collections.Generic;
using System.Threading.Tasks;
using Wheres_My_Well.Models;

namespace Wheres_My_Well.Services
{
    public interface IWellService
    {
        Task<IEnumerable<Well>> GetWells();
    }
}
