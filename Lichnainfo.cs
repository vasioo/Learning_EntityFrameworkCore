using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
public class Rootobject
{
    [JsonProperty("name")]
    public string name { get; set; }
    public int age { get; set; }
    public string[] read { get; set; }
}