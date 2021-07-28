using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{

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
    }

    public void SetMode(Mode newValue)
    {
        mode = newValue;
        
    }

    void OnTriggerEnter2D(Collider2D collidedObject)
    {
        if (collidedObject.transform.tag == "Pipe" || collidedObject.transform.tag == "Floor")
        {
            //Time.timeScale = 0;
            mode = Mode.Dead;
            pipes.GetComponent<StopMoving>().MakeStopMoving();
            floors.GetComponent<StopMoving>().MakeStopMoving();
            GetComponent<CapsuleCollider2D>().isTrigger = false;

        }
        else if (collidedObject.transform.tag == "Coin")
        {
            scoreScript.AddPoint();
            Debug.Log("Hello!");
            Destroy(collidedObject.gameObject);
            // Play blink182 sound effect
        }
        else if (collidedObject.transform.tag == "Ceiling") {
            rb.AddForce(new Vector2(0f, -5f), ForceMode2D.Impulse);
        }

        Debug.Log("GAME. OVER");
    }

}
