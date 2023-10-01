using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    // Start is called before the first frame update
    public float AgeLimit;
    float age;
    void Start(){

    }/* 
    void Awake(){
        ParticleSystem ps = GetComponent<ParticleSystem>();
    }
    void Reset()
    {
        AgeLimit = 10.0f;
    }
 
    void Update ()
    {
        if (age > AgeLimit)
        { 
            Destroy(gameObject);
            return;
        }
 
        age += Time.deltaTime;
    } */
}
