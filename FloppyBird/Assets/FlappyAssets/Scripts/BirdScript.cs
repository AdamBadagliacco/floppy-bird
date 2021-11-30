using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BirdScript : MonoBehaviour
{
    public GameObject coinSound;
    public GameObject deadSound;
    public GameObject jumpSound;

    public enum Mode { Menu, Ready, Play, Dead };
    private Mode mode; 
    private Rigidbody2D rb;
    public ScoreScript scoreScript;

    public GameObject pressSpaceText;

    public GameObject pipes;
    public GameObject floors;

    public GameObject leaderboard;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        mode = Mode.Ready;

        Debug.Log("current Timescale:" + Difficulty.timeScale);

        if (Difficulty.timeScale > 1f) { //Game already started dont need this shown
            leaderboard.SetActive(false);
        }

        Time.timeScale = Difficulty.timeScale;
    }


    // Update is called once per frame
    void Update()
    {
        if (mode == Mode.Play) {
            if (Input.GetKeyDown("space") || Input.touches.Length > 0)
            {
                if (gameObject.transform.position.y < 5.25)
                {
                    Jump();
                }
            }
        }
        else if (mode == Mode.Menu) {
            AutoJump();
        }
        else if (mode == Mode.Ready)
        {
            AutoJump();

            if (Input.GetKeyDown("space") || Input.touches.Length > 0)
            {
                Jump();
                mode = Mode.Play;
                pressSpaceText.SetActive(false);
                pipes.SetActive(true); 
                leaderboard.SetActive(false);
            }
        }


    }

    public void AutoJump()
    {
        if (gameObject.transform.position.y <= -.25)
        {
            Jump();
        }
    }

    public void Jump()
    {
        rb.velocity = new Vector2(0f, 0f);
        rb.AddForce(new Vector2(0f, 5f), ForceMode2D.Impulse);
        jumpSound.GetComponent<AudioSource>().Play();
    }

    public void SetMode(Mode newValue)
    {
        mode = newValue;
        
    }

    public void KillBird()
    {
        //Time.timeScale = 0;
        mode = Mode.Dead;
        pipes.GetComponent<StopMoving>().MakeStopMoving();
        floors.GetComponent<StopMoving>().MakeStopMoving();
        GetComponent<CapsuleCollider2D>().isTrigger = false;
        deadSound.GetComponent<AudioSource>().Play();
        StartCoroutine(deathWaiter());
    }

    IEnumerator deathWaiter()
    {
        //Wait for 2 seconds
        yield return new WaitForSecondsRealtime(1);
        SceneManager.LoadScene("Game Over Screen");
    }

    public void GetCoin()
    {
        scoreScript.AddPoint();
        coinSound.GetComponent<AudioSource>().Play();
    }

    void OnTriggerEnter2D(Collider2D collidedObject)
    {
        if (collidedObject.transform.tag == "Pipe" || collidedObject.transform.tag == "Floor")
        {
            KillBird();
        }
        else if (collidedObject.transform.tag == "Coin")
        {
            GetCoin();
            Destroy(collidedObject.gameObject);
        }
        else if (collidedObject.transform.tag == "GreenPipe")
        {
            Debug.Log("Leaving Timescale: " + Time.timeScale);
            Difficulty.timeScale = Time.timeScale - 0.1f;
           SceneManager.LoadScene("World 1-1");
        }
    }

}
