using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour {
	private Mario mario;

	// Use this for initialization
	void Start () {
		mario = FindObjectOfType<Mario> ();
	}
	
	// Update is called once per frame
	void Update () {
	}
}
