using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
    
[RequireComponent(typeof(CharacterController))]
public class AnimationHero : MonoBehaviour
{
    [SerializeField]
    private GameObject _body, _armR, _armL, _legR, _legL;
    [SerializeField] private float _speed = 10f;
    [SerializeField] private float _speedRotateHero = 10f, _angleRotate = 20f, _speedRotateArms = 3f, 
        _speedStep = 10f, _amplitude = 0.2f; 
    private CharacterController _controller;
    private Vector3 _moveDirection, _moveLegR, _moveLegL;
    private Quaternion _restRotationR, _restRotationL;

    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
        _moveLegR = _legR.transform.localPosition;
        _moveLegL = _legL.transform.localPosition;

        _restRotationR = _armR.transform.localRotation;
        _restRotationL = _armL.transform.localRotation;
    }
    private void Update()
    {
        _moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        _moveDirection.Normalize();
        

        if (_moveDirection != Vector3.zero) 
        {
            //transform.DOLookAt(_moveDirection, -1f, AxisConstraint.None, Vector3.up);
            Quaternion toRotate = Quaternion.LookRotation(_moveDirection, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, toRotate, Time.deltaTime * _speedRotateHero);
            MotionAnimation(true);
        }
        else MotionAnimation(false);
    }
    private void FixedUpdate()
    {
        Move(_moveDirection);
    }
    private void Move(Vector3 direction)
    {
        _controller.Move(direction * _speed * Time.fixedDeltaTime);
    }
    private void MotionAnimation(bool IsMotion)
    {
        float angle = Mathf.Sin(Time.time * _speedRotateArms) * _angleRotate;
        float step = Mathf.Sin(Time.time * _speedStep) * _amplitude;
        
        

        if (IsMotion)
        {
            //_armR.transform.DORotate(new Vector3(45, 20, -146), -1, RotateMode.WorldAxisAdd);
            _armR.transform.localRotation = _restRotationR * Quaternion.Euler(angle, 0, 0);
            _armL.transform.localRotation = _restRotationL * Quaternion.Euler(-angle, 0, 0);

            _legR.transform.localPosition = _moveLegR + new Vector3(0, 0, step);
            _legL.transform.localPosition = _moveLegL + new Vector3(0, 0, -step);

        }
        else
        {
            _armR.transform.localRotation = Quaternion.Lerp(_armR.transform.localRotation, _restRotationR, Time.deltaTime * 10f);
            _armL.transform.localRotation = Quaternion.Lerp(_armL.transform.localRotation, _restRotationL, Time.deltaTime * 10f);

            _legR.transform.localPosition = Vector3.Lerp(_legR.transform.localPosition, _moveLegR, 10f);
            _legL.transform.localPosition = Vector3.Lerp(_legL.transform.localPosition, _moveLegL, 10f);

        }
    }
}
