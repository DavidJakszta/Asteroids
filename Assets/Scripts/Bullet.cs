using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody2D rb;
    float speed = 15f;
    
    // Awake because bullets are Prefabs (object of which alot of instances will be created) and are usually not created at the start
    void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {
        
    }

    public void shoot( Vector2 direction ) {
        rb.velocity = direction.normalized * speed;
    }

    void OnTriggerExit2D (Collider2D other){
        if(other.tag == "Background"){
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Astroid"){
            Destroy(gameObject);
        }
    }
}
