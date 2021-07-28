using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopMoving : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MakeStopMoving()
    {
        foreach (Transform child in gameObject.transform)
        {
            child.GetComponent<ScrollLeftScript>().SetSpeed(0f);
        }
    }
}
