﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmaApp.Repository
{
    public class OrdenCompraRepository<T> : IRepository<T> where T : class
    {
        private readonly HttpClient _httpClient;
        private readonly string _endpoint;

        public OrdenCompraRepository(HttpClient httpClient, string endpoint)
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
                throw new Exception("No se pudo interpretar el ID de la respuesta.");
            }

            throw new Exception($"Error al crear el registro: {await response.Content.ReadAsStringAsync()}");
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"{_endpoint}/{id}");
            if (response.IsSuccessStatusCode)
                return true;

            throw new Exception($"Error al eliminar el registro: {await response.Content.ReadAsStringAsync()}");
        }

        public async Task<IEnumerable<T>> GetAllAsync(string? queryParams = null)
        {
            var response = await _httpClient.GetAsync($"{_endpoint}?{queryParams}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IEnumerable<T>>(content);
            }
            throw new Exception($"Error al obtener registros: {await response.Content.ReadAsStringAsync()}");
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"{_endpoint}/{id}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(content);
            }
            throw new Exception($"Error al obtener el registro: {await response.Content.ReadAsStringAsync()}");
        }

        public async Task<bool> UpdateAsync(int id, object dto)
        {
            var json = JsonConvert.SerializeObject(dto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"{_endpoint}/{id}", content);

            if (response.IsSuccessStatusCode)
                return true;

            throw new Exception($"Error al actualizar el registro: {await response.Content.ReadAsStringAsync()}");
        }
    }
}
