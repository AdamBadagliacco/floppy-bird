using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonActions : MonoBehaviour
{
    //public GameObject floor;
    public GameObject pipes;
    public GameObject buttons;
    public GameObject bird;
    public GameObject pressSpaceText;

    public void Play()
    {
        pipes.SetActive(true);
        buttons.SetActive(false);
        pressSpaceText.SetActive(true);
        bird.GetComponent<BirdScript>().SetMode(BirdScript.Mode.Ready);

    }
    public void Characters()
    {
        Debug.Log("Button Pressed");
    }
    public void LeaderBoards()
    {
        Debug.Log("Button Pressed");
    }
    public void CreateAccount()
    {
        Debug.Log("Button Pressed");
    }
    public void LogIn()
    {
        Debug.Log("Button Pressed");
    }
}
