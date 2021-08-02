using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentDroneScript : MonoBehaviour
{
    public float timeRemaining = 7f;
    public float TotalCoolDownTime = 7f;
    public GameObject DronePrefab;

    // Start is called before the first frame update
    void Start()
    {
        if (Difficulty.droneAmount > 2)
        {
            Difficulty.droneAmount -= 1;
        }

        for (int i = 0; i < Difficulty.droneAmount; i++)
        {
            GameObject newDrone = Instantiate(DronePrefab, new Vector3(i * 100, (-.25f * i) + 9.45f, 0), Quaternion.identity);
            newDrone.transform.parent = gameObject.transform;
        }


    }

    // Update is called once per frame
    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
        }
        else
        {
            Difficulty.droneAmount += 1;
            int i = Difficulty.droneAmount;
            GameObject newDrone = Instantiate(DronePrefab, new Vector3(i * 100, (-.25f * i) + 9.45f, 0), Quaternion.identity);
            newDrone.transform.parent = gameObject.transform;
        }

    }
}
