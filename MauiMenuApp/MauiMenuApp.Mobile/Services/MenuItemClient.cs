using MauiMenuApp.Domain.Common;
using MauiMenuApp.Domain.DTOs;
using MauiMenuApp.Domain.Models;
using MauiMenuApp.Mobile.Services.Interfaces;
using System.Net;
using System.Text.Json;
using MauiMenuApp.Domain.Mappings;


namespace MauiMenuApp.Mobile.Services
{
    public class MenuItemClient : IMenuItemClient
    {
        private readonly HttpClient _httpClient;

        public MenuItemClient(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task<Result<List<MenuItemModel>>> GetMainMenuItems()
        {
            Result<List<MenuItemModel>>? result = new Result<List<MenuItemModel>>();
            
            HttpResponseMessage? response = await _httpClient.GetAsync("api/Addresses");
            response.EnsureSuccessStatusCode();

            if (response != null)
            {
                string content = await response.Content.ReadAsStringAsync();
                Result<MainMenuDto> responseDto = JsonSerializer.Deserialize<Result<MainMenuDto>>(content, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }) ?? new();
                
                
                if(responseDto.Success)
                {
                    result.StatusCode = responseDto.StatusCode;
                    result.Value = responseDto.Value?.MenuItems.ToModels() ?? new();
                }
                else 
                { 
                    result.StatusCode = responseDto.StatusCode;
                    result.Errors = responseDto.Errors;
                }
            }
            else
            {
                result.StatusCode = HttpStatusCode.InternalServerError;
                result.Errors.Add(new Error("NoServerResponse", "No response from server." ));
            }


            return result;
        }

        public Task<Result<SubMenuModel>> GetSubMenuItems()
        {
            throw new NotImplementedException();
        }
    }
}
