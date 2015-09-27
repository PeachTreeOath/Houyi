using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ArrowScript : MonoBehaviour {

	private int level = 1;
	public float widthChange;
	private Text textPower;

	// Use this for initialization
	void Start () {
		textPower = (Text)GameObject.Find ("Text Power").GetComponent<Text> ();
		textPower.text = "Arrow Dmg: " + level;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public int getDamage()
	{
		return level;
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		level++;
		if (level == 11) {
			textPower.text = "Arrow Dmg: 0";
			Destroy (this.gameObject);
			return;
		}
		TrailRenderer trail = (TrailRenderer)GetComponent<TrailRenderer> ();
		trail.startWidth += widthChange;
		textPower.text = "Arrow Dmg: " + level;
	}
}
