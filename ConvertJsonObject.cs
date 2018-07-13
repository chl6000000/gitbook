namespace ConsoleApp
{
    public class Program
    {

  #region read json and convert to objects
        /// <summary>
        /// response2.text
        /// 
        //////////////////////      {
        //////////////////////          "Guid": "0bd86b080ef34s95bf77b9481e2e70",
        //////////////////////          "ContainsHealthChecks": "true",
        //////////////////////          "HealthCheckResponses":           [
        //////////////////////                                        {
        //////////////////////                              "Id": "ASHC",
        //////////////////////                              "Description": "APS  Check",
        //////////////////////                              "Completed": "true"
        //////////////////////                    },
        //////////////////////                                        {
        //////////////////////                              "Id": "SHC",
        //////////////////////                              "Description": "APS CHECK 1",
        //////////////////////                              "Completed": "false"
        //////////////////////                    }
        //////////////////////          ]
        //////////////////////      }
        /// 
        /// </summary>
        public static void readJsonAndConvertToObject()
        {
            string jsonText = File.ReadAllText(@"S:\response1.txt");
            var obj = FromJson<GatewayHealthCheckResponse>(jsonText);
            Console.WriteLine(obj.Guid);
        }
        public static T FromJson<T>(string jsonText)
        {
            return JsonConvert.DeserializeObject<T>(jsonText, new JsonConverter[1] { new IsoDateTimeConverter() });
        }
        public class GatewayHealthCheckResponse
        {
            public string Guid { get; set; }
            public bool ContainsHealthChecks { get; set; }
            public List<HealthCheckResponse> HealthCheckResponses { get; set; }
        }
        public class HealthCheckResponse
        {
            public string Id { get; set; }
            public string Description { get; set; }
            public bool Completed { get; set; }
        }
        #endregion
    }
}