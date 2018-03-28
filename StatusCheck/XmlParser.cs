using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using NUnit.Framework;

namespace StatusCheck
{
    [TestFixture]
    class XmlParser
    {
        private const string _baseUrl = "https://classic.parimatch.com/ps2/bets.xml?er=1";
        private const string _urlLive = "https://classic.parimatch.com/ps2/livebets.xml?er=1&lt=1";
        private const string _urlSoon = "https://classic.parimatch.com/ps2/livebets.xml?er=1&lt=2";
        private Api _prematch => new Api(_baseUrl);
        private Api _live => new Api(_urlLive);
        private Api _soon => new Api(_urlSoon);

        [Test]
        public void T()
        {
            var sk = GatherXmlUrls(new List<string> { "" });
            Console.WriteLine("PREMATCH SK: " + sk.Count);

            var gr = GatherXmlUrls(sk);
            Console.WriteLine("PREMATCH GR: " + gr.Count);

            var li = GatherXmlUrls(gr);
            Console.WriteLine("PREMATCH LI: " + li.Count);
        }

        [Test]
        public void D()
        {
            var live = GetItems(_live);
            Console.WriteLine("LIVE: " + live.Count());

            var soon = GetItems(_soon);
            Console.WriteLine("SOON: " + soon.Count());
        }

        #region Helpers

        public List<string> GatherXmlUrls(List<string> addToUrl)
        {
            var finalList = new List<string>();
            foreach (var addPart in addToUrl)
            {
                var content = _prematch.ExecuteRequest(addPart).Content;
                XDocument doc = XDocument.Parse(content);

                if (!doc.Root.Elements().Any())
                    throw new ArgumentNullException($"There is no items in the responsed xml.");

                var xElements = doc.Root.Elements().First().Name != "item" ?
                    doc.Root.Elements().Elements("item") :
                    doc.Root.Elements("item");

                finalList.AddRange(xElements.Select(x => x.Attribute("url").Value).ToList());
            }

            return finalList;
        }

        public IEnumerable<XElement> GetItems(Api api)
        {
            var finalList = new List<string>();
            var content = api.ExecuteRequest().Content;
            XDocument doc = XDocument.Parse(content);

            if (!doc.Root.Elements().Any())
                throw new ArgumentNullException($"There is no items in the responsed xml.");

            return doc.Descendants("item").Select(c => c);
        }

        public void GenerateResultingFile(List<string> addToUrl)
        {
            var builder = new StringBuilder();
            builder.AppendLine("Date,VW,Event,Items");

            foreach (var addPart in addToUrl)
            {
                var content = _prematch.ExecuteRequest(addPart).Content;
                XDocument doc = XDocument.Parse(content);

                var newRow = $"{doc.Root.Attribute("ldate").Value}," +
                             $"{doc.Root.Attribute("vw").Value}," +
                             //$"{doc.Root.Element("ev").Value}," +
                             $"{ConcatItemNodes(doc)}";
                builder.AppendLine(newRow);
            }

            var path = @"C:\Users\daryna.horobets\Documents\" +
                       DateTime.Now.ToString("M_d_yyyy_hhmmss") +
                       "_parsedXml.csv";
            try
            {
                using (var file = new StreamWriter(path, true, Encoding.GetEncoding(1251)))
                {
                    file.Write(builder.ToString());
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private string ConcatItemNodes(XDocument doc)
        {
            var list = doc.Root.Elements("item");
            var builder = new StringBuilder();

            foreach (var xElement in list)
            {
                builder.Append(xElement.Value);
            }

            return builder.ToString();
        }

        #endregion
    }
}
