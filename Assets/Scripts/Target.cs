using UnityEngine;
using System.Collections;

[RequireComponent( typeof( Collider ) )]
[RequireComponent( typeof( Renderer) )]
[RequireComponent( typeof( FollowTarget) )]
[RequireComponent( typeof( Rigidbody ) )]
public class Target : MonoBehaviour {

	private Transform imageTarget;

	public Material punchMaterial;
	public Material kickMaterial;

	public Transform explosionPrefab;

	private TargetType targetType;


	void Awake(){
		imageTarget = GameObject.FindWithTag("Image").transform;
	}

	// Use this for initialization
	void Start () {
		SetPosition ();			// Set position
		ConfigureTarget ();		// Configure target properties
	}
	
	// Update is called once per frame
	void Update () {
		//Rotate the cube at fixed rate
		transform.Rotate (new Vector3 (15, 30, 45) * Time.deltaTime);
	}

	void OnDestroy(){
		//Create an explosion after cube is destroyed
		ConfigureExplosion();
	}

	/// <summary>
	/// Sets the position.
	/// </summary>
	private void SetPosition(){
		// Calculate fixed position on unit circle at unit height
		const float UNIT_HEIGHT = 1.0f;
		Vector3 randomPos = PositionAtFixedHeight( Random.insideUnitCircle.normalized, UNIT_HEIGHT);

		// Set gameobject position 
		GetComponent<FollowTarget> ().offset = randomPos;
		GetComponent<FollowTarget> ().target = imageTarget;
	}

	/// <summary>
	/// Adjusts position to fixed height.
	/// </summary>
	/// <returns>The at fixed height.</returns>
	/// <param name="pos">Position.</param>
	/// <param name="height">Height.</param>
	private Vector3 PositionAtFixedHeight( Vector2 pos, float height ){
		return new Vector3 (pos.x, height, pos.y);
	}

	/// <summary>
	/// Configures the explosion.
	/// </summary>
	private void ConfigureExplosion(){
		Transform explosion = Instantiate (explosionPrefab, transform.position, Quaternion.identity) as Transform;

		if (targetType == TargetType.Punch) {
			explosion.GetComponent<ParticleSystem> ().startColor = punchMaterial.color;
		} 
		else {
			explosion.GetComponent<ParticleSystem> ().startColor = kickMaterial.color;
		}
	}

	/// <summary>
	/// Configure this instance.
	/// </summary>
	private void ConfigureTarget(){
		SetTargetType ();

		if (targetType == TargetType.Punch) {
			GetComponent<Renderer> ().sharedMaterial = punchMaterial;
			gameObject.layer = LayerMask.NameToLayer ("Punch");
		} 
		else {
			GetComponent<Renderer> ().sharedMaterial = kickMaterial;
			gameObject.layer = LayerMask.NameToLayer ("Kick");
		}
	}

	/// <summary>
	/// Sets the target type.
	/// </summary>
	/// <param name="t">T.</param>
	public void SetTargetType(){
		const int NUM_TARGETS = 2;
		int index = Random.Range (0, NUM_TARGETS);
		targetType = (TargetType)index;
	}
		
}

//Different types of target
public enum TargetType{
	Punch = 0,
	Kick = 1
}
