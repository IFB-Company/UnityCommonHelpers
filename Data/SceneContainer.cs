using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Common.Data
{
    [CreateAssetMenu(fileName = "SceneContainer", menuName = "CommonData/SceneContainer")]
    public class SceneContainer : ScriptableObject
    {
#if UNITY_EDITOR
        [SerializeField] private SceneAsset _sceneAsset;

        private void OnValidate()
        {
            _sceneName = _sceneAsset != null ? _sceneAsset.name : "UNKNOWN";
        }
#endif
        [SerializeField] private string _sceneName;
        public string SceneName => _sceneName;
    }
}