using UnityEngine;
using System.Collections;

[RequireComponent( typeof ( AudioSource ) )]
public class PlayOnce : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GetComponent<AudioSource> ().Play ();	//Play audio sound
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
