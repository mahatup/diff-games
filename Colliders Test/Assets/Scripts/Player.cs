using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed;
    private Rigidbody _rb;
    private MeshRenderer _mesh;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _mesh = GetComponent<MeshRenderer>();
    }

    private void FixedUpdate()
    {
        Vector2 input = GetInput();

        _rb.AddForce(transform.right * input.x * _speed);
        _rb.AddForce(transform.forward * input.y * _speed);
    }

    private Vector2 GetInput ()
    {
        return new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "FireZone") 
        {
            transform.localScale *= 2;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "FireZone")
        {
            transform.localScale /= 2;
        }
    }

}
