using System;
using Injection;
using UnityEngine;

namespace UnityCommonHelpers._Demo._InjectorDemo
{
    /// <summary>
    /// This class is responsibility for setup any dependency for each 
    /// </summary>
    public class SceneContextDemo : MonoBehaviour
    {
        [SerializeField] private CubeRotatorData _cubeRotatorData;
        [SerializeField] private CubeRotator _cubeRotator;
        
        private Injector _injector;
        private void Awake()
        {
            _injector = new Injector();
            _injector.Bind(new Calculator());
            _injector.Bind(_cubeRotatorData);
            
            
            _injector.Bind(_cubeRotator);
            
            _injector.PostBindings();
            //_injector.Bind();
        }
    }
}
