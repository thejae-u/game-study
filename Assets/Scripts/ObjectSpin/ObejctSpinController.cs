using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObejctSpinController : MonoBehaviour
{
    [SerializeField] private float _rotatingSpeed;
    [SerializeField] private float _orbitSpeed;
    [SerializeField] private float _distance;

    private float _rotating = 0f;
    private float _orbit = 0f;

    private Transform _myTransform;
    
    private Camera _mainCamera;
    
    private Vector3 _movePos;
    private Vector3 _rotatePos;

    private void Start()
    {
        _myTransform = transform;
        _mainCamera = Camera.main;
    }

    private void Update()
    {
        RotateObject();
        MoveObject();
    }

    private void MoveObject()
    {
        Debug.Assert(_mainCamera != null);
        _orbit += _orbitSpeed * Time.deltaTime;
        _movePos.x = Mathf.Sin(_orbit);
        _movePos.z = Mathf.Cos(_orbit);

        _myTransform.position = _movePos * (_distance / 2);
    }

    private void RotateObject()
    {
        _rotating += _rotatingSpeed * Time.deltaTime;

        _myTransform.localRotation = Quaternion.Euler(0, _rotating, 0);
    }
}
