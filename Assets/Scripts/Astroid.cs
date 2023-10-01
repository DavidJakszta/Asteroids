using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Astroid : MonoBehaviour
{

    public Sprite[] sprites;
    Rigidbody2D rb;
    SpriteRenderer sr;
    PolygonCollider2D pc;
    float speed = 2f;

    // Start is called before the first frame update
    void Start()
    {
     //explosion =  GameObject.Find("Explosion").GetComponent<ParticleSystem>();
    }

    void Awake() {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        pc = GetComponent<PolygonCollider2D>();
    }

    public void kick(float theMass, Vector2 direction){
        //choose random sprite
       sr.sprite = this.sprites[Random.Range(0, this.sprites.Length)];

    //upadte collider path
       List<Vector2> path = new List<Vector2>();
       sr.sprite.GetPhysicsShape(0, path);
       pc.SetPath(0, path.ToArray());

    //Set mass and scale 
       rb.mass = theMass;
       float width = Random.Range(0.75f, 1.33f);
       float height = 1/width;
       transform.localScale = new Vector2(width, height) * theMass;
    // move and rotate
       rb.velocity = direction.normalized * speed;
       rb.AddTorque(Random.Range(-4f, 4f));
    }

    void OnTriggerExit2D(Collider2D other){
        if(other.tag == "Background"){
            Destroy(gameObject);
        }
    }

       void OnTriggerEnter2D(Collider2D other){
        
        if(other.tag == "Bullet"){
           if(rb.mass > 0.7f){
            split();
           
           }
           Destroy(gameObject);
           FindObjectOfType<GameManager>().increaseScore(rb.mass, rb.transform.position);
        }
        else if(other.tag == "Ship"){
            Destroy(gameObject);
            
         }
        
    }

    void split() {
        Vector2 position = this.transform.position + Random.insideUnitSphere * 0.5f; // adding to random point inside sphere doesnt break collision? z doesnt matter??
        Vector2 position2 = this.transform.position + Random.insideUnitSphere * 0.5f;

        Astroid small = Instantiate(this, position, this.transform.rotation );
        Astroid small2 = Instantiate(this, position2, this.transform.rotation );

        Vector2 direction = Random.insideUnitCircle;
        float mass = rb.mass/2;
        
        small.kick(mass, direction);
        small2.kick(mass, direction);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
