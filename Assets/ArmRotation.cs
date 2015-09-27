using UnityEngine;
using System.Collections;

public class ArmRotation : MonoBehaviour {

	public Vector3 angle;
	public float angle2;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 difference = Camera.main.ScreenToWorldPoint (Input.mousePosition) - transform.position;
		difference.Normalize ();
		angle2 = Mathf.Atan2 (difference.y, difference.x);
		float rotZ = Mathf.Atan2 (difference.y, difference.x) * Mathf.Rad2Deg;
		angle = difference;

		transform.rotation = Quaternion.Euler(0f, 0f, rotZ);
	}

	public Vector3 getAngle()
	{
		return angle;
	}
}
