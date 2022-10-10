using UnityEngine;
using System.IO;

public class SaveManager : MonoBehaviour
{
    public static string directory = "/SaveData/";
    public static string fileName = "Save.txt";
    
    public static void Save(Status savedPreferences)
    {
        string dir = Application.persistentDataPath + directory;

        if(!Directory.Exists(dir))
        {
            Directory.CreateDirectory(dir);
        }

        string json = JsonUtility.ToJson(savedPreferences);
        File.WriteAllText(dir + fileName, json);
    }

    public static Status Load()
    {
        string fullPath = Application.persistentDataPath + directory + fileName;
        Status savedPreferences = new Status();

        if(File.Exists(fullPath))
        {
            string json = File.ReadAllText(fullPath);
            savedPreferences = JsonUtility.FromJson<Status>(json);
            Debug.Log(savedPreferences);
        }
        else
        {
            Debug.Log("There's no save!");
        }

        return savedPreferences;
    }
}
