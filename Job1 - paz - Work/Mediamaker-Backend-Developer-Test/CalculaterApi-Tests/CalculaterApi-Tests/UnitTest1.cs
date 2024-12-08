using System.Net;
using System.Text.Json;
using System.Text;

namespace CalculaterApi_Tests
{
    public class MyWebApiTests
    {
        private readonly HttpClient _httpClient;

        public MyWebApiTests()
        {
            // Create an instance of HttpClient to make requests to the Web API
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://localhost:7085"); // replace with your Web API URL
        }

        [Fact]
        public async Task TestAdd()
        {
            // Make a POST request to the "Add" endpoint of the Web API
            HttpResponseMessage response = await _httpClient.PostAsync("/calculator/add", new StringContent("{\"Operand1\": 5, \"Operand1\": 7}", Encoding.UTF8, "application/json"));

            // Check that the response has a 200 status code
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            // Read the response content as a string and parse it as a JsonElement
            string responseBody = await response.Content.ReadAsStringAsync();
            JsonElement responseJson = JsonSerializer.Deserialize<JsonElement>(responseBody);

            // Check that the result property of the response is correct
            Assert.Equal(12, responseJson.GetProperty("result").GetInt32());
        }

        [Fact]
        public async Task TestSubtract()
        {
            // Make a POST request to the "Subtract" endpoint of the Web API
            HttpResponseMessage response = await _httpClient.PostAsync("/calculator/subtract", new StringContent("{\"Operand1\": 10, \"Operand1\": 3}", Encoding.UTF8, "application/json"));

            // Check that the response has a 200 status code
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            // Read the response content as a string and parse it as a JsonElement
            string responseBody = await response.Content.ReadAsStringAsync();
            JsonElement responseJson = JsonSerializer.Deserialize<JsonElement>(responseBody);

            // Check that the result property of the response is correct
            Assert.Equal(7, responseJson.GetProperty("result").GetInt32());
        }

        // Add more test methods for other endpoints of your Web API
    }
}