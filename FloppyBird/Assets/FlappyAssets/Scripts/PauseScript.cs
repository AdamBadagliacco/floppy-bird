using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour
{
    public float timeScaleB4Pause;
    public bool paused = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (paused) {
                paused = false;
                Time.timeScale = timeScaleB4Pause;
            }
            else {
                timeScaleB4Pause = Time.timeScale;
                paused = true;
                Time.timeScale = 0f;
            }
        }
    }
}
