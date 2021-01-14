using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Common
{
    public class TransformFollower : MonoBehaviour
    {
        [SerializeField] private Vector3 _offset;
        
        [SerializeField] private Transform _followTransform;

        public Transform FollowTransform
        {
            get { return _followTransform; }
            set { this._followTransform = value; }
        }
        
        [SerializeField] private float _moveSpeed = 6f;
        [SerializeField] private float _rotSpeed = 6f;

        public void SetFollowTransform(Transform target)
        {
            _followTransform = target;
        }
        
        private void Update()
        {
            if (_followTransform == null)
                return;

            var posToFollow = _followTransform.position + _offset;
            
            transform.position =
                Vector3.Lerp(transform.position, posToFollow, _moveSpeed * Time.deltaTime);
            transform.rotation =
                Quaternion.Lerp(transform.rotation, _followTransform.rotation, _rotSpeed * Time.deltaTime);
        }
    }
}
