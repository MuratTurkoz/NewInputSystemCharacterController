using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSimpleMoveTest : MonoBehaviour
{
    private CharacterController _controller;
    [SerializeField] private float _speed = 6;
    [SerializeField] private float _rotationSpeed = 6;
    private PlayerInputTest _playerInputTest;

    private Vector3 _movement;

    private void Start()
    {
        _playerInputTest=GetComponent<PlayerInputTest>();
        _controller = GetComponent<CharacterController>();
    }
    private void Update()
    {
        //Rotate
        transform.Rotate(0, _playerInputTest.GetHorizontalInput() * _rotationSpeed, 0);
        //Move 
        _movement = transform.TransformDirection(Vector3.forward);
        float _currentSpeed = _speed * _playerInputTest.GetVerticalInput();
        _controller.SimpleMove(_movement * _currentSpeed);

    }

}
