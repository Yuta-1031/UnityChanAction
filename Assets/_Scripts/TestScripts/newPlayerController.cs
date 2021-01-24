using UnityEngine;
using System.Collections;

public class newPlayerController : MonoBehaviour
{

	public enum State
	{
		Normal,
		WaitShot,
	}

	private Animator animator;
	private SearchEnemy searchEnemy;
	private Vector3 velocity = Vector3.zero;
	[SerializeField] private State state;
	[SerializeField] private float charaRotateSpeed = 45f;
	[SerializeField] private bool isRotate = false;
	[SerializeField] private float unLockAngle = 1f;

	// Use this for initialization
	void Start()
	{
		animator = GetComponent<Animator>();
		searchEnemy = GetComponentInChildren<SearchEnemy>();

		state = State.Normal;
	}

	// Update is called once per frame
	void Update()
	{
		if (state == State.Normal)
		{
				if (Input.GetButtonDown("Fire1"))
				{
					searchEnemy.SetNowTarget();
					SetState(State.WaitShot);
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
				}
			}

			if (!Input.GetButton("Fire1"))
			{
				SetState(State.Normal);
			}
		}

		//velocity.y += Physics.gravity.y * Time.deltaTime;
		
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
