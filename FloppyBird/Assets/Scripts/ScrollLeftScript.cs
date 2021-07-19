using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollLeftScript : MonoBehaviour
{

    private Rigidbody2D rb;
    public float speed; 
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.AddComponent<Rigidbody2D>() as Rigidbody2D;
        rb.bodyType = RigidbodyType2D.Kinematic;
        rb.velocity = new Vector2(speed*-1, 0.0f);
    }

    void Awake()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.x <= -12.42)
        {
            gameObject.transform.position = new Vector3(21.12f, -5.2f, -1f);
        }
    }
}
