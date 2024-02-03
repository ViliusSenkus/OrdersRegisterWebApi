using Application.DTOs.Requests;
using Application.DTOs.Responses;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Application
{
    public class OrdersRegisterService
    {
        public ResponseEntry GetById(int id)
        {
            return new ResponseEntry()
            {
                Id = id,
                Executor = "ieskomas irasas - Nr." + id
            };
        }
        public ResponseEntries GetAll()
        {
            List<ResponseEntry> list = new List<ResponseEntry>();
            for (int x = 0; x < 3; x++)
            {
                list.Add(new ResponseEntry()
                {
                    Id = x,
                    Executor = "ieskomas irasas - Nr." + x
                });
            }

            return new ResponseEntries() { Entries = list };
        }
        public ResponseEntry Create(RequestCreate createDto)
        {
            return new ResponseEntry()
            {
                Id = 555,
                Executor = createDto.Executor
            };
        }
        public ResponseEntry Update(RequestUpdate updateDto)
        {
            return new ResponseEntry()
            {
                Id = updateDto.Id,
                Executor = updateDto.Executor
            };
        }

        public void Delete(int id)
        {
            
        }
    }
}
