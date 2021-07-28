using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdamTest : MonoBehaviour
{
    public GameObject myScore;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Score in Mario World is: " + myScore.GetComponent<ScoreScript>().GetScore());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
