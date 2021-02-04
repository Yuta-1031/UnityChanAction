using UnityEngine;
using System.Collections;
using UnityEngine.Animations.Rigging;

namespace Footsteps
{

	[RequireComponent(typeof(Rigidbody), typeof(Animator))]
	public class Hal_UnityChanController : MonoBehaviour
	{

		Animator thisAnimator;
		Rigidbody thisRigidbody;
		bool armMotion;

		Vector2 directionalInput;
		float moveSpeed;
		bool isMoving;

		effect script;
		public GameObject Hal_AttackEffect;
		public float nowPosi;
		public float move_Y;
		public float delay;
		public float time;

		private float t_Up;

		void Start()
		{
			nowPosi = this.transform.position.y;
			thisAnimator = GetComponent<Animator>();
			thisRigidbody = GetComponent<Rigidbody>();

			//iTween.MoveAdd(gameObject, iTween.Hash("Y", move_Y, "time", time, "delay", delay, "loppType", "pingPong"));

			if (!thisAnimator || !thisRigidbody)
			{
				//Debug.LogError("Please assign both a rigidbody and an animator to this gameobject, top down controller will not function.");
				enabled = false;
			}

			this.t_Up = 8f;
		}


		void FixedUpdate()
		{
			UpdateAnimator();
		}

        private void OnCollisionEnter(Collision collision)
        {
            if(collision.gameObject.tag == "Floor")
            {
				this.t_Up = 8f;
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if(other.gameObject.tag == "Ceiling")
            {
				this.t_Up = 0;
            }
        }

		void UpdateAnimator()
		{

			thisRigidbody.AddForce(transform.up * t_Up, ForceMode.Force);

			// Get player input
			directionalInput.x = Input.GetAxisRaw("Horizontal");
			directionalInput.y = Input.GetAxisRaw("Vertical");
			moveSpeed = Mathf.Clamp01(directionalInput.magnitude);
			moveSpeed += (moveSpeed > 0f ? (Input.GetKey(KeyCode.LeftShift) ? 1f : 0f) : 0f);
			isMoving = Input.GetButton("Horizontal") || Input.GetButton("Vertical");

			// Handle the locomotion animations
			thisAnimator.SetFloat("move_speed", moveSpeed, 0.3f, Time.fixedDeltaTime);
			thisAnimator.SetBool("move", isMoving);


			if (Input.GetMouseButtonDown(0))
			{
				thisAnimator.SetBool("Attack", true);
				armMotion = true;
			}
		}

		void AttackStart()
		{
			this.armMotion = true;
		}


		void Attackend()
		{
			this.armMotion = false;
			//thisAnimator.SetBool("Attack", false);
			//Invoke("MotionEnd", 2f);
		}

		void Attack3End()
		{
			this.armMotion = false;
			thisAnimator.SetBool("Attack", false);

		}

		void AttackEffect()
		{
			script = Hal_AttackEffect.GetComponent<effect>();
			script.Effect();
		}
	}
}