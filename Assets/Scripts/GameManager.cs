using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TMP_Text scoreText;
    public TMP_Text highscoreText;
    public TMP_Text livesText;
    float score;
    float highscore;
    int lives = 3;
    public ParticleSystem explosion;
    // Start is called before the first frame update
    void Start()
    {

       // .GetComponent<Astroid>().MyFunction();
      // explosion = GameObject.Find("Explosion").GetComponent<ParticleSystem>();
       //  explosion = GetComponent<ParticleSystem>();
    }

    public void increaseScore(float mass, Vector2 position){
        score += mass * 10;
        if( highscore < score){
            highscore = score;
        }
        
        print(("score: " + score.ToString()));
        explosion.transform.position = position;
        
        ParticleSystem explosionInstance = Instantiate(explosion, position, Quaternion.identity);
        Destroy(explosionInstance.gameObject, 2);
        // explosion.Emit(100); idk
        // explosion.Play();  only works if the particleSystem is not immediately used somewhere else (only one position at a time)
    }

    public void decreaseLifes(Vector2 position){
        ParticleSystem explosionInstance = Instantiate(explosion, position, Quaternion.identity);
        Destroy(explosionInstance.gameObject, 2);
        lives--;
        if(lives == 0){
            gameOver();
        }
    }

    void gameOver(){
        score = 0;
        lives = 2;
        //Invoke("reset", 5);
        // destroy everything
    }


   
    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + score.ToString();
        highscoreText.text = "HighScore: " + highscore.ToString();
        livesText.text = "Lives: " + lives.ToString();
    }
}
