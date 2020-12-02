using System;
using UnityEngine;

namespace Common.ServiceLocator
{
    public class ServiceHub : MonoBehaviour
    {
        [SerializeField] private GameObject[] _servicePrefabs;
        public event Action<IGameService> OnGameServiceCreated;

        public event Action OnServicesLoaded;

        private void Start()
        {
            InitStandartServices();
            InitMonoBehaviorServices();
            
            DontDestroyOnLoad(this.gameObject);
            
            OnServicesLoaded?.Invoke();
        }

        /// <summary>
        /// Default services not inherited  by MonoBehaviour 
        /// </summary>
        private void InitStandartServices()
        {
            
        }

        private void InitMonoBehaviorServices()
        {
            for (int i = 0; i < _servicePrefabs.Length; i++)
            {
                var prefab = _servicePrefabs[i];
                if (prefab == null)
                {
                    Debug.LogError("Some service prefab is missing!");
                }
                else
                {
                    var instance = Instantiate(prefab, transform);
                    var serviceComponent = instance.GetComponent<IGameService>();
                    OnGameServiceCreated?.Invoke(serviceComponent);
                }
            }
        }
    }  
}

