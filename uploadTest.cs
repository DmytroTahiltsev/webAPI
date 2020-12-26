using NUnit.Framework;
using System;
using RestSharp;

namespace webApi_lab
{
    [TestFixture()]
    public class WebApi
    {
        [Test()]
        public void Upload()
        {
            string filename = @"/Users/evgenij/Downloads/1.jpg";
            String token = "IYDwfr3oWiAAAAAAAAAAAZwfvOEPuUT-k0VcLd1aigsgD56kXj-IQHN-3NMNdNHM";
            RestClient restClient = new RestClient("https://content.dropboxapi.com/2/files/upload");

            byte[] image = System.IO.File.ReadAllBytes(filename);

            RestRequest restRequest = new RestRequest(Method.POST);
            restRequest.RequestFormat = DataFormat.Json;

            restRequest.AddHeader("Authorization", "Bearer " + token);
            restRequest.AddHeader("Dropbox-API-Arg", "{\"path\":\"/test/4k_image.jpg\"}");
            restRequest.AddParameter("application/octet-stream", image, "application/octet-stream", ParameterType.RequestBody);
            restRequest.AddHeader("Content-Type", "application/octet-stream");

            var response = restClient.Execute(restRequest);

            Assert.IsTrue(response.Content != null);
        }


    }

}