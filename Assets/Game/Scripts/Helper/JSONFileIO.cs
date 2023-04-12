using System;
using System.IO;
using UnityEngine;

namespace Game.Scripts.Helper
{
    public static class JSONFileIO
    {
        public static T ReadJSONFile<T>(string fileName)
        {
            T result = default;

            try
            {
                TextAsset jsonFile = Resources.Load<TextAsset>(fileName);
                result = JsonUtility.FromJson<T>(jsonFile.text);
            }
            catch (Exception e)
            {
                Logger.Log(LogMessage.Error, $"Failed to load/pars {fileName}: {e.Message}");
                return result;
            }

            if (result == null)
            {
                Logger.Log(LogMessage.Error, $"Failed to deserialize game data");
            }

            return result;
        }

        public static void WriteJSONFile<T>(string filePath, T data)
        {
            string json = JsonUtility.ToJson(data, true);
            string fullPath = $"{Application.dataPath}/Resources/{filePath}";
            File.WriteAllText(fullPath, json);
        }
    }
}