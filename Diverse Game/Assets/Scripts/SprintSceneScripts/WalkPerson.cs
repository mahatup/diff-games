using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkPerson : MonoBehaviour
{
    private Rigidbody _rb;
    private float _speed = 5f;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        Walking(_rb);
    }
    private void Walking(Rigidbody rb)
    {
        Vector3 directionVec = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;
        rb.MovePosition(transform.position + directionVec * Time.fixedDeltaTime * _speed);

        if (directionVec != Vector3.zero)
        {
            Quaternion targetRot = Quaternion.LookRotation(directionVec);
            Quaternion smoothRot = Quaternion.Slerp(transform.rotation, targetRot, 4f * Time.fixedDeltaTime);
            rb.MoveRotation(smoothRot);
        }
    }
}
