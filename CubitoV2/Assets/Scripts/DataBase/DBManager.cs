using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DBManager : MonoBehaviour
{
    DataJson data;
    public string fileName = "data.json";

    private void Start()
    {
        try
        {
            Load();
        }
        catch
        {
            Save();
        }
    }

    public void Save()
    {
        string json = JsonUtility.ToJson(data);
        WriteToFile(fileName, json);
    }

    public DataJson Load()
    {
        data = new DataJson();
        string json = ReadFromFile(fileName);
        JsonUtility.FromJsonOverwrite(json, data);
        return data;
    }

    private void WriteToFile(string fileName, string json)
    {
        string path = GetFilePath(fileName);
        FileStream fileStream = new FileStream(path, FileMode.Create);

        using(StreamWriter writer = new StreamWriter(fileStream))
        {
            writer.Write(json);
        }
    }

    private string ReadFromFile(string fileName)
    {
        string path = GetFilePath(fileName);
        if (File.Exists(path))
        {
            using (StreamReader reader = new StreamReader(path))
            {
                string json = reader.ReadToEnd();
                return json;
            }
        }
        else
        {
            Debug.LogWarning("DB not found");
        }
        return "";
    }

    private string GetFilePath(string fileName)
    {
        return Application.persistentDataPath + "/" + fileName;
    }
}
