using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HadiansyahAL.Manager;

namespace HadiansyahAL.PlayerControl
{   
    public class PlayerController : MonoBehaviour
    {   
        [SerializeField] private float AnimBlendSpeed = 8.9f;
        [SerializeField] private Transform CameraPlayerRoot;
        [SerializeField] private Transform Camera;
        [SerializeField] private float UpperLimit = -40f;
        [SerializeField] private float BottomLimit = 70f;
        [SerializeField] private float MouseSensitivity = 21.9f;
        public int KeyAmount;

        private Rigidbody _PlayerRigidbody;
        private InputManager _inputManager;
        private Animator _animator;
        private bool _hasAnimator;
        private int _xVelHash;
        private int _yVelHash;
        private float _xRotation;


        private const float _walkSpeed = 2f;
        private const float _runSpeed = 6f;
        private Vector2 _currentVelocity;


        private void Start()
        {
            _hasAnimator = TryGetComponent<Animator>(out _animator);
            _PlayerRigidbody = GetComponent<Rigidbody>();
            _inputManager = GetComponent<InputManager>();


            _xVelHash = Animator.StringToHash("X_Velocity");
            _yVelHash = Animator.StringToHash("Y_Velocity");
        }


        private void FixedUpdate()
        {
                Move();
            
        }


        private void LateUpdate()
        {
                camMovements();
        }

        private void Move()
        {
            if(!_hasAnimator) return;
            float targetSpeed = _inputManager.Run ? _runSpeed : _walkSpeed;
            if (_inputManager.Move == Vector2.zero) targetSpeed = 0;
            _currentVelocity.x = Mathf.Lerp(_currentVelocity.x, _inputManager.Move.x * targetSpeed, AnimBlendSpeed * Time.fixedDeltaTime);
            _currentVelocity.y = Mathf.Lerp(_currentVelocity.y, _inputManager.Move.y * targetSpeed, AnimBlendSpeed * Time.fixedDeltaTime);
            var xVelDifference = _currentVelocity.x - _PlayerRigidbody.velocity.x;
            var zVelDifference = _currentVelocity.y - _PlayerRigidbody.velocity.z;
            _PlayerRigidbody.AddForce(transform.TransformVector(new Vector3 (xVelDifference, 0 , zVelDifference)), ForceMode.VelocityChange);
            _animator.SetFloat(_xVelHash, _currentVelocity.x);
            _animator.SetFloat(_yVelHash, _currentVelocity.y);
        }


        private void camMovements()
        {
            if(!_hasAnimator) return;
            var Mouse_X = _inputManager.Look.x;
            var Mouse_Y = _inputManager.Look.y;
            Camera.position = CameraPlayerRoot.position;
            _xRotation -= Mouse_Y * MouseSensitivity * Time.smoothDeltaTime;
            _xRotation = Mathf.Clamp(_xRotation, UpperLimit, BottomLimit);
            Camera.localRotation = Quaternion.Euler(_xRotation, 0, 0);
            _PlayerRigidbody.MoveRotation(_PlayerRigidbody.rotation * Quaternion.Euler(0, Mouse_X * MouseSensitivity * Time.smoothDeltaTime, 0));
        }
    private void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "Key")
        {
            KeyAmount += 2;
            Destroy(other.gameObject);
        }
    }

        
    }
}
