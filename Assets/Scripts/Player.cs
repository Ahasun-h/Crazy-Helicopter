using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
   
    public float tapForce = 200;
    public float tiltSmoth = 50;
    public Vector3 StartPos;

    Rigidbody2D rigidbody;
    Quaternion downRotation;
    Quaternion forwardRotation;

   

    float currentTime = 4f;
    [SerializeField] Text countdownText;
    public GameObject coutdownLayer;
    public GameObject coutdownText;
    public GameObject coutdownMessage;


    public GameObject pauseButton;
    public GameObject score;


    public GameUI gameUi;

    AudioSource audio;


    void Start()
    {
            rigidbody = GetComponent<Rigidbody2D>();
            downRotation = Quaternion.Euler(0, 0, -5);
            forwardRotation = Quaternion.Euler(0, 0, 5);

            audio = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.instante.gameStates == GameManager.GameStates.countdown)
        {
            currentTime -= 1 * Time.deltaTime;

            countdownText.text = currentTime.ToString("0");
            if (currentTime <= 0)
            {
                currentTime = 0;

                coutdownLayer.SetActive(false);
                coutdownText.SetActive(false);
                coutdownMessage.SetActive(false);

                pauseButton.SetActive(true);
                score.SetActive(true);

             

                GameManager.instante.gameStates = GameManager.GameStates.gmaePlaying;
            }
        }



        if (GameManager.instante.gameStates == GameManager.GameStates.gmaePlaying)
        {

            if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                transform.rotation = forwardRotation;
                rigidbody.velocity = Vector3.zero;
                rigidbody.AddForce(Vector2.up * tapForce, ForceMode2D.Force);
            }
           

            if (Input.GetMouseButtonDown(0))
            {
                transform.rotation = forwardRotation;
                rigidbody.velocity = Vector3.zero;
                rigidbody.AddForce(Vector2.up * tapForce, ForceMode2D.Force);
            }

            transform.rotation = Quaternion.Lerp(transform.rotation, downRotation, tiltSmoth * Time.deltaTime);
        }else
        {
            this.transform.position = new Vector3(0f, 1.14f, transform.position.z);
        }

            

    }

    private void OnTriggerEnter2D(Collider2D Other)
    {
        if (Other.tag == "SkyObject")
        {
            GameManager.instante.gameStates = GameManager.GameStates.playerDied;
            this.gameObject.SetActive(false);

            audio.Play();
            // uIManager.SaveGameData();
            gameUi.ActivateRestartUI();
            gameUi.SaveGameData();
           // uIManager.CarCrashSound();

        }

        else if (Other.tag == "GroundObject")
        {
            GameManager.instante.gameStates = GameManager.GameStates.playerDied;
            this.gameObject.SetActive(false);

            audio.Play();
            // uIManager.SaveGameData();
            gameUi.ActivateRestartUI();
            gameUi.SaveGameData();
            // uIManager.CarCrashSound();

        }

        else if (Other.tag == "DeadZone")
        {
            GameManager.instante.gameStates = GameManager.GameStates.playerDied;
            this.gameObject.SetActive(false);

            audio.Play();
            gameUi.ActivateRestartUI();
        }

      
    }



}
