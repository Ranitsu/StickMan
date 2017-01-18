using UnityEngine;
using System.Collections;
using System.IO;
using Entities;


public class FileIO : MonoBehaviour
{

    public void SaveMap(string fileName, Level levelData)
    {
        //TUTAJ TRZEBA TO ROZKMINAC
        var levelDataBytes = JsonUtility.ToJson(levelData);


        if (!Directory.Exists(Application.persistentDataPath + "/CustomLevels/"))
            Directory.CreateDirectory(Application.persistentDataPath + "/CustomLevels/");

        var filePath = Application.persistentDataPath + "/CustomLevels/" + fileName + ".lvl";

        using (var fs = new FileStream(filePath, FileMode.Create, FileAccess.Write))
        {
            using (var bw = new BinaryWriter(fs))
            {
                bw.Write(levelDataBytes);
                bw.Flush();
            }
        }

    }

    public Level LoadMap(string fileName)
    {
        Level loadedLevel = null;

        var filePath = Application.persistentDataPath + "/CustomLevels/" + fileName + ".lvl";

        using (var fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
        {
            //TUTAJ TRZEBA TO ROZKMINAC

            loadedLevel = JsonUtility.FromJson<Level>(fs.ToString());  //JsonUtility.FromJson<Level>(fs);

        }

        Debug.Log(loadedLevel.LevelName);
        Debug.Log(loadedLevel.LevelDescription);
        Debug.Log(loadedLevel.Author);
        Debug.Log(loadedLevel.LevelParts.Count);

        return loadedLevel;
    }
}
