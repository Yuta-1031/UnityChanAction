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
		TwoBoneIKConstraint r_ArmRig;
		bool armMotion;

		Vector2 directionalInput;
		float moveSpeed;
		bool isMoving;

		effect script;
		public GameObject Hal_AttackEffect;

		public float nowPosi;

		void Start()
		{
			nowPosi = this.transform.position.y;
			thisAnimator = GetComponent<Animator>();
			thisRigidbody = GetComponent<Rigidbody>();

			if (!thisAnimator || !thisRigidbody)
			{
				//Debug.LogError("Please assign both a rigidbody and an animator to this gameobject, top down controller will not function.");
				enabled = false;
			}
		}

		void FixedUpdate()
		{
			UpdateAnimator();
		}

		void UpdateAnimator()
		{

			// Get player input
			directionalInput.x = Input.GetAxisRaw("Horizontal");
			directionalInput.y = Input.GetAxisRaw("Vertical");
			moveSpeed = Mathf.Clamp01(directionalInput.magnitude);
			moveSpeed += (moveSpeed > 0f ? (Input.GetKey(KeyCode.LeftShift) ? 1f : 0f) : 0f);
			isMoving = Input.GetButton("Horizontal") || Input.GetButton("Vertical");

			// Handle the locomotion animations
			thisAnimator.SetFloat("move_speed", moveSpeed, 0.3f, Time.fixedDeltaTime);
			thisAnimator.SetBool("move", isMoving);

			this.r_ArmRig = GameObject.Find("R_ArmConstraint").GetComponent<TwoBoneIKConstraint>();

			if (Input.GetMouseButtonDown(0))
			{
				thisAnimator.SetBool("Attack", true);
				armMotion = true;
			}

			if (armMotion == true)
			{
				r_ArmRig.weight = 0f;
				//Debug.Log("true");
			}
			if (armMotion == false)
			{
				r_ArmRig.weight = 1.0f;
				//Debug.Log("false");
			}

			//transform.position = new Vector3(transform.position.x, nowPosi + Mathf.PingPong(Time.deltaTime/5, 0.3f), transform.position.z);
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