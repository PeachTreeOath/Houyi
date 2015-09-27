using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {

	[SerializeField] LayerMask enemyMask;
	[SerializeField] float fireRate = 10;
	[SerializeField] float shotSpeed = 10;
	private float timeToFire = 0;
	public Transform firePoint;
	public GameObject arrowPrefab;
	public GameObject currentProjectile;

	// Use this for initialization
	void Awake () {
		if (firePoint == null) {
			Debug.Log("No fire point found");
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (fireRate == 0) {
			if (Input.GetButtonDown ("Fire1")) {
				Shoot ();
			}
		} else {
			if (Input.GetButton("Fire1") && Time.time > timeToFire)
			{
				timeToFire = Time.time + 1/fireRate;
				Shoot ();
			}
		}
	}

	void Shoot()
	{
		Destroy (currentProjectile);

		GameObject arrow = (GameObject)Instantiate(arrowPrefab, new Vector3(firePoint.transform.position.x, firePoint.transform.position.y, 0), Quaternion.identity);
		ArmRotation arm = GetComponent <ArmRotation>();
		Rigidbody2D rigidBody = arrow.GetComponent<Rigidbody2D> ();
		rigidBody.velocity = new Vector2 (Mathf.Cos(arm.angle2) * shotSpeed, Mathf.Sin(arm.angle2) * shotSpeed);

		currentProjectile = arrow;
	}
}
