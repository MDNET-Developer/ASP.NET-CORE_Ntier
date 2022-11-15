using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Train.NTier.DTOs.WorkDtos;

namespace Train.NTier.Business.Interfaces
{
    public interface IWorkService
    {
        Task<List<WorkListDto>> GetWorkLists();
        Task Create(WorkCreateDto dto);
        Task Remove(object id);
        Task<WorkListDto> GetById(object id);
        Task Update(WorkUpdateDto dto);
    }
}
