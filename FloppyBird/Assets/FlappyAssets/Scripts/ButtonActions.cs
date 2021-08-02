using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonActions : MonoBehaviour
{
    //public GameObject floor;
    public GameObject pipes;
    public GameObject buttons;
    public GameObject bird;
    public GameObject pressSpaceText;
    public GameObject submitScoreButton;
    public GameObject nameInputText;

    public string initials;

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

    public void PlayAgain()
    {
        SceneManager.LoadScene("FlappyBird");
        ScoreScript.SetScore(0);
    }

    public void UploadScore()
    {
        string name = nameInputText.GetComponent<Text>().text;
        int score = ScoreScript.GetScore();
        APIHandler.UploadScore(name, score, this);
    }

    public void InitialsChanged(string newInitials)
    {
        Debug.Log(newInitials.Length);
        if (newInitials.Length > 0)
        {
            submitScoreButton.GetComponent<Button>().interactable = true;
        }
        else
        {
            submitScoreButton.GetComponent<Button>().interactable = false;
        }
    }
}
