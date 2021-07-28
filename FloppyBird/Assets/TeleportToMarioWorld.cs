using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportToMarioWorld : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collidedObject)
    {
        if (collidedObject.transform.tag == "Bird")
        {
            Debug.Log("Going To MarioWorld");
            SceneManager.LoadScene(1);
        }
    }
}
