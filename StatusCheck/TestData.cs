using System;
using System.Linq;

namespace StatusCheck
{
    public static class TestData
    {
        private static string GetService(string protocol, string env, string serviceName, bool isConsul)
        => $"{protocol}://{env}{serviceName}{(isConsul ? ".betlab.consul/status" : "/status")}";

        public static object[] GetData(string protocol, string env, bool isConsul)
        {
            int length = typeof(Services).GetEnumValues().Length;
            object[] obj = new object[length];
            var serviceEnums = Enum.GetValues(typeof(Services)).Cast<Services>();
            var serviceVales = serviceEnums.Select(x => x.GetDescription()).ToArray();

            for (var i = 0; i < length; i++) {
                obj[i] = new object[] { GetService(protocol, env,  serviceVales[i], isConsul) };
            }
            return obj;
        }
    }
}