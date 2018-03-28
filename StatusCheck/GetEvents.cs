using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;

namespace StatusCheck
{
    [TestFixture]
    [Category("GetEvents")]
    public class GetEvents
    {
        private List<Event> EventsList = new List<Event>();

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            var service = "https://sport3.betlab.com/spout-prematch/api/events";
            var client = new RestClient(service);

            var request = new RestRequest();
            var response = client.Execute(request);
            EventsList.AddRange(DeseriaizeEvents(response)); // events count
            WriteEvents();
        }

        [Test]
        public void Test()
        {
            
        }

        private List<Event> DeseriaizeEvents(IRestResponse response)
        {
            return JsonConvert.DeserializeObject<List<Event>>(response.Content);
        }

        private void WriteEvents()
        {
            var builder = new StringBuilder();
            builder.AppendLine("ExternalId,BetlabEventKey,Url," +
                               "NameLng1,NameText1,NameLng2,NameText2," +
                               "GroupCommentLng1,GroupCommentText1,GroupCommentLng2,GroupCommentText2");
            foreach (var evnt in EventsList)
            {
                var nameLng1 = evnt.Name.Length > 0 ? evnt.Name[0].Lang : string.Empty;
                var nameTxt1 = evnt.Name.Length > 0 ? evnt.Name[0].Text : string.Empty;
                var nameLng2 = evnt.Name.Length > 1 ? evnt.Name[1].Lang : string.Empty;
                var nameTxt2 = evnt.Name.Length > 1 ? evnt.Name[1].Text : string.Empty;

                var groupCommentLng1 = evnt.GroupComment.Length > 0 ? evnt.GroupComment[0].Lang : string.Empty;
                var groupCommentTxt1 = evnt.GroupComment.Length > 0 ? evnt.GroupComment[0].Text : string.Empty;
                var groupCommentLng2 = evnt.GroupComment.Length > 1 ? evnt.GroupComment[1].Lang : string.Empty;
                var groupCommentTxt2 = evnt.GroupComment.Length > 1 ? evnt.GroupComment[1].Text : string.Empty;

                builder.AppendLine($"{evnt.ExternalId},{evnt.BetlabEventKey},{evnt.Url}" +
                                   $"{nameLng1},\"{nameTxt1}\",{nameLng2},\"{nameTxt2}\"," +
                                   $"{groupCommentLng1},\"{groupCommentTxt1}\",{groupCommentLng2},\"{groupCommentTxt2}\"");
            }
            File.WriteAllText(System.AppDomain.CurrentDomain.BaseDirectory + 
                              @"/" + DateTime.Now.ToString("MMddyy_hhmmss") + 
                              "_allEvents.csv", builder.ToString());
        }
    }
}