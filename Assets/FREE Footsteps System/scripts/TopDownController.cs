using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.AI;

namespace Footsteps {
	[RequireComponent(typeof(Rigidbody), typeof(Animator))]

	public class TopDownController : MonoBehaviour {

		public enum State
		{
			Normal,
			WaitShot,
		}
		[SerializeField] Transform cameraPivot;
		[SerializeField] float jogSpeed = 5f;
		[SerializeField] float rotationSpeed = 270f;
		[SerializeField] float turningOnSpotRotationSpeed = 360f;
		[SerializeField] private State state;
		[SerializeField] private float charaRotateSpeed = 45f;
		[SerializeField] private bool isRotate = false;
		[SerializeField] private float unLockAngle = 1f;
		[SerializeField] TrailRenderer sword;
		Transform thisTransform;
		Animator thisAnimator;
		Rigidbody thisRigidbody;
		NavMeshAgent agent;
		AnimatorStateInfo currentLocomotionInfo;
		Quaternion targetRotation;
		Vector3 movementDirection;
		Vector2 directionalInput;
		public int test = 100;
		public bool casueDamege = true;
		public CapsuleCollider capsuleCollider;
		public GameObject casueDamegeEff;
		private SearchEnemy searchEnemy;
		private Vector3 velocity = Vector3.zero;
		float moveSpeed;
		bool isMoving;
		bool turningOnSpot;
		bool attackMove;

		void Start() {
			thisTransform = transform;
			thisAnimator = GetComponent<Animator>();
			thisRigidbody = GetComponent<Rigidbody>();
			searchEnemy = GetComponentInChildren<SearchEnemy>();
			agent = GetComponent<NavMeshAgent>();

			sword.emitting = false;
			attackMove = true;

			state = State.Normal;

			if (!thisAnimator || !thisRigidbody) {
				//Debug.LogError("Please assign both a rigidbody and an animator to this gameobject, top down controller will not function.");
				enabled = false;
			}
		}

		void FixedUpdate() {
			UpdateAnimator();
			RotateCharacter();
			MoveCharacter();
		}

		void UpdateAnimator() {
			currentLocomotionInfo = thisAnimator.GetCurrentAnimatorStateInfo(0);

			if(attackMove == true)
            {
				directionalInput.x = Input.GetAxisRaw("Horizontal");
				directionalInput.y = Input.GetAxisRaw("Vertical");
				moveSpeed = Mathf.Clamp01(directionalInput.magnitude);
				moveSpeed += (moveSpeed > 0f ? (Input.GetKey(KeyCode.LeftShift) ? 1f : 0f) : 0f);
				isMoving = Input.GetButton("Horizontal") || Input.GetButton("Vertical");

				thisAnimator.SetFloat("move_speed", moveSpeed, 0.3f, Time.fixedDeltaTime);
				thisAnimator.SetBool("move", isMoving);
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
				if (Input.GetButtonDown("Fire1"))
				{
					//searchEnemy.SetNowTarget();
					//SetState(State.WaitShot);
					thisAnimator.SetTrigger("Attack");
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
			if (Input.GetKeyDown(KeyCode.Q))
            {
				thisAnimator.SetTrigger("Avoidance");
            }
        }

        void AttackStart()
        {
			searchEnemy.SetNowTarget();
			SetState(State.WaitShot);
			capsuleCollider.enabled = true;
			attackMove = false;
			casueDamege = true;
        }

		void AttackEnd()
        {
			searchEnemy.DeleteEnemyList();
			capsuleCollider.enabled = false;
			attackMove = true;
			thisAnimator.SetBool("Attack", false);
        }

		public void CauseDamage(Collider damCol)
        {
			if(damCol.gameObject.tag == "Enemy")
            {
				casueDamege = false;
            }
        }

		void MoveCharacter()
		{
			if(attackMove == true)
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

		void EffectOn()
		{
			sword.emitting = true;
		}

		void EffectOff()
        {
			sword.emitting = false;
			thisAnimator.SetFloat("Speed", 1f);
        }
	}
}
