using System.Threading.Tasks;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class Wolf : MonoBehaviour
{
    public Rigidbody2D SquareRB;
    public float velocityInt;
    public Animator WolfAnimator;
    public Collider2D wolfcollider;
    public bool jump;
    
    public Vector3 scale;
    public bool idleBool;
    public GameObject cam;
    public Rigidbody2D camRB;
    public Vector2 wolfspeed;
    public float wolfspeedy;
    public float PlayerHealth;
    public TextMeshProUGUI healttext;
    public TextMeshProUGUI scoretext;
    public Image healthbar;
    public float score;
    public bool isDeath;
    public Button exitButton;
    public Button playButton;
    public TextMeshProUGUI playtext;
    public GameObject gameOverCanvas;


    // Start is called before the first frame update
    void Start()
    {
        SquareRB = GetComponent<Rigidbody2D>();
        WolfAnimator = GetComponent<Animator>();
        wolfcollider = GetComponent<Collider2D>();
        jump = false;
        PlayerHealth = 100;
        score = 0;
        Time.timeScale=0;

        
    }

    void exit()
    {
        Application.Quit();
    }
    
    void play()
    {
        if(isDeath)
        {
            isDeath=false;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        }
        
        
            Time.timeScale = 1;
            gameOverCanvas.SetActive(false);
        
    }

    // Update is called once per frame
    async void Update()
    {   
        
        playButton.onClick.AddListener(play);
        exitButton.onClick.AddListener(exit);

        if (Input.GetKeyDown(KeyCode.Escape)&&!isDeath)
        {
            if(Time.timeScale==0)
            {
                Time.timeScale=1;
                gameOverCanvas.SetActive(false);

            }

            else
            {
                Time.timeScale = 0;
                gameOverCanvas.SetActive(true);
            }
        }
        
        if (PlayerHealth < 0)
        {
            PlayerHealth = 0;
        }

        scoretext.text = score.ToString();

        healttext.text = PlayerHealth.ToString();
        wolfspeedy = SquareRB.velocity.y;
        SquareRB.velocity = new Vector2(wolfspeed.x,wolfspeedy);
        //camRB.velocity = new Vector2(SquareRB.velocity.x,0);

        cam.transform.position = new Vector3(transform.position.x,0,-10);

        healthbar.fillAmount = PlayerHealth/100;
        
        if (wolfspeed.x == 0 && jump!)
        
        {
            
            WolfAnimator.SetBool("idle",true);
            idleBool = true;
            
        }
        else
        {
            WolfAnimator.SetBool("idle",false);
            idleBool = false;
        }

        if (Input.GetKeyDown("w"))  
        {
            if (jump!)
            {
                jump = true;
                WolfAnimator.SetTrigger("Jump");
                SquareRB.velocity = new Vector2 (wolfspeed.x,velocityInt); 
                await Task.Delay(150);
                jump = false;
            }               
        }

          if (Input.GetKeyDown("space"))
        
        {
            if (idleBool)
            {    
                WolfAnimator.SetTrigger("attack");
            }

            else if (jump! && wolfspeed.x != 0)
            {
                WolfAnimator.SetTrigger("runattack");
            }
        }

        if (Input.GetKey("a"))
        {
             if (wolfspeed.x >= 0)
            {
                scale = gameObject.transform.localScale;
                scale.x = -3;
                gameObject.transform.localScale = scale;
            }
            wolfspeed.x = -6;
        }

        else if (Input.GetKey("d"))
        {
            if (wolfspeed.x <= 0)
            {
                scale = gameObject.transform.localScale;
                scale.x = 3;
                gameObject.transform.localScale = scale;
            }
            wolfspeed.x = 6;
  
        }
        else 
        {
            wolfspeed.x = 0;
        }

        if (PlayerHealth <= 0 )
        {
            PlayerHealth = 0;
            WolfAnimator.SetTrigger("dead");
            isDeath = true;
            gameOverCanvas.SetActive(true);
            playtext.text = "Play Again";
            
        }

       
    }
}
