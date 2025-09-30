using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEngine.UI.Image;

public class MovePlayer : MonoBehaviour
{
    private Vector3 _startPosition, _direction;
    private Rigidbody _rb;
    [SerializeField]
    private TMP_Text _scoreText;
    private int _score = 0;
    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _startPosition = transform.position;
        _scoreText.text = "Score: " + _score;
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitData;
            if(Physics.Raycast(ray, out hitData))
            {
                _direction = (hitData.point - _startPosition).normalized;
                _rb.velocity = Vector3.zero;
                _rb.AddForce(_direction * 30f, ForceMode.Impulse);
            }
        }
        if (transform.position.z >= 10f) 
        {
            Restart();
            _score = 0;
            _scoreText.text = "Score: " + _score;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Obs")
        {
            Restart();
            _score++;
            _scoreText.text = "Score: " + _score;
        }
    }
    private void Restart()
    {
        transform.position = _startPosition;
        _rb.velocity = Vector3.zero;
        _rb.angularVelocity = Vector3.zero;
    }
}
