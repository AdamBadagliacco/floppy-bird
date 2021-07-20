using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipePairScript : MonoBehaviour
{
    //Prox and speed will increase with difficulty
    public float bigProxDelta; //Proximity change per reset at first
    public float smallProxDelta; // Proxity change per reset later
    public int bigDeltaIterations;
    public int iteration = 0;

    public float heightMax; //-2.25
    public float heightMin; //-6.00

    public GameObject topPipe;
    public GameObject botPipe;

    private Rigidbody2D rb;
    private float height;

    public GameObject coinPrefab;
    private GameObject currentCoin;


    void Start()
    {
        RandomizeHeight();
        SetCoinHeight();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SetCoinHeight()
    {
        if (currentCoin != null)
        {
            Destroy(currentCoin);
        }
        currentCoin = Instantiate(coinPrefab, new Vector3(topPipe.transform.position.x, (topPipe.transform.position.y + botPipe.transform.position.y) / 2, topPipe.transform.position.z), Quaternion.identity) as GameObject; ;
        currentCoin.transform.parent = gameObject.transform;
    }

    public void ResetPipe()
    {
        IncreaseProximity();
        RandomizeHeight();
        iteration++;
        SetCoinHeight();
    }
    
    private void IncreaseProximity()
    {
        float proxDelta;
        if (iteration < bigDeltaIterations)
        {
            proxDelta = bigProxDelta;
        } 
        else
        {
            proxDelta = smallProxDelta;
        }
        topPipe.transform.position = new Vector3(topPipe.transform.position.x, topPipe.transform.position.y - proxDelta, topPipe.transform.position.z);
    }

    private void RandomizeHeight()
    {
        height = Random.Range(heightMin, heightMax);
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, height, gameObject.transform.position.z);
    }
}
