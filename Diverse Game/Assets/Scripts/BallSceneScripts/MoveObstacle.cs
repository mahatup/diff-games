using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MoveObstacle : MonoBehaviour
{
   
    private Rigidbody _rb;
    private float _speed = 10f; 
    private void Awake()
    {
        
        _rb = GetComponent<Rigidbody>();
        
    }
    void Update()
    {
        MoveObs(_speed);

    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Wall")
        {
            _speed = -_speed * 1.2f;
        }
    }
    private void MoveObs(float speed)
    {
        _rb.AddForce(new Vector3(1, 0, 0) * speed);
    }
}
