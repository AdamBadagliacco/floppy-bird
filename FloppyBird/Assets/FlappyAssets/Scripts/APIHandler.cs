using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class APIHandler : MonoBehaviour
{
    public Text Display;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public static void UploadScore(string initials, int score, MonoBehaviour behavior)
    {
        behavior.StartCoroutine(PostScore(initials, score));
    }


    static IEnumerator PostScore(string initials, int score)
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
