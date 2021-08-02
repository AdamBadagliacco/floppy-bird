using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class APIHandler : MonoBehaviour
{
    [System.Serializable]
    public class LeaderboardEntry
    {
        public string name;
        public string score;
    }

    [System.Serializable]
    public class LeaderboardData
    {
        public LeaderboardEntry[] entries;
    }

    public Text Display;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DoRequest("https://2t6es54bpd.execute-api.us-west-2.amazonaws.com/public"));
    }

    IEnumerator DoRequest(string uri)
    {
        UnityWebRequest uwr = UnityWebRequest.Get(uri);
        yield return uwr.SendWebRequest();

        if (uwr.isNetworkError)
        {
            Debug.Log("Error While Sending: " + uwr.error);
        }
        else
        {
            string json_response = uwr.downloadHandler.text;
            Debug.Log("Received: " + json_response);

            string jsonBody = GetRequestBody(json_response).Replace("\\", "");

            LeaderboardData myObject = JsonUtility.FromJson<LeaderboardData>(jsonBody);
            
            Debug.Log("Entries: " + myObject);
            for (int i = 0; i < myObject.entries.Length; i++)
            {
                Debug.Log("Object " + i + ": " + myObject.entries[i].name + " " + myObject.entries[i].score);
            }

            Display.text = myObject.entries[1].name;
        }
    }

    public string GetRequestBody(string json_response)
    {
        int startOfBody = json_response.IndexOf("^");
        int endOfBody = json_response.IndexOf("|");
        return json_response.Substring(startOfBody + 1, (endOfBody - startOfBody) - 1);
    }
}
