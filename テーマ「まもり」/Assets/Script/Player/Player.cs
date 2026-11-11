using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	[SerializeField] float m_speed;					//速度

	private PlayerAnimation m_playerAnimation;		//アニメーション
	private PlayerInput m_playerInput;				//入力
	private Movement m_movement;					//移動
	private Health m_health;						//HP
	private AttackController m_attackController;    //攻撃

	private bool m_isDeath = false;		//死んでいるか
	private bool m_isRight = false;		//方向(左右方向の二方向限定だから)

	private void Awake()
	{

		m_playerAnimation = GetComponent<PlayerAnimation>();
		m_playerInput = GetComponent<PlayerInput>();
		m_movement = GetComponent<Movement>();
		m_attackController = GetComponent<AttackController>();
		m_health = GetComponentInChildren<Health>();

	}

	private void Update()
	{
		if (m_isDeath) return;

		//死んだら死亡アニメーションの再生
		if (m_health.IsDeath && !m_isDeath)
		{
			m_isDeath = m_health.IsDeath;
			m_playerAnimation.DeathAnime();

			m_movement.Stop();

			return;
		}

		//左右方向の判定
		if (m_playerInput.Input.x > 0)
		{
			m_isRight = true;
		}
		else if (m_playerInput.Input.x < 0)
		{
			m_isRight = false;
		}
		

		//入力有効の時
		if (!m_playerInput.IgnoreInputMove)
		{
			//移動
			m_movement.Move(m_playerInput.Input, m_speed);

			//移動アニメーション
			m_playerAnimation.MoveAnime(m_playerInput.Input);

			//方向
			m_attackController.SetDirection(m_isRight);

		}
		//入力無効の時
		else if(m_playerInput.IgnoreInputMove)
		{
			//動きを止める
			m_movement.Stop();
		}

		//剣攻撃アニメーション
		if(m_playerInput.SwordAttackDown && !m_playerAnimation.CanMoveAttack)
		{
			//剣攻撃アニメーション1
			if (m_playerInput.MoveInputTime < 0.5f)
			{
				m_playerAnimation.SwordAttackAnime1();
				m_attackController.SelectAttack(PlayerAttackIds.SwordHorizontalSlash);		
			}
			//剣攻撃アニメーション2
			else
			{
				m_playerAnimation.SwordAttackAnime2();
				m_attackController.SelectAttack(PlayerAttackIds.SwordDownwardSlash);     
			}

		}
		//弓攻撃アニメーション
		else if(m_playerInput.BowAttackDown && !m_playerAnimation.CanMoveAttack)
		{
			m_playerAnimation.BowAttackAnime();
			m_attackController.SelectAttack(PlayerAttackIds.RapidShot);     
		}

	}

}
