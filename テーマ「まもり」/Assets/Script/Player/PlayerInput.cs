using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{

	[SerializeField] InputAction m_swordAttack;	//剣攻撃入力
	[SerializeField] InputAction m_bowAttack;	//弓攻撃入力

	private Vector2 m_input;		//プレイヤーを動かすための入力
	private bool m_ignoreInputMove; //Move入力を無視
	private float m_moveInputTime;	//Moveの入力されていた時間

	public float MoveInputTime => m_moveInputTime;

	public Vector2 Input => m_input;

	public bool IgnoreInputMove => m_ignoreInputMove;
	
	public bool SwordAttackDown => m_swordAttack.WasPressedThisFrame();

	public bool BowAttackDown => m_bowAttack.WasPressedThisFrame();

	//プレイヤーを動かすための入力を取得する
	public void OnMove(InputAction.CallbackContext context)
	{
		m_input = context.ReadValue<Vector2>();
	}

	private void Update()
	{
		if(m_input.magnitude > 0.1)
		{
			m_moveInputTime += Time.deltaTime;
		}
		else if(m_input.magnitude < 0.1)
		{
			m_moveInputTime = 0;
		}
	}

	private void OnEnable()
	{
		m_swordAttack.Enable();
		m_bowAttack.Enable();
	}

	private void OnDisable()
	{
		m_swordAttack.Disable();
		m_bowAttack.Disable();
	}

	//アニメーションのイベントで呼ぶ
	public void InputDisabled()
	{
		m_ignoreInputMove = true;
	}

	//アニメーションのイベントで呼ぶ
	public void InputEnabled()
	{
		m_ignoreInputMove = false;
	}

}
