using Azure;
using Newtonsoft.Json;
using SharedModels.Dtos.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace FarmaApp.Repository
{
    public class UsuarioRepository<T> : IRepository<T> where T : class
    {
        private readonly HttpClient _httpClient;
        private readonly string _endpoint;

        public UsuarioRepository(HttpClient httpClient, string endpoint)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _endpoint = endpoint ?? throw new ArgumentNullException(nameof(endpoint));
        }

        public async Task<IEnumerable<T>> GetAllAsync(string? queryParams = null)
        {
            try
            {
                var response = await _httpClient.GetAsync($"{_endpoint}?{queryParams}");

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<IEnumerable<T>>(content);
                }
                else
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error en la solicitud: {errorContent}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener datos: {ex.Message}");
            }
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"{_endpoint}/{id}");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(content);
            }
            else
            {
                var errorResponse = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error al obtener datos: {errorResponse}");
            }
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

                throw new Exception("Error inesperado al procesar la respuesta del servidor.");
            }

            var errorResponse = await response.Content.ReadAsStringAsync();
            throw new Exception($"Error al crear recurso: {errorResponse}");
        }
    

        public async Task<bool> UpdateAsync(int id, object dto)
        {
            var json = JsonConvert.SerializeObject(dto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync($"{_endpoint}/{id}", content);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                var errorResponse = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error al actualizar recurso: {errorResponse}");
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"{_endpoint}/{id}");

            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                var errorResponse = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error al eliminar recurso: {errorResponse}");
            }
        }
    }
}
