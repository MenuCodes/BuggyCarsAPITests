using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuggyCarsAPITests.TestMethods
{
    //Test class to verify the visitor registration
    [TestClass]
    public class PostMethods
    {
        private string Regurl = "https://k51qryqov3.execute-api.ap-southeast-2.amazonaws.com/prod/users";
        private string loginUrl = "https://k51qryqov3.execute-api.ap-southeast-2.amazonaws.com/prod/oauth/token";
        [TestMethod]
        public void TestRegistration()
        {
            string json = "{\"username\":\"jackenew14g\",\"firstName\":\"dD\",\"lastName\":\"afa\",\"password\":\"Jack@1234\",\"confirmPassword\":\"Jack@1234\"}";
            IRestClient restClient = new RestClient();
            IRestRequest restRequest = new RestRequest()
            {
                Resource = Regurl
            };

            restRequest.AddHeader("Content-Type", "application/json");
            restRequest.AddJsonBody(json);
            IRestResponse restResponse = restClient.Post(restRequest);

            //Assert the status code
            Assert.AreEqual(201,(int)restResponse.StatusCode);
        }

        //Test class to verify the login funtionlity
        [TestMethod]
        public void TestLogin()
        {
            IRestClient restClient = new RestClient();
            IRestRequest restRequest = new RestRequest("grant_type=password&username=jackenew1&password=Jack@1234")
            {
                Resource = loginUrl
            };

            restRequest.AddHeader("Content-Type", "application/json");
            restRequest.AddParameter("grant_type", "password", ParameterType.GetOrPost);
            restRequest.AddParameter("username", "jackenew1", ParameterType.GetOrPost);
            restRequest.AddParameter("password", "Jack@1234", ParameterType.GetOrPost);
            IRestResponse restResponse = restClient.Post(restRequest);

            Assert.AreEqual(200, (int)restResponse.StatusCode);
        }

    }
}
