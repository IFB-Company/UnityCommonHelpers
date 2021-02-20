using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace UnityHelpers.GameSettings
{
    public enum GameSettingsType
    {
        NONE = 0,
        INTEGER = 1,
        FLOAT = 2,
        STRING = 3
    }
    
    [System.Serializable]
    public class GameSettingsContainer
    {
        public string KeyName;
        public GameSettingsType SettingsType;
        public string Value;
    }

    [CreateAssetMenu(fileName = "GameSettingsHolder", menuName = "GameSettings/GameSettingsHolder")]
    public class GameSettingsHolder : ScriptableObject
    {
        private Dictionary<GameSettingsType, Dictionary<string, GameSettingsContainer>> SettingsTypesDict;
        
        [SerializeField] private GameSettingsContainer[] _settingsContainers;

        public void InitialSetup()
        {
            if (SettingsTypesDict == null)
            {
                InitDict();
            }
        }
        
        public int GetInt(string key, int defaultValue = 0)
        {
            if (SettingsTypesDict == null)
            {
                InitDict();
            }

            var settingType = GameSettingsType.INTEGER;

            var containerDict = SettingsTypesDict[settingType];
            if (!containerDict.ContainsKey(key))
            {
                Debug.LogError($"Setting with type '{settingType}' and key '{key}' is not exists!");
                return defaultValue;
            }

            if (int.TryParse(containerDict[key].Value, out var value))
            {
                return value;
            }

            return defaultValue;
        }
        

        public float GetFloat(string key, float defaultValue = 0f)
        {
            if (SettingsTypesDict == null)
            {
                InitDict();
            }

            var settingType = GameSettingsType.FLOAT;

            var containerDict = SettingsTypesDict[settingType];
            if (!containerDict.ContainsKey(key))
            {
                Debug.LogError($"Setting with type '{settingType}' and key '{key}' is not exists!");
                return defaultValue;
            }

            if (float.TryParse(containerDict[key].Value, out var value))
            {
                return value;
            }

            return defaultValue;
        }
        
        public string GetString(string key, string defaultValue = "")
        {
            if (SettingsTypesDict == null)
            {
                InitDict();
            }

            var settingType = GameSettingsType.STRING;

            var containerDict = SettingsTypesDict[settingType];
            if (!containerDict.ContainsKey(key))
            {
                Debug.LogError($"Setting with type '{settingType}' and key '{key}' is not exists!");
                return defaultValue;
            }
            

            return containerDict[key].Value;
        }

        private void InitDict()
        {
            SettingsTypesDict = new Dictionary<GameSettingsType, Dictionary<string, GameSettingsContainer>>()
            {
                {GameSettingsType.INTEGER, new Dictionary<string, GameSettingsContainer>()},
                {GameSettingsType.FLOAT, new Dictionary<string, GameSettingsContainer>()},
                {GameSettingsType.STRING, new Dictionary<string, GameSettingsContainer>()}
            };

            var intSettings = _settingsContainers.Where(c => c.SettingsType == GameSettingsType.INTEGER);
            var floatSettings = _settingsContainers.Where(c => c.SettingsType == GameSettingsType.FLOAT);
            var stringSettings = _settingsContainers.Where(c => c.SettingsType == GameSettingsType.STRING);

            SettingsTypesDict[GameSettingsType.INTEGER] = intSettings.ToDictionary(s => s.KeyName);
            SettingsTypesDict[GameSettingsType.FLOAT] = floatSettings.ToDictionary(s => s.KeyName);
            SettingsTypesDict[GameSettingsType.STRING] = stringSettings.ToDictionary(s => s.KeyName);
        }
    }
}
