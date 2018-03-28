using System;
using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using RestSharp.Extensions;

namespace StatusCheck
{
    [TestFixture]
    [Category("ServiceVersionProd")]
    public class TestSuite
    {
        static object[] ProdData => TestData.GetData("https", "sport.betlab.com/", isConsul: false);

        [Test]
        [TestCaseSource(nameof(ProdData))]
        public void Test(string service)
        {
            var client = new RestClient(service);

            var request = new RestRequest();
            var response = client.Execute(request);
            Assert.That((int)response.StatusCode, Is.EqualTo(200), $"Unexpected status code from '{service}'");
        }

        private string GetContent(IRestResponse response)
        {
            var sb = new StringBuilder();


            return sb.ToString();
        }

        private void WriteToFile(string content)
        {
            File.WriteAllText(@"./versions.txt", content);
        }
    }
}

