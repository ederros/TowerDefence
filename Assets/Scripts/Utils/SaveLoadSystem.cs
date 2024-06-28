using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using System.Security.Cryptography;
using System.Text;
using System;


public class SaveLoadSystem : MonoBehaviour
{

    private readonly string Key = "1234567890";
   
    

    public string EnDecrypt(string text)
    {
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < text.Length; i++)
        {
            //Debug.Log(text[i]+" to " + (char)(text[i] ^ Key[i % Key.Length]));
            sb.Append((char)(text[i] ^ Key[i % Key.Length]));
        }
        return sb.ToString();
    }

    [SerializeField] private string fileName;
    private List<ISaveLoadable> saveLoadables;
    private string fullPath;
    public static SaveLoadSystem instance;

    [System.Serializable]
    private class SerializableList<T>
    {
        public List<T> list;
    }
    
    private void Awake() 
    {
        
        instance = this;
        fullPath = GetPath();
        if(!Directory.Exists(Application.persistentDataPath + Path.DirectorySeparatorChar + "Saves"))
            Directory.CreateDirectory(Application.persistentDataPath + Path.DirectorySeparatorChar + "Saves");
            
        Debug.Log(fullPath);
        IEnumerable<ISaveLoadable> enumerable = FindObjectsOfType<MonoBehaviour>(true).OfType<ISaveLoadable>();
        saveLoadables = new List<ISaveLoadable>(enumerable);
        if(!TryLoad())
        {
            Debug.LogError("Error at load");
        }
        Save();
    }

    private string GetPath() => Application.persistentDataPath + Path.DirectorySeparatorChar + "Saves" + Path.DirectorySeparatorChar + fileName;
    public void Save()
    {
        SerializableList<string> objs = new SerializableList<string>();
        objs.list = new List<string>();
        if(saveLoadables == null) return;
        foreach (var item in saveLoadables)
        {
            object obj;
            item.Save(out obj);
            objs.list.Add(JsonUtility.ToJson(obj));
        }
        if(File.Exists(fullPath))
        {
            File.Delete(fullPath);
        }
        using(FileStream fs = File.OpenWrite(fullPath))
        {
            using(StreamWriter sr = new StreamWriter(fs))
            {
                sr.Write(EnDecrypt(JsonUtility.ToJson(objs)));
            }
        }
    }
    
    public bool TryLoad()
    {
        if(!File.Exists(fullPath))
        {
            return false;
        } 
        //try{
        using(FileStream fs = File.OpenRead(fullPath))
        {
            using(StreamReader sr = new StreamReader(fs))
            {
                //Debug.Log(EnDecrypt(sr.ReadToEnd()));
                //Debug.Log(sr.ReadToEnd());
                SerializableList<string> list;
                string data = sr.ReadToEnd();
                
                Debug.Log(data + " = " + EnDecrypt(data));
                try{
                    list = JsonUtility.FromJson<SerializableList<string>>(EnDecrypt(data));
                }
                catch{
                    return false;
                }
                Debug.Log(list);
                int ind = 0;
                if(list.list.Count != saveLoadables.Count) return false;
                foreach (var item in saveLoadables)
                {
                    object obj = JsonUtility.FromJson(list.list[ind], item.GetSavedDataType());
                    if(obj == null) return false;
                    item.Load(obj);
                    ind++;
                }
            }
        }
        return true;
        //}catch{
        //    return false;
        //}
    }

    private void OnApplicationPause(bool pauseStatus) 
    {
        Save();
    }

    private void OnApplicationQuit() 
    {
        Save();
    }

    private void OnDestroy() 
    {
        Save();
    }
}


