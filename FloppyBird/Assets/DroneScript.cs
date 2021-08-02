using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneScript : MonoBehaviour
{
    public float leftSide = 0f;
    public float rightSide = 199f;
    public bool goingRight = true;
    private Rigidbody2D rb;

    //Below attributes are the ones to edit for a different feel/difficulty
    public float timeRemaining;
    public float TotalCoolDownTime;
    public float speed;
    public GameObject[] spawnableEnemies;
    public int MaxDroneAmount = 10; 

    public GameObject DroneParent;
    public GameObject DronePrefab;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.AddComponent<Rigidbody2D>() as Rigidbody2D;
        rb.bodyType = RigidbodyType2D.Kinematic;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.x <= leftSide) {
            moveRight();
        }
        else if (gameObject.transform.position.x >= rightSide)
        {
            moveLeft();
        }

        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
        }
        else
        {
            timeRemaining = TotalCoolDownTime;
            TotalCoolDownTime -= 0.5f;
            speed = speed + 0.5f;
            Instantiate(spawnableEnemies[Random.Range(0, spawnableEnemies.Length)], gameObject.transform.position, Quaternion.identity);

            //Resets drone to normal speed and cooldown, and creates another as well 
            if (TotalCoolDownTime < 1f && DronePrefab.transform.childCount < 10) {
                GameObject newDrone = Instantiate(DronePrefab, new Vector3(0, 9.45f, 0), Quaternion.identity);
                newDrone.transform.parent = DroneParent.transform;
                ResetDrone();
            }
        }
    }

    private void moveRight() {
        rb.velocity = new Vector2(speed, 0.0f);
        goingRight = true;
    }

    private void moveLeft() {
        rb.velocity = new Vector2(-speed, 0.0f);
        goingRight = false;
    }

    private void ResetDrone()
    {
         TotalCoolDownTime = 4;
            speed = 5;

    }
}
