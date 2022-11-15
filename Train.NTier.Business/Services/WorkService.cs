using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Train.NTier.Business.Interfaces;
using Train.NTier.DataAccsess.UnitOfWork;
using Train.NTier.DTOs.WorkDtos;
using Train.NTier.Entity.Concrete;

namespace Train.NTier.Business.Services
{
    public class WorkService : IWorkService
    {
        private readonly Uow _uow;

        public WorkService(Uow uow)
        {
            _uow = uow;
        }

        public async Task Create(WorkCreateDto dto)
        {
            await _uow.GetRepository<Work>().Create(new()
            {
                Description = dto.Description,
                IsCompleted = dto.IsCompleted
            });
            await _uow.SaveChanges();
        }

        public async Task<WorkListDto> GetById(object id)
        {
           var getwork= await _uow.GetRepository<Work>().GetbyId(id);
            return new() {
                Description = getwork.Description,
                IsCompleted = getwork.IsCompleted
            };
        }

        public async Task<List<WorkListDto>> GetWorkLists()
        {
            var list = await _uow.GetRepository<Work>().GetAll();

            var worklist = new List<WorkListDto>();
            if (list != null && list.Count > 0)
            {
                foreach (var item in list)
                {
                    worklist.Add(new()
                    {
                        Description = item.Description,
                        Id = item.Id,
                        IsCompleted = item.IsCompleted
                    });
                }
            }
            return worklist;
        }

        public async Task Remove(object id)
        {
          var removed=  await _uow.GetRepository<Work>().GetbyId(id);
            _uow.GetRepository<Work>().Remove(removed);
           await _uow.SaveChanges();
        }

        public async Task Update(WorkUpdateDto dto)
        {
            _uow.GetRepository<Work>().Update(new()
            {
                Description=dto.Description,
                IsCompleted = dto.IsCompleted,
                Id=dto.Id
            });
            await _uow.SaveChanges();

        }
    }
}
