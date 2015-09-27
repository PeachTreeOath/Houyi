using UnityEngine;
using System.Collections;

namespace Houyi
{
	public class PlatformerCharacter2D : MonoBehaviour
	{

		[SerializeField]
		private float speed = 5f;
		[SerializeField]
		private float jumpForce = 40f;
		private Rigidbody2D mRigidBody;
		private bool facingRight;
		[SerializeField]
		public Transform playerGfx;
		private bool grounded;
		public Transform arrowPrefab;

		// Use this for initialization
		void Start ()
		{
			mRigidBody = GetComponent<Rigidbody2D> ();
	
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}

		public void Move (float move, bool jump)
		{
			mRigidBody.velocity = new Vector2 (move * speed, mRigidBody.velocity.y);

			if (move < 0 && !facingRight) {
				Flip ();
			} else if (move > 0 && facingRight) {
				Flip ();
			}
			//Debug.Log (mRigidBody.velocity.y);
			//Debug.Log ("GROUNDED: " + grounded + " JUMP: " + jump);
			//if (grounded && jump) {
			//	grounded = false;
			//	mRigidBody.AddForce (new Vector2 (0f, jumpForce));

			//}
		}

		public void ResetJump ()
		{
			grounded = true;
		}

		private void Flip ()
		{
			facingRight = !facingRight;

			Vector3 theScale = playerGfx.localScale;
			theScale.x *= -1;
			playerGfx.localScale = theScale;
		}
	}
}