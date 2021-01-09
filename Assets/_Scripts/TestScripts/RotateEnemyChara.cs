using UnityEngine;
using System.Collections;

public class RotateEnemyChara : MonoBehaviour
{

	public enum State
	{
		Normal,
		WaitShot,
	}

	private CharacterController characterController;
	private Animator animator;
	private Vector3 velocity = Vector3.zero;
	[SerializeField] private float walkSpeed = 1.5f;
	[SerializeField] private State state;
	[SerializeField] private float charaRotateSpeed = 45f;
	private SearchEnemy searchEnemy;
	[SerializeField] private bool isRotate = false;
	[SerializeField] private float unLockAngle = 1f;

	[SerializeField] Transform cameraPivot;
	[SerializeField] float jogSpeed = 5f;
	[SerializeField] float rotationSpeed = 270f;
	[SerializeField] float turningOnSpotRotationSpeed = 360f;
	Transform thisTransform;
	Rigidbody thisRigidbody;
	AnimatorStateInfo currentLocomotionInfo;
	Quaternion targetRotation;
	Vector3 movementDirection;
	Vector2 directionalInput;

	float moveSpeed;
	bool turningOnSpot;
	bool isMoving;

	// Use this for initialization
	void Start()
	{
		animator = GetComponent<Animator>();
		characterController = GetComponent<CharacterController>();
		searchEnemy = GetComponentInChildren<SearchEnemy>();

		thisTransform = transform;
		thisRigidbody = GetComponent<Rigidbody>();

		if (!animator || !thisRigidbody)
		{
			//Debug.LogError("Please assign both a rigidbody and an animator to this gameobject, top down controller will not function.");
			enabled = false;
		}

		state = State.Normal;
	}

	void FixedUpdate()
	{
		UpdateAnimator();
		RotateCharacter();
		MoveCharacter();
	}

	void UpdateAnimator()
	{
		if (state == State.Normal)
		{
			if (characterController.isGrounded)
			{
				currentLocomotionInfo = animator.GetCurrentAnimatorStateInfo(0);

				directionalInput.x = Input.GetAxisRaw("Horizontal");
				directionalInput.y = Input.GetAxisRaw("Vertical");
				moveSpeed = Mathf.Clamp01(directionalInput.magnitude);
				moveSpeed += (moveSpeed > 0f ? (Input.GetKey(KeyCode.LeftShift) ? 1f : 0f) : 0f);
				isMoving = Input.GetButton("Horizontal") || Input.GetButton("Vertical");

				// Handle the locomotion animations
				animator.SetFloat("move_speed", moveSpeed, 0.3f, Time.fixedDeltaTime);
				animator.SetBool("move", isMoving);


				if (Input.GetButtonDown("Fire2"))
				{
					searchEnemy.SetNowTarget();
					SetState(State.WaitShot);
				}
			}
		}
		else if (state == State.WaitShot)
		{
			//　ターゲットを自動で変更する処理
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
					animator.SetFloat("Speed", 0f);
				}
			}

			if (!Input.GetButton("Fire2"))
			{
				SetState(State.Normal);
			}
		}

		velocity.y += Physics.gravity.y * Time.deltaTime;
		characterController.Move(velocity * Time.deltaTime);
	}

	void MoveCharacter()
	{
		Vector3 velocity = thisTransform.forward * moveSpeed * jogSpeed;
		velocity.y = thisRigidbody.velocity.y;
		thisRigidbody.velocity = velocity;
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
			animator.SetFloat("Speed", 0f);
		}
	}

	public State GetState()
	{
		return state;
	}
	//　回転中かどうかを返す
	public bool IsRotate()
	{
		return isRotate;
	}
}
