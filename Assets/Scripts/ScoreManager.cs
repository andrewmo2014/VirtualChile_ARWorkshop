using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent (typeof( Text ) )]
public class ScoreManager : MonoBehaviour {

	private Text scoreText;
	private int score;


	void Awake(){
		scoreText = GetComponent<Text> ();
		score = 0;
	}

	// Use this for initialization
	void Start () {
		SetScore ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	/// <summary>
	/// Increments the score.
	/// </summary>
	public void IncrementScore(){
		score++;
		SetScore ();
	}

	/// <summary>
	/// Sets the score.
	/// </summary>
	private void SetScore (){
		scoreText.text = "Score: " + score.ToString ();
	}
}
