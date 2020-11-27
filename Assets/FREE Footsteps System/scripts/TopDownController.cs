using UnityEngine;
using System.Collections;

namespace Footsteps {

	[RequireComponent(typeof(Rigidbody), typeof(Animator))]
	public class TopDownController : MonoBehaviour {
 
		Animator thisAnimator;
		Rigidbody thisRigidbody;

		Vector2 directionalInput;
		float moveSpeed;
		bool isMoving;
		/*private float isRunning;
		private float isMoving;
		private bool isAttack;*/
		public CapsuleCollider capsuleCollider;


		void Start() {
			thisAnimator = GetComponent<Animator>();
			thisRigidbody = GetComponent<Rigidbody>();

			if(!thisAnimator || !thisRigidbody) {
				//Debug.LogError("Please assign both a rigidbody and an animator to this gameobject, top down controller will not function.");
				enabled = false;
			}
		}

		void FixedUpdate() {
			UpdateAnimator();
			//print(directionalInput);
		}

		void UpdateAnimator() {
			// Get player input
			directionalInput.x = Input.GetAxisRaw("Horizontal");
			directionalInput.y = Input.GetAxisRaw("Vertical");
			moveSpeed = Mathf.Clamp01(directionalInput.magnitude);
			moveSpeed += (moveSpeed > 0f ? (Input.GetKey(KeyCode.LeftShift) ? 1f : 0f) : 0f);
			isMoving = Input.GetButton("Horizontal") || Input.GetButton("Vertical");

			// Handle the locomotion animations
			thisAnimator.SetFloat("move_speed", moveSpeed, 0.3f, Time.fixedDeltaTime);
			thisAnimator.SetBool("move", isMoving);

            //追加
            if (Input.GetMouseButtonDown(0))
            {
				thisAnimator.SetBool("Attack", true);
            }
		}
		void AttackStart()
        {
			capsuleCollider.enabled = true;
        }

		void AttackEnd()
        {
			capsuleCollider.enabled = false;
			thisAnimator.SetBool("Attack", false);
        }
	}
}
