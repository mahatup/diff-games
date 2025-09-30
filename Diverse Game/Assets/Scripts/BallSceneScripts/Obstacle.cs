using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private SpawnObs _spawner;

    public void Init(SpawnObs spawner) 
    {
        _spawner = spawner;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            _spawner.Respawn();

        }
    }
}
