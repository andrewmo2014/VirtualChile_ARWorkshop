using UnityEngine;
using System.Collections;

public class DestroyAfter : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Destroy (gameObject, 1.0f);		//Destroy object after 1 second
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
