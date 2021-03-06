using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

	namespace Footsteps
{
	[RequireComponent(typeof(Rigidbody), typeof(Animator))]

	public class PlayerController : MonoBehaviour
	{
		public enum State
		{
			Normal,
			WaitShot,
		}
		[SerializeField] Transform cameraPivot;
		[SerializeField] private State state;
		[SerializeField] float jogSpeed = 5f;
		[SerializeField] float rotationSpeed = 270f;
		[SerializeField] private float unLockAngle = 1f;
		[SerializeField] private float charaRotateSpeed = 45f;
		[SerializeField] float turningOnSpotRotationSpeed = 360f;
		[SerializeField] private bool isRotate = false;
		[SerializeField] GameObject shield;
		
		Transform thisTransform;
		Animator thisAnimator;
		Rigidbody thisRigidbody;
		GameObject bom;

		AnimatorStateInfo currentLocomotionInfo;
		Quaternion targetRotation;
		Vector3 movementDirection;
		Vector2 directionalInput;
		Vector3 velocity = Vector3.zero;

		public GameObject pampkinBom;
		public GameObject smoke;
		public GameObject shieldBrokenEff;
		public Transform pampkinPos;
		private SearchEnemy searchEnemy;


		float moveSpeed;
		float shieldColor = 0;
		bool turningOnSpot;
		bool isMoving;
		bool attackMove = true;
		public bool shieldOn;
		public bool shieldAnim;

		void Start()
		{
			thisTransform = transform;
			thisAnimator = GetComponent<Animator>();
			thisRigidbody = GetComponent<Rigidbody>();
			searchEnemy = GetComponentInChildren<SearchEnemy>();
			
			state = State.Normal;
			shield.SetActive(false);
			
			if (!thisAnimator || !thisRigidbody)
			{
				//Debug.LogError("Please assign both a rigidbody and an animator to this gameobject, top down controller will not function.");
				enabled = false;
			}
		}

		void FixedUpdate()
		{
			UpdateAnimator();
			RotateCharacter();
			MoveCharacter();
		}

		void UpdateAnimator()
		{
			currentLocomotionInfo = thisAnimator.GetCurrentAnimatorStateInfo(0);

            if (attackMove)
            {
				directionalInput.x = Input.GetAxisRaw("Horizontal");
				directionalInput.y = Input.GetAxisRaw("Vertical");
				//moveSpeed += (moveSpeed > 0f ? (Input.GetKey(KeyCode.LeftShift) ? 1f : 0f) : 0f);
				isMoving = Input.GetButton("Horizontal") || Input.GetButton("Vertical");
				thisAnimator.SetFloat("move_speed", moveSpeed, 0.3f, Time.fixedDeltaTime);
				thisAnimator.SetBool("move", isMoving);

				moveSpeed = Mathf.Clamp01(directionalInput.magnitude);
				if (shieldAnim == true && moveSpeed > 0)
				{
					moveSpeed -= 0.5f;
					//moveSpeed += (moveSpeed > 0f ? (Input.GetKey(KeyCode.LeftShift) ? 1f : 0f) : 0f);
				}
			}
		}

        private void Update()
        {
			if (EventSystem.current.IsPointerOverGameObject())
			{
				return;
			}

			if (state == State.Normal)
			{
				if (Input.GetButtonDown("Fire1") || Input.GetKeyDown(KeyCode.X))
				{
					thisAnimator.SetTrigger("attack");
				}
			}
			else if (state == State.WaitShot)
			{
				if (searchEnemy.GetNowTarget())
				{
					isRotate = true;
					//　キャラクターの向きを変える
					var targetRotation = Quaternion.LookRotation(searchEnemy.GetNowTarget().transform.position - transform.position);
					targetRotation = Quaternion.Euler(0f, targetRotation.eulerAngles.y, 0f);
					transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, charaRotateSpeed * Time.deltaTime);

					//　ロックを解除する条件
					if (Mathf.Abs(transform.eulerAngles.y - Quaternion.LookRotation(searchEnemy.GetNowTarget().transform.position - transform.position).eulerAngles.y) < unLockAngle)
					{
						isRotate = false;
					}
				}

				if (!Input.GetButton("Fire1"))
				{
					SetState(State.Normal);
				}
			}

            if (Input.GetKey(KeyCode.LeftShift))
			{
				shieldAnim = true;
			}

            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
				shieldOn = true;
				shield.SetActive(true);
				shieldColor = 0.7f;
            }

			if (Input.GetKeyUp(KeyCode.LeftShift))
			{
				shieldOn = false;
				shieldAnim = false;
			}

			if (shieldOn)
			{
				shield.GetComponent<Renderer>().material.color = new Color(0, 0, 0, shieldColor);
				shieldColor -= Time.deltaTime * 0.15f;
				if (shieldColor < 0.1)
				{
					shieldColor = 0;
					shieldOn = false;
				}
			}
			else if (!shieldOn || !shieldAnim)
			{
				shield.SetActive(false);
			}
		}

        void MoveCharacter()
		{
            if (attackMove)
            {
				Vector3 velocity = thisTransform.forward * moveSpeed * jogSpeed;
				velocity.y = thisRigidbody.velocity.y;
				thisRigidbody.velocity = velocity;
            }
            else
            {
				this.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
				this.transform.rotation = transform.rotation;
			}
		}

		void RotateCharacter()
		{
			movementDirection = cameraPivot.right * directionalInput.x + cameraPivot.forward * directionalInput.y;
			bool inIdle = currentLocomotionInfo.IsName("idle");
			float deltaAngle = 0f;
			float targetRotationSpeed = rotationSpeed;

			if (turningOnSpot) targetRotationSpeed = turningOnSpotRotationSpeed;

			if (inIdle)
			{
				Vector3 targetDirection = new Vector3(movementDirection.x, 0f, movementDirection.z);
				deltaAngle = Vector3.Angle(targetDirection, transform.forward);
				float angleSign = Mathf.Sign(Vector3.Cross(transform.forward, targetDirection).y);
				deltaAngle *= angleSign;
			}

			turningOnSpot = Mathf.Abs(deltaAngle) > 30f && inIdle;

			if (movementDirection != Vector3.zero)
			{
				targetRotation = Quaternion.LookRotation(movementDirection);
				thisTransform.rotation = Quaternion.RotateTowards(thisTransform.rotation, targetRotation, Time.deltaTime * targetRotationSpeed);
			}

		}
		public void SetState(State state)
		{
			this.state = state;
			velocity = Vector3.zero;

			if (state == State.WaitShot)
			{
				thisAnimator.SetFloat("move_speed", 0f);
			}
		}

		public State GetState()
		{
			return state;
		}

		public bool IsRotate()
		{
			return isRotate;
		}

		void AttackStart()
		{
			searchEnemy.SetNowTarget();
			SetState(State.WaitShot);
			attackMove = false;
			shieldAnim = false;
		}

		void AttackEnd()
		{
			searchEnemy.DeleteEnemyList();
			attackMove = true;
			thisAnimator.SetBool("Attack", false);
		}

		public void ShieldDestroy(Collider col)
        {
			if(col.gameObject.CompareTag("EnemyCollider"))
            {
				Instantiate(shieldBrokenEff, new Vector3(this.transform.position.x, this.transform.position.y + 1f, this.transform.position.z), Quaternion.identity);
				shieldOn = false;
            }
        }

		void Spone()
        {
			var smokeEff = Instantiate(smoke, pampkinPos);
			Destroy(smokeEff, 2f);
			Invoke("PampSpone", 0.02f);
        }

		void PampSpone()
        {
			bom = Instantiate(pampkinBom, pampkinPos);
			Invoke("ParentNull", 0.35f);
        }

		void ParentNull()
        {
			bom.transform.parent = null;
		}

		void WalkStart()
        {
			thisAnimator.applyRootMotion = true;
        }
	}
}