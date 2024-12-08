using System.Net;
using System.Text.Json;
using System.Text;
using System.Net.Http.Headers;

namespace Calculater_Tests
{
    public class CalculatorApiTests
    {
        private readonly HttpClient _httpClient;

        public CalculatorApiTests()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://localhost:7085"); 
        }

        [Fact]
        public async Task TestAdd()
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "token");

            HttpResponseMessage response = await _httpClient.PostAsync("/calculator/add", new StringContent("{\"Operand1\": 5, \"Operand2\": 7}", Encoding.UTF8, "application/json"));

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

           
            string responseBody = await response.Content.ReadAsStringAsync();
            int result = JsonSerializer.Deserialize<int>(responseBody);

           
            Assert.Equal(12, result);
        }

        [Fact]
        public async Task TestSubtract()
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "token");
            HttpResponseMessage response = await _httpClient.PostAsync("/calculator/subtract", new StringContent("{\"Operand1\": 10, \"Operand2\": 3}", Encoding.UTF8, "application/json"));

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            string responseBody = await response.Content.ReadAsStringAsync();
            int result = JsonSerializer.Deserialize<int>(responseBody);

            Assert.Equal(7, result);
        }

        [Fact]
        public async Task TestMultiply()
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "token");
            HttpResponseMessage response = await _httpClient.PostAsync("/calculator/multiply", new StringContent("{\"Operand1\": 10, \"Operand2\": 3}", Encoding.UTF8, "application/json"));

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            string responseBody = await response.Content.ReadAsStringAsync();
            int result = JsonSerializer.Deserialize<int>(responseBody);

            Assert.Equal(30, result);
        }

        [Fact]
        public async Task TestDivide()
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "token");
            HttpResponseMessage response = await _httpClient.PostAsync("/calculator/divide", new StringContent("{\"Operand1\": 10, \"Operand2\": 2}", Encoding.UTF8, "application/json"));

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            string responseBody = await response.Content.ReadAsStringAsync();
            int result = JsonSerializer.Deserialize<int>(responseBody);

            Assert.Equal(5, result);
        }
    }
}