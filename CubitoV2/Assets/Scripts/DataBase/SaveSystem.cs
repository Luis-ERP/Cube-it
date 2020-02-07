using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveSystem
{
    public static void SaveUser(Main player, MainAchievements achievs)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string[] paths = { Application.persistentDataPath, "data.d" };
        string path = Path.Combine(paths);
        FileStream stream = new FileStream(path, FileMode.Create);
        UserData data = new UserData(player, achievs);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static UserData LoadData()
    {
        string[] paths = { Application.persistentDataPath, "data.d" };
        string path = Path.Combine(paths);
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            UserData data = formatter.Deserialize(stream) as UserData;
            stream.Close();

            return data;
        }
        else
        {
            return null;
        }
    }
}
