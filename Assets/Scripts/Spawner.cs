using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Astroid astroid;
    float spawnRate = 2.0f;
    float spawnDistance = 10f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("spawn", 0f, spawnRate);
    }

    void spawn() {
        Vector2 spawnPoint = Random.insideUnitCircle.normalized * spawnDistance;

        float angle = Random.Range(-15, 15);

        Quaternion rotation = Quaternion.AngleAxis(angle, new Vector3(0,0,1));

        Astroid theAstroid = Instantiate(astroid, spawnPoint, rotation);

        Vector2 direction = rotation * -spawnPoint; //q*v/q
        float mass = Random.Range(0.8f, 1.4f);
        theAstroid.kick(mass, direction);
    }
    // Update is called once per frame
    void Update()
    {

    }

  
}
