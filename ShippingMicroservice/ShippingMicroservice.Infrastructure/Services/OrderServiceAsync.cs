using ShippingMicroservice.ApplicationCore.Contracts.Service;
using System.Text;
using System.Text.Json;

namespace ShippingMicroservice.Infrastructure.Services
{
    public class OrderServiceAsync : IOrderServiceAsync
    {
        private const string ORDERMICROSERVICE_URL = "http://host.docker.internal:5016/api/Order";
        public async Task<bool> UpdateOrderStatusAsync(int orderId, string status)
        {
            var url = $"{ORDERMICROSERVICE_URL}/UpdateOrderStatus/{orderId}";

            var content = new StringContent(JsonSerializer.Serialize(status), Encoding.UTF8, "application/json");
            using var client = new HttpClient();
            try
            {
                var response = await client.PutAsync(url, content);
                return response.IsSuccessStatusCode;
            }
            catch (Exception e)
            {
                // Log the exception if necessary
                Console.WriteLine("Exception: " + e.Message);
                return false;
            }
        }
    }
}
