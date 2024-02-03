using Application.DTOs.Requests;
using Application.DTOs.Responses;
using System.Collections.Generic;
using Application.Interfaces;
using System.Threading.Tasks;

namespace Application
{
    public class OrdersRegisterService
    {
        private readonly IOrdersRegisterRepository _repository;
        public OrdersRegisterService(IOrdersRegisterRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResponseEntry> GetById(int id)
        {
            return await _repository.GetById(id);
        }
        public async Task<ResponseEntries> GetAll()
        {
            var list = await _repository.GetAll();
            return new ResponseEntries() {Entries = list};
        }
        public async Task<ResponseEntry> Create(RequestCreate createDto)
        {
            return await _repository.Create(createDto);
        }
        public async Task<ResponseEntry> Update(RequestUpdate updateDto)
        {
            return await _repository.Update(updateDto);
        }

        public async Task Delete(int id)
        {
           await _repository.Delete(id);
        }
    }
}
