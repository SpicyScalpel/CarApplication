using Car.Core.Domain;
using Car.Core.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car.Core.ServiceInterface
{
    public interface ICarServices
    {
        Task<Cars> Create(CarsDto dto);
        Task<Cars> GetAsync(Guid id);
        //Task<Cars> Update(CarsDto dto);
        //Task<Cars> Delete(CarsDto dto);
    }
}
