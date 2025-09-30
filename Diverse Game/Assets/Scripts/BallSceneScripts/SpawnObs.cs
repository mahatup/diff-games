using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObs : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _obsPrefab;

    private Vector3 _minPosition, _maxPosition;
    private GameObject _instance;
    private int _index;
    private void Awake()
    {
        _minPosition = new Vector3(-8.9f, 0f, -1.5f);
        _maxPosition = new Vector3(8.9f, 0f, 7f);
    }
    private void Start()
    {
        Spawn();
        
    }

    private void Spawn()
    {
        _index = Random.Range(0, _obsPrefab.Length);
        Vector3 randomPosition = new Vector3(
        Random.Range(_minPosition.x, _maxPosition.x),
        _obsPrefab[_index].transform.position.y,
        Random.Range(_minPosition.z, _maxPosition.z)
        );
        _instance = Instantiate(_obsPrefab[_index], randomPosition, Quaternion.identity);

        _instance.GetComponent<Obstacle>().Init(this);
    }
    public void Respawn()
    {
        if (_instance != null) 
        {
            Destroy(_instance);

        }
        Spawn();
    }
}
