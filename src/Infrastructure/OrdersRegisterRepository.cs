using Application.DTOs.Requests;
using Application.DTOs.Responses;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.CodeDom.Compiler;
using Application.Interfaces;

namespace Infrastructure
{
    public class OrdersRegisterRepository : IOrdersRegisterRepository
    {
        private readonly IDbConnection _connection;

        public OrdersRegisterRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<ResponseEntry> GetById(int id)
        {
            string query = @"
                SELECT contractingWorks, executor, businessClient, countingMethod, vipClient
                FROM ordersRegistry
                WHERE id = @id";
            ResponseEntry result = await _connection.QueryFirstOrDefaultAsync<ResponseEntry>(
                query, new { id });
            return result;
        }
        public async Task<List<ResponseEntry>> GetAll()
        {
            string query = @"
                SELECT contractingWorks, executor, businessClient, countingMethod, vipClient
                FROM ordersRegistry";
            var result = await _connection.QueryAsync<ResponseEntry>(query);

            return result.ToList();
        }
        public async Task<ResponseEntry> Create(RequestCreate createDto)
        {
            string query = @"INSERT INTO ordersRegistry
                (contractingWorks, executor, businessClient, countingMethod, vipClient)
                VALUES (@contractingWorks, @executor, @businessClient, @countingMethod, @vipClient)
                RETURNING id contractingWorks, executor, businessClient, countingMethod, vipClient";
            var parameters = new
            {
                contractingWorks = createDto.ContractingWorks,
                executor = createDto.Executor,
                businessClient = createDto.BusinessClient,
                countingMethod = createDto.CountingMethod,
                vipClient = createDto.VipClient
            };
            var result = await _connection.QueryFirstOrDefaultAsync<ResponseEntry>(query, parameters);

            return result;
        }
        public async Task<ResponseEntry> Update(RequestUpdate updateDto)
        {
            string query = @"UPDATE ordersRegistry
                    SET contractingWorks = @contractingWorks,
                        executor = @executor,
                        businessClient = @businessClient,
                        countingMethod = @countingMethod,
                        vipClient = @vipClient
                        updatedAt = @updatedAt)
                    WHERE id = @id
                    RETURNING
                    id contractingWorks, executor, businessClient, countingMethod, vipClient;";

            var parameters = new
            {
                id = updateDto.Id,
                contractingWorks = updateDto.ContractingWorks,
                executor = updateDto.Executor,
                businessClient = updateDto.BusinessClient,
                countingMethod = updateDto.CountingMethod,
                vipClient = updateDto.VipClient,
                updatedAt = DateTime.Now,
            };
            var result = await _connection.QueryFirstOrDefaultAsync<ResponseEntry>(query, parameters);

            return result;
        }

        public async Task<int> Delete(int id)
        {
            string sql = "DELETE FROM ordersRegistry WHERE id=@id;";
            var parameters = new
            {
                id = id,
            };
           return await _connection.ExecuteAsync(sql, parameters);
        }
    }
}
