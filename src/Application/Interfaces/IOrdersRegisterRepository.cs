using Application.DTOs.Requests;
using Application.DTOs.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IOrdersRegisterRepository
    {
        Task<ResponseEntry> Create(RequestCreate createDto);
        Task<int> Delete(int id);
        Task<List<ResponseEntry>> GetAll();
        Task<ResponseEntry> GetById(int id);
        Task<ResponseEntry> Update(RequestUpdate updateDto);
    }
}