using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    private Rigidbody2D rb;
    public ScoreScript scoreScript;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            rb.velocity = new Vector2(0f, 0f);
            rb.AddForce(new Vector2(0f, 5f), ForceMode2D.Impulse);
        }
    }

    void OnTriggerEnter2D(Collider2D collidedObject)
    {
        if (collidedObject.transform.tag == "Pipe" || collidedObject.transform.tag == "Floor")
        {
            Time.timeScale = 0;
        }
        else if (collidedObject.transform.tag == "Coin")
        {
            scoreScript.AddPoint();
            Debug.Log("Hello!");
            Destroy(collidedObject.gameObject);
            // Play blink182 sound effect
        }
        Debug.Log("GAME. OVER");
    }
}
