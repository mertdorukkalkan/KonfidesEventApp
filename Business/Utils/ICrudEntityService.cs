using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Business.DTOs;
using Core.Utils.Results;

namespace Business.Utils
{
    public interface ICrudEntityService<TEntityGetDto, TEntityCreateDto, TEntityUpdateDto>
        where TEntityGetDto : IEntityGetDto, new()
        where TEntityCreateDto : IDto, new()
        where TEntityUpdateDto : IDto, new()
    {
        Task<IDataResult<TEntityGetDto>> AddAsync(TEntityCreateDto input);
        Task<IDataResult<TEntityGetDto>> UpdateAsync(int id, TEntityUpdateDto input);
        Task<IResult> DeleteByIdAsync(int id);
        Task<IDataResult<TEntityGetDto>> GetByIdAsync(int id);
        Task<IDataResult<ICollection<TEntityGetDto>>> GetAllAsync();
    }
}