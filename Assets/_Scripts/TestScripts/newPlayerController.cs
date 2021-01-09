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
	private Vector3 velocity = Vector3.zero;
	[SerializeField]
	private float walkSpeed = 1.5f;
	[SerializeField]
	private State state;
	//　キャラの回転スピード
	[SerializeField]
	private float charaRotateSpeed = 45f;
	//　敵サーチスクリプト
	private SearchEnemy searchEnemy;
	//　回転中かどうか
	[SerializeField]
	private bool isRotate = false;
	//　敵の方向を向いたとする角度
	[SerializeField]
	private float unLockAngle = 1f;

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
				if (Input.GetButtonDown("Fire2"))
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
					animator.SetFloat("Speed", 0f);
				}
			}

			if (!Input.GetButton("Fire2"))
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
