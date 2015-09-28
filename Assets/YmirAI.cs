using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class YmirAI : MonoBehaviour {

	[SerializeField]
	private int hp = 10;
	private Rigidbody2D mRigidBody;
	private string[] layers = {"Trash", "Default"};
	private float timeSincePort;
	private bool invincible = false;
	public Text textHP;
	public float blinkSpeed;
	private int state = 0;
	public Vector3 loke1;
	public Vector3 loke2;
	public Vector3 loke3;
	public Vector3 loke4;

	// Use this for initialization
	void Start () {
		textHP.text = "Enemy HP: " + hp;
		timeSincePort = Time.time;
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
					Application.LoadLevel("GameOver");
				}
				Destroy (col.gameObject);
				textHP.text = "Enemy HP: " + hp;
				StartCoroutine(Flash(.5f, 0.05f));
			}
		}
	}

	// Update is called once per frame
	void Update () {
		if (Time.time - timeSincePort > blinkSpeed) {
			state++;
			if(state == 4) state = 0;
			Vector3 position = new Vector3(0,0,0);
			switch(state)
			{
			case 0:
				position = loke1;
				break;
			case 1:
				position = loke2;
				break;
			case 2:
				position = loke3;
				break;
			case 3:
				position = loke4;
				break;
			}
			transform.localScale = new Vector3(-transform.localScale.x,transform.localScale.y,transform.localScale.z);
			transform.position = position;
			timeSincePort = Time.time;
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



