using UnityEngine;
using System.Collections;

public class FollowTarget : MonoBehaviour {

	public Transform target;
	public Vector3 offset = new Vector3(0f, 0f, 0f);


	private void LateUpdate()
	{
		if (target != null) {
			transform.position = target.position + offset;
		}

	}
}
