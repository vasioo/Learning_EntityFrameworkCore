using Newtonsoft.Json;
using System;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
namespace JSON
{
    class Program
    {
        static void Main(string[] args)
        {
            string json = File.ReadAllText(@"D:\JSON\JSON\test.json");
            var template = new
            {
                name =string.Empty,
                age=0
            };
            var obj = JsonConvert.DeserializeObject(json);
            //var obj = JsonSerializer.Deserialize<Rootobject>(json);
            File.WriteAllText(@"D:\JSON\JSON\test.json", JsonConvert.SerializeObject(obj));
        }
    }
}
