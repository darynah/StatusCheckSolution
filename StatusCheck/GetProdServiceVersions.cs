using System;
using System.IO;
using System.Text;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;

namespace StatusCheck
{
    [TestFixture]
    [Category("GetProdServiceVersions")]
    public class GetProdServiceVersions
    {
        static object[] ProdData => TestData.GetData("https", "sport.betlab.com/", isConsul: false);
        private static readonly StringBuilder Content = new StringBuilder();

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            WriteContent();
        }

        [Test]
        [TestCaseSource(nameof(ProdData))]
        public void Test(string service)
        {
            var client = new RestClient(service);

            var request = new RestRequest();
            var response = client.Execute(request);
            GetContent(response);
        }

        private void GetContent(IRestResponse response)
        {
            var results = JObject.Parse(response.Content);
            Content.AppendLine("Response Uri: " + response.ResponseUri);
            if ((string)results["name"] != null)
                Content.AppendLine("Name: " + (string)results["name"]);

            if ((string)results["port"] != null)
                Content.AppendLine("Port: " + (string)results["port"]);

            if ((string)results["id"] != null)
                Content.AppendLine("Id: " + (string)results["id"]);

            if ((string)results["environment"] != null)
                Content.AppendLine("Environment: " + (string)results["environment"]);

            if (results["version"] != null)
            {
                foreach (var result in results["version"])
                    Content.AppendLine(result.ToString().Replace('"', ' ').Trim());
            }

            Content.AppendLine(string.Empty);
        }

        private void WriteContent()
        {
            File.WriteAllText(System.AppDomain.CurrentDomain.BaseDirectory + @"/"+ DateTime.Now.ToString("MMddyy_hhmmss") + "_prodVersions.txt", Content.ToString());
        }
    }
}