using UnityEditor;
using UnityEngine;
using System.IO;
using Assets.Scripts.Entities.Enums;

namespace Assets.Scripts.Services
{
    [System.Serializable]
    public class CombatData
    {
        public int EnemyID;

        public void SaveData(string dataFile)
        {
            string path = Application.dataPath + $"/Data/{dataFile}.json";

            string combatData = JsonUtility.ToJson(this);

            File.WriteAllText(path, combatData);
        }

        public void LoadData(string dataFile)
        {
            string path = Application.dataPath + $"/Data/{dataFile}.json";
            if (File.Exists(path))
            {
                string jsonFile = File.ReadAllText(path);

                CombatData data = JsonUtility.FromJson<CombatData>(jsonFile);

                EnemyID = data.EnemyID;
            }
        }
    }
}