using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attractable : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Attractor[] attractors = GameObject.FindObjectsOfType <Attractor>();
		print (attractors.Length);
		foreach (Attractor core in attractors) {
			core.AddAttractable (this.gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
