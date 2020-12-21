using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{
    public Vector2 speed; //Ball only moves in 2d space
    public float speedMultiplier = 1;
    public AudioSource audioSource;
    public AudioSource gameMusic;
    public AudioClip hitSound;
    public AudioClip endSound;
    public Animator textAnimator;
    public Text text;
    public PongPlayer player;

    public bool gameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("PongPlayer").GetComponent<PongPlayer>();
        gameMusic.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver == false)
        {
            transform.position += new Vector3(speed.x, speed.y) * Time.deltaTime * speedMultiplier;
        }
        
        //Check if Player missed the ball
        if (transform.position.x < -9 || transform.position.x > 9 || transform.position.y < -5 || transform.position.y > 5)
        {
            End();
        }

        //Allow user to replay game
        if (gameOver == true)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                transform.position = Vector3.zero;
                gameOver = false;
                gameMusic.Play();
                text.text = "";
            }
        }

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        //Debug.Log(col.gameObject.name);

        if (col.gameObject.name == "Paddle Floor")
        {
            speed.y = -speed.y; //Send Ball back (Vertical)
            HitEffect();
        }

        if (col.gameObject.name == "Paddle Wall")
        {
            speed.x = -speed.x; //Send Ball back (Horizontal)
            HitEffect();
        }
    }

    void HitEffect()
    {
        textAnimator.SetTrigger("effect");
        player.totalScore += 1;
        text.text = player.totalScore.ToString();
        audioSource.pitch = Random.Range(0.8f, 1.3f);
        audioSource.PlayOneShot(hitSound);
    }

    void End()
    {
        gameMusic.Stop();
        transform.position = new Vector3(100, 100, 0);
        player.totalScore = 0;
        text.text = "Game Over !\nSpace to Replay\nEsc for Main Menu";
        audioSource.pitch = 1.0f;
        audioSource.PlayOneShot(hitSound);
        gameOver = true;
    }
}
