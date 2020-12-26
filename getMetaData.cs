using NUnit.Framework;
using System;
using RestSharp;

namespace webApi_lab
{
    [TestFixture()]
    public class WebApi
    {


        [Test()]
        public void GetMetaData()
        {
            string filename = @"/Users/evgenij/Downloads/1.jpg";
            String token = "IYDwfr3oWiAAAAAAAAAAAZwfvOEPuUT-k0VcLd1aigsgD56kXj-IQHN-3NMNdNHM";
            RestClient restClient = new RestClient("https://api.dropboxapi.com/2/files/get_metadata");

            byte[] image = System.IO.File.ReadAllBytes(filename);

            RestRequest restRequest = new RestRequest(Method.POST);
            restRequest.RequestFormat = DataFormat.Json;

            restRequest.AddHeader("Authorization", "Bearer " + token);
            restRequest.AddHeader("Content-Type", "application/json");
            restRequest.AddJsonBody("{\"path\":\"/test/4k_image.jpg\"}");

            var response = restClient.Execute(restRequest);
            Assert.IsTrue(response.Content != null);
        }

    }

}
