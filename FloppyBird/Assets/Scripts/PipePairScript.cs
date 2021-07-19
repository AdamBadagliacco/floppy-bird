using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipePairScript : MonoBehaviour
{

    //Prox and speed will increase with difficulty
    public float prox; //Proximity

    public float heightMax; //-0.98
    public float heightMin; //-5.82

    private Rigidbody2D rb;
    private float height;

    void Start()
    {
        height = Random.Range(heightMin, heightMax);
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, height, gameObject.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.x >= 19f)
        {
            height = Random.Range(heightMin, heightMax);
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, height, gameObject.transform.position.z);
        }
    }
}
