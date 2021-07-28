﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collidedObject)
    {
        if (collidedObject.transform.tag == "Bird")
        {
            collidedObject.GetComponent<BirdScript>().GetCoin();
            Destroy(gameObject);
        }
    }
}
