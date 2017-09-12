using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attractor : MonoBehaviour {

	const float grabitationalConstant = 667.4f;
	private Rigidbody rigidBody;
	private List<GameObject> attractables;


	public void removeAttractable(GameObject attractable){
		attractables.Remove (attractable);
	}

	public List<GameObject> getAttractablesList()
	{
		return attractables;
	}

	public void AddAttractable(GameObject attractable){
		if(attractables  == null){
			attractables = new List<GameObject> ();
		}
		attractables.Add (attractable);
	}

	// Use this for initialization
	void Start () {
		rigidBody = GetComponent<Rigidbody> ();
		Attractor[] otherCores = GameObject.FindObjectsOfType<Attractor> ();
		foreach(Attractor otherCore in otherCores){
			if(otherCore != this){
				attractables = new List<GameObject> ();
				attractables = otherCore.getAttractablesList ();
				print (attractables.Count);
				break;
			}
		}

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(attractables != null){
		foreach (GameObject attractable in attractables){
			attract (attractable);
		}
		}
	}

	void attract(GameObject objToAttract){
		Rigidbody rbToAttract = objToAttract.GetComponent<Rigidbody> ();

		Vector3 direction = this.rigidBody.position - rbToAttract.position;
		float distance = direction.magnitude;

		if(distance == 0f){
			return;
		}

		float forceMagnitude = grabitationalConstant * (this.rigidBody.mass + rbToAttract.mass) / Mathf.Pow (distance, 2);

		Vector3 force = direction.normalized * forceMagnitude;

		rbToAttract.AddForce (force);
	}
}
