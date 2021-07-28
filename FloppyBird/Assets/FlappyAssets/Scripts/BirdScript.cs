using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        mode = Mode.Menu;
    }


    // Update is called once per frame
    void Update()
    {
        if (mode == Mode.Play) {
            if (Input.GetKeyDown("space"))
            {
                Jump();
            }
        }
        else if (mode == Mode.Menu) {
            AutoJump();
        }
        else if (mode == Mode.Ready)
        {
            AutoJump();

            if (Input.GetKeyDown("space"))
            {
                Jump();
                mode = Mode.Play;
                pressSpaceText.SetActive(false);
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
    }

    public void GetCoin()
    {
        scoreScript.AddPoint();
        coinSound.GetComponent<AudioSource>().Play();
    }

}
