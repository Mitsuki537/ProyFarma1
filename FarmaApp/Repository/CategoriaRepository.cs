using Newtonsoft.Json;
using SharedModels.Dtos.CategoriaProducto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmaApp.Repository
{
    public class CategoriaRepository<T> : IRepository<T> where T : class
    {
        private readonly HttpClient _httpClient;
        private readonly string _endpoint;

        public CategoriaRepository(HttpClient httpClient, string endpoint)
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

                var createdEntity = JsonConvert.DeserializeObject<CategoriaProductoDto>(result);
                return createdEntity.IdCategory;
            }

            var errorResponse = await response.Content.ReadAsStringAsync();
            throw new Exception($"Error al crear recurso: {errorResponse}");
        }

        public async Task<bool> DeleteAsync(int id)
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
            throw new Exception($"Error al obtener datos: {await response.Content.ReadAsStringAsync()}");
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"{_endpoint}/{id}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(content);
            }
            throw new Exception($"Error al obtener datos: {await response.Content.ReadAsStringAsync()}");
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
