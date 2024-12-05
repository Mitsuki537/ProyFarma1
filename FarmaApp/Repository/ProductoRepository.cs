using Newtonsoft.Json;
using SharedModels.Dtos.Producto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmaApp.Repository
{
    public class ProductoRepository<T> : IRepository<T> where T : class
    {
        private readonly HttpClient _httpClient;
        private readonly string _endpoint;

        public ProductoRepository(HttpClient httpClient, string endpoint)
        {
            _httpClient = httpClient;
            _endpoint = endpoint;
        }

        public async Task<int> CreateAsync(object dto)
        {
            var json = JsonConvert.SerializeObject(dto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(_endpoint, content);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();

                if (int.TryParse(result, out int id))
                {
                    return id;
                }

                var createdEntity = JsonConvert.DeserializeObject<ProductoDto>(result);
                return createdEntity.IdProduct;
            }

            var errorResponse = await response.Content.ReadAsStringAsync();
            throw new Exception($"Error al crear producto: {errorResponse}");
        }

        public  async Task<bool> DeleteAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"{_endpoint}/{id}");
            return response.IsSuccessStatusCode;
        }

        public async Task<IEnumerable<T>> GetAllAsync(string? queryParams = null)
        {
            var response = await _httpClient.GetAsync($"{_endpoint}?{queryParams}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IEnumerable<T>>(content);
            }

            throw new Exception($"Error al obtener productos: {await response.Content.ReadAsStringAsync()}");
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"{_endpoint}/{id}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(content);
            }

            throw new Exception($"Error al obtener producto: {await response.Content.ReadAsStringAsync()}");
        }

        public async Task<bool> UpdateAsync(int id, object dto)
        {
            var json = JsonConvert.SerializeObject(dto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"{_endpoint}/{id}", content);

            return response.IsSuccessStatusCode;
        }
    }
}
