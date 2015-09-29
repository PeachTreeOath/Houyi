using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ApolloAI : MonoBehaviour {

	[SerializeField]
	private int hp = 10;
	private float speed = 5f;
	private Rigidbody2D mRigidBody;
	private string[] layers = {"Trash", "Default"};
	private bool invincible = false;
	public Text textHP;
	public float stopL;
	public float stopR;
	
	// Use this for initialization
	void Start () {
		mRigidBody = GetComponent<Rigidbody2D> ();
		mRigidBody.velocity = new Vector2 (speed, 0);
		textHP.text = "Enemy HP: " + hp;
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (!invincible) {

			if(col.name == "Arrow(Clone)")
			{
				ArrowScript arrow = col.GetComponent<ArrowScript>();
				hp -= arrow.getDamage();
				if(hp <= 0)
				{
					Application.LoadLevel("s2");
				}
				Destroy (col.gameObject);
				textHP.text = "Enemy HP: " + hp;
				StartCoroutine(Flash(.5f, 0.05f));
			}
		}
	}

	// Update is called once per frame
	void Update () {

		if (mRigidBody.velocity.x >= 0 && transform.position.x > stopR) {
			mRigidBody.velocity = new Vector2 (-mRigidBody.velocity.x, 0);
			transform.localScale = new Vector3(-transform.localScale.x,transform.localScale.y,transform.localScale.z);
		}
		else if(mRigidBody.velocity.x < 0 && transform.position.x < stopL) {
			mRigidBody.velocity = new Vector2 (-mRigidBody.velocity.x, 0);
			transform.localScale = new Vector3(-transform.localScale.x,transform.localScale.y,transform.localScale.z);
		}
	}

	IEnumerator Flash(float time, float intervalTime)
	{
		invincible = true;
		float elapsedTime = 0f;
		int index = 0;
		while(elapsedTime < time )
		{
			GetComponent<SpriteRenderer>().sortingLayerName = layers[index % 2];
			
			elapsedTime += Time.deltaTime;
			index++;
				yield return new WaitForSeconds(intervalTime);
		}
		GetComponent<SpriteRenderer>().sortingLayerName = "Default";
		invincible = false;
	}
}

