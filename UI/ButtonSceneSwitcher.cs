using Common.Singletons;
using UnityEngine;
using UnityEngine.UI;

namespace Common.UI
{
    [RequireComponent(typeof(Button))]
    public class ButtonSceneSwitcher : MonoBehaviour
    {
        [SerializeField] private string _sceneName;
        private void Awake()
        {
            if (string.IsNullOrEmpty(_sceneName))
            {
                Debug.LogError($"SceneName is missing!");
                return;
            }
            var btn = this.GetComponent<Button>();
            if (btn != null)
            {
                btn.onClick.AddListener(OnClick);
            }
            else
            {
                Debug.LogError("Button is missing!");
            }
        }

        private void OnClick()
        {
            if (SceneSwitchingManager.Instance == null)
            {
                Debug.LogError($"{nameof(SceneSwitchingManager)} is missing!");
                return;
            }
            
            SceneSwitchingManager.Instance.LoadSceneByName(_sceneName);
        }
    }
}

