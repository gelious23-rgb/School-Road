using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Speedometr : MonoBehaviour
{

    public const float _maxSpeedAngle = -90;
    public const float _zeroSpeedAngle = 90;

    private Transform _arrowTransform;

    private float _speedMax;
    private float _speed;
    

    private void Awake()
    {
        _arrowTransform = transform.Find("Arrow");

        _speed = 0f;
        _speedMax = 200f;

    }
    private void Update()
    {
        _speed += ((PlayerController._risingSpeed * 170f) * Time.deltaTime);
        if (_speed > _speedMax) _speed = _speedMax;

        _arrowTransform.localEulerAngles = new Vector3(0, 0, GetSpeedRotation());
    }

    private float GetSpeedRotation()
    {
        float _totalAngleSize = _zeroSpeedAngle - _maxSpeedAngle;

        float _speedNormalized = _speed / _speedMax;

        return _zeroSpeedAngle - _speedNormalized * _totalAngleSize;
    }


}
