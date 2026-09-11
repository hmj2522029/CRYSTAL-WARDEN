using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetTracking : MonoBehaviour
{
	[SerializeField] float m_speed;			//移動速度
	[SerializeField] Transform m_target;	//追従するオブジェクト

	private Vector2 m_dir;          //ターゲットの方向
	private Vector2 m_inputDir;		//入力方向
	private float m_currentSpeed;   //現在の速度
	private bool m_isMove = true;	//移動しているか

	public Vector2 InputDir => m_inputDir;

	public float Speed => m_currentSpeed;

	public bool IsMove => m_isMove;


	private void Update()
	{
		//ターゲットが設定されていない場合は処理を行わない
		if (m_target == null) return;

		//ターゲットの方向を計算
		m_dir = (m_target.position - transform.position).normalized;

	}

	private void FixedUpdate()
	{

		//ターゲットとの距離が1.5以上の場合のみ移動する
		if ((m_target.position - transform.position).magnitude > 1.5)
		{

			m_inputDir = m_dir;
			m_currentSpeed = m_speed;
			m_isMove = true;

		}
		else
		{
			m_inputDir = Vector2.zero;
			m_isMove = false;
			m_currentSpeed = 0;
		}

	}

	public void SetTarget(Transform transform)
	{
		m_target = transform;
	}


}
