using HawksNestGolf.NET.Client.Interfaces;
using HawksNestGolf.NET.Shared.Models;
using System.Net.Http.Json;

namespace HawksNestGolf.NET.Client.Services
{
    public class BaseDataService<T> : IBaseDataService<T> where T : class
    {
        private string _url = "";
        private readonly HttpClient _httpClient;

        public BaseDataService(HttpClient httpClient, string resource)
        {
            _httpClient = httpClient;
            _url = $"api/{resource}";
        }

        public async Task<ApiResponse<IList<T>>> GetAll()
        {
            var response = await _httpClient.GetFromJsonAsync<ApiResponse<IList<T>>>(_url);
            if (response is null)
                return new ApiResponse<IList<T>> { Success = false, Data = null, Message = "Error" };

            return response;
        }

    }
}
