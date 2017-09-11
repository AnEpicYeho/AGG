using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attractable : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Core[] cores = GameObject.FindObjectsOfType <Core>();
		print (cores.Length);
		foreach (Core core in cores) {
			core.AddAttractable (this.gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
