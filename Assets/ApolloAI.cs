using UnityEngine;
using System.Collections;

public class ApolloAI : MonoBehaviour {

	[SerializeField]
	private float speed = 5f;
	private Rigidbody2D mRigidBody;
	private Material mat;
	private Color[] colors = {Color.yellow, Color.red};
	private Color origColor;
	private bool isColliderEnable = true;

	void Awake()
	{
		mat = GetComponent<SpriteRenderer>().material;
		origColor = mat.color;
	}

	// Use this for initialization
	void Start () {
		mRigidBody = GetComponent<Rigidbody2D> ();
		mRigidBody.velocity = new Vector2 (speed, 0);

	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (isColliderEnable) {

			if(col.name == "Arrow(Clone)")
			{
				Destroy (col.gameObject);
				StartCoroutine(Flash(.5f, 0.05f));
			}
		}
	}

	// Update is called once per frame
	void Update () {

		if (mRigidBody.velocity.x >= 0 && Camera.main.WorldToScreenPoint(new Vector3(transform.position.x,0f,0f)).x > 475) {
			mRigidBody.velocity = new Vector2 (-mRigidBody.velocity.x, 0);
			transform.localScale = new Vector3(-transform.localScale.x,transform.localScale.y,transform.localScale.z);
		}
		else if(mRigidBody.velocity.x < 0 && Camera.main.WorldToScreenPoint(new Vector3(transform.position.x,0f,0f)).x < 150) {
			mRigidBody.velocity = new Vector2 (-mRigidBody.velocity.x, 0);
			transform.localScale = new Vector3(-transform.localScale.x,transform.localScale.y,transform.localScale.z);
		}
	}

	IEnumerator Flash(float time, float intervalTime)
	{
		float elapsedTime = 0f;
		int index = 0;
		while(elapsedTime < time )
		{
			mat.color = colors[index % 2];
			
			elapsedTime += Time.deltaTime;
			index++;
				yield return new WaitForSeconds(intervalTime);
		}
		mat.color = origColor;
	}
}
