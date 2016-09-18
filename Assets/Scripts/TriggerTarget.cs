using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(Collider))]
public class TriggerTarget : MonoBehaviour {

	public Transform targetPrefab;
	private ScoreManager scoreManager;


	void Awake(){
		scoreManager = GameObject.FindObjectOfType<ScoreManager> ();
	}

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnTriggerEnter( Collider other ){
		if (other.gameObject.CompareTag ("Target")) {
			Destroy (other.gameObject);			// Destroy target
			scoreManager.IncrementScore ();		// Add score
			Invoke ("CreateTarget", 1.0f); 		// Create new target after 1 second
		}
	}

	/// <summary>
	/// Creates a new target.
	/// </summary>
	void CreateTarget(){
		Instantiate (targetPrefab, Vector3.zero, Quaternion.identity);
	}
		
}
