namespace DbIntegrationTestsDemo
{
    public class IntegrationWebApiTests
    {
        private readonly string _url = "http://webapp-showcase:8080/WeatherForecast/";

        [Fact]
        public async Task GetReturnsProductWithSameId()
        {
            using var httpClient = new HttpClient();

            var response = await httpClient.GetAsync(_url);

            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();

            Assert.Equal("Sunny", result);
        }
    }
}
