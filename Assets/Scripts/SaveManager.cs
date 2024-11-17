using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;

public static class SaveManager
{
    private static readonly string _saveFolder = Application.persistentDataPath + "/SaveData";

    public static void Delete(string profilename)
    {
        if (!File.Exists(_saveFolder + "/" + profilename))
        {
            Debug.LogError("Profile not found :" + profilename);
            return;
        }
        Debug.Log("Deleting file :" + profilename);
        File.Delete(_saveFolder + "/" + profilename);
    }
    public static SaveProfile<T> Load<T>(string profilename) where T : SaveProfileData
    {
        if (!File.Exists(_saveFolder + "/" + profilename))
        {
            Debug.LogError("Profile not found :" + profilename);

            return null;
        }
        var fileContents = File.ReadAllText(_saveFolder + "/" + profilename);
        Debug.Log(fileContents);
        return JsonConvert.DeserializeObject<SaveProfile<T>>(fileContents);
    }

    public static void Save<T>(SaveProfile<T> saveProfile) where T : SaveProfileData
    {
        if (File.Exists(_saveFolder + "/" + saveProfile))
        {
            throw new FileNotFoundException("Profile already exists:" + saveProfile.name);
        }

        var serializedData = JsonConvert.SerializeObject(saveProfile,
            Formatting.Indented,
            new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });

        if (!Directory.Exists(_saveFolder))
        {
            Directory.CreateDirectory(_saveFolder);
        }
        File.WriteAllText(_saveFolder + "/" + saveProfile.name, serializedData);
    }

}