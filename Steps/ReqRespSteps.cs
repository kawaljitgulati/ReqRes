using NUnit.Framework;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace ReqResAutomation.Steps
{
    [Binding]
    public class ReqRespSteps
    {
        private HttpClient _client;

        private string _endpoint;

        [Given(@"ReqRes endpoint is set")]
        public void GivenTheGETReqResEndpointIsSet()
        {
            _endpoint = "https://reqres.in/api/users";

        }

        [When(@"I set user id in request")]
        [When(@"Send GET HTTP request")]
        [Then(@"I receive valid HTTP response code")]
        public async Task ThenIReceiveValidHTTPResponseCode()
        {
            _client = new HttpClient();

            _endpoint = _endpoint + "/2";

            var response = await _client.GetAsync(_endpoint);

            Assert.AreEqual((int)response.StatusCode, 200);
        }

        [When(@"I set invalid user id in request")]
        [When(@"Send GET HTTP request to get details")]
        [Then(@"I receive invalid HTTP response code")]
        public async Task ThenIReceiveInValidHTTPResponseCode()
        {
            _client = new HttpClient();

            _endpoint = _endpoint + "/67";

            var response = await _client.GetAsync(_endpoint);

            Assert.AreEqual((int)response.StatusCode, 404);
        }


        [When(@"Provide new user details")]
        [When(@"Send POST HTTP request")]
        [Then(@"I receive valid POST HTTP response code")]
        public async Task WhenProvideNewUserDetails()
        {
            _client = new HttpClient();

            var requestData = "{\r\n\"name\": \"morpheus\",\r\n\"job\": \"leader\"\r\n}";

            var content = new StringContent(requestData, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync(_endpoint, content);

            Assert.AreEqual((int)response.StatusCode, 201);
        }

        [When(@"Provide new user details for PUT")]
        [When(@"Send PUT HTTP request")]
        [Then(@"I receive valid PUT HTTP response code")]
        public async Task ThenIReceiveValidPUTHTTPResponseCode()
        {
            _client = new HttpClient();

            var requestData = "{\r\n\"name\": \"morpheus\",\r\n\"job\": \"leader\"\r\n}";

            var content = new StringContent(requestData, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync(_endpoint, content);

            Assert.AreEqual((int)response.StatusCode, 200);
        }

        [When(@"Provide user id in delete endpoint")]
        [When(@"Send DELETE HTTP request")]
        [Then(@"I receive DELETE HTTP response code")]
        public async Task ThenIReceiveDELETEHTTPResponseCode()
        {
            _client = new HttpClient();

            _endpoint = _endpoint + "/12";

            var response = await _client.DeleteAsync(_endpoint);

            Assert.AreEqual((int)response.StatusCode, 204);
        }

    }
}
