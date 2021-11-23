using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class MakeButtons4Leaderboard : MonoBehaviour
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

    public GameObject ButtonPrefab;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GetLeaderboard());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator GetLeaderboard()
    {
        string uri = "https://2t6es54bpd.execute-api.us-west-2.amazonaws.com/public";
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
            Debug.Log("JSONBODY: " + jsonBody);
            LeaderboardData leaders = JsonUtility.FromJson<LeaderboardData>(jsonBody);

            Debug.Log("Entries: " + leaders);
            for (int i = 0; i < leaders.entries.Length; i++)
            {
                GameObject newButtonPrefab = Instantiate(ButtonPrefab, new Vector3(0, 0, 0), Quaternion.identity);
                newButtonPrefab.transform.parent = gameObject.transform;
                newButtonPrefab.transform.GetChild(0).GetComponent<Text>().text = "" + (i + 1) + ". " + leaders.entries[i].name + " - " + leaders.entries[i].score;
            }
        }
    }

    public string GetRequestBody(string json_response)
    {
        int startOfBody = json_response.IndexOf("^");
        int endOfBody = json_response.IndexOf("|");
        return json_response.Substring(startOfBody + 1, (endOfBody - startOfBody) - 1);
    }
}
