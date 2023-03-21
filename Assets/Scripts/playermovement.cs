using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;



public class playermovement : MonoBehaviour
{
    public CharacterController2D Controller;

    private bool isGameOver;


    float horizontalMove = 0f;

    public float runSpeed = 40f;

    private float movementSpeed = 5f;

    bool jump = false;


    Animator anim;

    public Text score;

    private int scoreValue;

    public Text livesText;

    public Text scoreValueText;
    public GameObject winTextObject;

    public GameObject loseTextObject;

    public float speed;


    private Rigidbody2D rd2d;

    private float movementX;
    private float movementY;

    private Rigidbody rb;

    private int lives;

    public AudioClip musicClipOne;

    public AudioClip musicClipTwo;

    public AudioClip musicClipThree;

    public AudioClip musicClipFour;

    public AudioSource musicSource;

    


    
    void Start()
    {   
        anim = GetComponent<Animator>(); 

        score.text = scoreValue.ToString();
        score.text = lives.ToString();
        rd2d = GetComponent<Rigidbody2D>();
        rb = GetComponent<Rigidbody>();



        winTextObject.SetActive(false);

        lives = 3;

        SetlivesText();

        loseTextObject.SetActive(false);

        SetscoreValueText();

        scoreValue = 0;

    }

    
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        if (Input.GetButtonDown("Jump"))
        {
            
            jump = true;
            anim.SetInteger("State", 3);
            musicSource.clip = musicClipTwo;
            musicSource.Play();
        }
        if (Input.GetButtonUp("Jump"))
        {
            anim.SetInteger("State", 0);
            musicSource.Stop();
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            anim.SetInteger("State", 1);
            musicSource.clip = musicClipOne;
            musicSource.Play();
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            anim.SetInteger("State", 0);
            musicSource.Stop();
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            anim.SetInteger("State", 1);
            musicSource.clip = musicClipOne;
            musicSource.Play();
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            anim.SetInteger("State", 0);
            musicSource.Stop();
        }
        if (lives <= 0)
        {
            Destroy(gameObject);
            
        }
        if (scoreValue >= 8)
        {
            Destroy(gameObject);
            
        }


   
    }

    void FixedUpdate ()
    {
        Controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;

        Vector3 movement = new Vector3(movementX, 0.0f, movementY);

        rd2d.AddForce(movement * speed);

        float hozMovement = Input.GetAxis("Horizontal");
        float vertMovement = Input.GetAxis("Vertical");
        rd2d.AddForce(new Vector2(hozMovement * speed, vertMovement * speed));

    }

    

    void OnCollisionEnter2D(Collision2D collision)
    {
       if (collision.collider.tag == "Coin")
        {
            scoreValue += 1;
            score.text = scoreValue.ToString();
            Destroy(collision.collider.gameObject);
            SetscoreValueText();
        }
        else if (collision.collider.tag == "Enemy")
        {
            lives -= 1;
            livesText.text = lives.ToString();
            Destroy(collision.collider.gameObject);
            SetlivesText();
        }
        
       
        if (scoreValue == 4 && !isGameOver)
        { 
            isGameOver = true;
            transform.position = new Vector2(88.5f, 0.26f);

            lives = 3;

            SetlivesText();
            
        }
        
    }

   


  

    void SetscoreValueText()
    {
        scoreValueText.text = "Score: " + scoreValue.ToString();

        if (scoreValue >= 8)
        {

            winTextObject.SetActive(true);
            
            
        }
        
    }
    void SetlivesText()
    {
        livesText.text = "Lives: " + lives.ToString();

        if (lives <= 0)
        {
            loseTextObject.SetActive(true);
            
            
        }
    }

    void OnMove(InputValue value)
    {
        Vector2 v = value.Get<Vector2>();

        movementX = v.x;
        movementY = v.y;
    }
   
    
}
