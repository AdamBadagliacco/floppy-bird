using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.centerOfMass = new Vector2(-0.004216969f, 10.114217328f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            Debug.Log("Jumping!");
            rb.velocity = new Vector2(0f, 0f);
            rb.AddForce(new Vector2(0f, 5f), ForceMode2D.Impulse);
        }
    }

    void OnTriggerEnter2D(Collider2D collidedEnvironment)
    {
        Debug.Log("GAME. OVER");
    }
}
