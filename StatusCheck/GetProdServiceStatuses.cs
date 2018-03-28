using NUnit.Framework;
using RestSharp;

namespace StatusCheck
{
    [TestFixture]
    [Category("GetProdServiceStatuses")]
    public class GetProdServiceStatuses
    {
        static object[] ProdData => TestData.GetData("https", "sport.betlab.com/", isConsul: false);
        static object[] StageData => TestData.GetData("https", "sport3.betlab.com/", isConsul: false);
        static object[] UatData => TestData.GetData("http", "uat-", isConsul: true);
        static object[] DbeData => TestData.GetData("http", "dbe-", isConsul: true);

        [Test]
        [TestCaseSource(nameof(ProdData))]
        //[TestCaseSource(nameof(StageData))]
        //[TestCaseSource(nameof(UatData))]
        //[TestCaseSource(nameof(DbeData))]
        public void Test(string service)
        {
            var client = new RestClient(service);

            var request = new RestRequest();
            var response = client.Execute(request);
            Assert.That((int)response.StatusCode, Is.EqualTo(200), $"Unexpected status code from '{service}'");
        }

       
    }
}