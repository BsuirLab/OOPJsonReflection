using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Lab3OOP
{
    public class JsonConverter
    {
        public string SerializeListIntoString(List<Mammals> mammalList)
        {
             string jsonString = JsonConvert.SerializeObject(mammalList, Formatting.Indented, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All
            });
            return jsonString;
        }
        public List<Mammals> DeserializeStringIntoList(string jsonString)
        {
            List<Mammals> DeserializedList = (List<Mammals>)JsonConvert.DeserializeObject(jsonString, new JsonSerializerSettings 
            {
                TypeNameHandling = TypeNameHandling.All
            });
            return DeserializedList;
        }

        public bool WriteJsonToFile(string path,string jsonString)
        {
            File.WriteAllText(path, jsonString);
            return true;
        }
        public string ReadJsonFromFile(string path)
        {
            return File.ReadAllText(path);
        }

    }
}
