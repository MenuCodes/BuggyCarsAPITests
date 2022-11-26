using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using RestSharp.Serializers;
using RestSharp;
using System.Collections.Generic;
using System.Text.Json;
using System.Net;
using Newtonsoft.Json;
using JsonSerializer = Newtonsoft.Json.JsonSerializer;
using RestSharp.Authenticators;

namespace BuggyCarsAPITests
{
    //Test class to verify the Dashboard data retrieval
    [TestClass]
    public class GetAPITests
    {
        private string getUrl = "https://k51qryqov3.execute-api.ap-southeast-2.amazonaws.com/prod/dashboard";
        
        [TestMethod]
        public void TestGetDashboard()
        {
            var restClient = new RestClient();
            var restRequest = new RestRequest(getUrl);
            var restResponse = restClient.Execute(restRequest);

            if (restResponse.IsSuccessful)
            {
                //Assert the status code
                Assert.AreEqual("OK",restResponse.StatusCode.ToString());
                //Assert the content of the reponse
                Assert.IsTrue(restResponse.Content.Contains("make"));
            }
        }


    }


}
