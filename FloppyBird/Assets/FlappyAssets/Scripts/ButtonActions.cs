using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Networking;

public class ButtonActions : MonoBehaviour
{
    //public GameObject floor;
    public GameObject pipes;
    public GameObject buttons;
    public GameObject bird;
    public GameObject pressSpaceText;
    public GameObject submitScoreButton;
    public GameObject textInputField;
    public GameObject nameInputText;
    public GameObject scoreUploadedText;

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
        Difficulty.timeScale = 1f;
    }

    public void UploadScore()
    {
        string name = nameInputText.GetComponent<Text>().text;
        int score = ScoreScript.GetScore();
        UploadScore(name, score);

        submitScoreButton.SetActive(false);
        textInputField.SetActive(false);

        scoreUploadedText.SetActive(true) ;
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

    public void UploadScore(string initials, int score)
    {
        StartCoroutine(PostScore(initials, score));
    }


    IEnumerator PostScore(string initials, int score)
    {
        string uri = "https://2t6es54bpd.execute-api.us-west-2.amazonaws.com/public";
        WWWForm form = new WWWForm();
        form.AddField("name", initials);
        form.AddField("score", score);

        UnityWebRequest uwr = UnityWebRequest.Post(uri, form);
        yield return uwr.SendWebRequest();

        if (uwr.isNetworkError)
        {
            Debug.Log("Error While Sending: " + uwr.error);
        }
        else
        {
            Debug.Log("Form upload complete!");
            Debug.Log("Result: " + uwr.downloadHandler.text);
        }
    }
}
