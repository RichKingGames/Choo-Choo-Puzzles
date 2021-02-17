using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;

public class Game 
{
    public Graph Map { get; }
    public Worm[] Worms { get; }
    public Game(Graph map, Worm[] worms)
    {
        Map = map;
        Worms = worms;
    }

    private static JsonSerializerSettings Settings = new JsonSerializerSettings
    {
        TypeNameHandling = TypeNameHandling.Objects,
        Formatting = Formatting.Indented
    };

    public void Write(string jsonFile)
    {
        string jsonString = JsonConvert.SerializeObject(this, Settings);
        File.WriteAllText(jsonFile, jsonString);
    }

    public static Game Read(string jsonFile)
    {
        string jsonStringOutput = File.ReadAllText(jsonFile);
        return JsonConvert.DeserializeObject<Game>(jsonStringOutput, Settings);
    }

}
