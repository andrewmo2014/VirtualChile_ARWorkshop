using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animator))]
public class PlayerController : MonoBehaviour
{

	private Animator anim;					
	private AnimatorStateInfo currentState;
	private AnimatorStateInfo previousState;

	private Transform target;
	public float speed = 4.0f;


	// Use this for initialization
	void Start ()
	{
		anim = GetComponent<Animator> ();
		currentState = anim.GetCurrentAnimatorStateInfo (0);
		previousState = currentState;
	}

	void FixedUpdate(){
		if (target != null) {

			//Calculate final rotation based on target and player positions
			Vector3 direction = target.position - transform.position;
			direction.y = 0.0f;
			Quaternion targetRot 	= Quaternion.LookRotation(direction);

			//Rotate the player with smooth linear interpolation
			transform.rotation	= Quaternion.Slerp(transform.rotation, targetRot, Time.deltaTime * speed);

		} else {

			//Set target variable
			GameObject targetRef = GameObject.FindGameObjectWithTag ("Target");
			if( targetRef != null )
				target = targetRef.transform;
		}
	}

	// Update is called once per frame
	void Update () {
		// Punch when Press "P"
		if( Input.GetKeyDown(KeyCode.P) ){
			Punch();
		}
		// Kick when Press "K"
		if( Input.GetKeyDown(KeyCode.K) ){
			Punch();
		}
	}

	/// <summary>
	/// Set punch animation to true
	/// </summary>
	public void Punch(){
		anim.SetBool ("Jab", true);
	}

	/// <summary>
	/// Set kick animation to true
	/// </summary>
	public void Kick(){
		anim.SetBool ("Hikick", true);
	}
}
