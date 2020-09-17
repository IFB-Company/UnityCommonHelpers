using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Common.Singletons
{
    public class SceneSwitchingManager : GameSingletonBase<SceneSwitchingManager>
    {
        [SerializeField] private float _delayAfterLoad = 1f;
        protected override SceneSwitchingManager GetInstance() => this;
        private Coroutine _sceneSwitchingCoroutine;
        
        /// <summary>
        /// int_param = Scene index in build settings
        /// </summary>
        public event Action<string> OnSceneStartLoading;
        
        /// <summary>
        /// int_param = Scene index in build settings
        /// </summary>
        public event Action<string> OnSceneLoaded; 
        
        public void LoadSceneByName(string sceneName)
        {
            if (_sceneSwitchingCoroutine != null)
            {
                Debug.LogError("Some scene already in loading progress.");
                return;
            }

            _sceneSwitchingCoroutine = StartCoroutine(SceneSwitchingCoroutine(sceneName));
        }
        
        private IEnumerator SceneSwitchingCoroutine(string sceneName)
        {
            OnSceneStartLoading?.Invoke(sceneName);
            AsyncOperation loadingAsyncOp = SceneManager.LoadSceneAsync(sceneName);
            while (!loadingAsyncOp.isDone)
            {
                yield return null;
            }
            
            yield return new WaitForSeconds(_delayAfterLoad);
            _sceneSwitchingCoroutine = null;
            OnSceneLoaded?.Invoke(sceneName);
        }
        
    }
}
