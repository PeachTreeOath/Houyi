using UnityEngine;
using System.Collections;
using Houyi;

public class GroundCheckScript : MonoBehaviour {

	private PlatformerCharacter2D player;

	void Start()
	{
		 player = gameObject.GetComponentInParent<PlatformerCharacter2D>();
	}
	
//	void OnTriggerStay2D (Collider2D other)
//	{
//
//		//if (other.gameObject.tag == "Player") {
//		player.ResetJump();
//		//}
//	}

	void OnTriggerEnter2D (Collider2D other)
	{

		//if (other.gameObject.tag == "Player") {
		player.ResetJump();
		//}
	}
}
