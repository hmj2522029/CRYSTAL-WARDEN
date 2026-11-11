using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAnimation : MonoBehaviour
{

	private Animator m_anime;
	private SpriteRenderer m_spriteRenderer;

	private bool m_canMoveAttack = false;    //攻撃アニメーションしているかどうか

	public bool CanMoveAttack => m_canMoveAttack;

	private void Awake()
	{
		m_anime = GetComponent<Animator>();
		m_spriteRenderer = GetComponent<SpriteRenderer>();
	}

	public void MoveAnime(Vector2 input)
	{
		m_anime.SetFloat("Input", input.magnitude);

		//X方向での画像反転
		if(input.x > 0 )
		{
			m_spriteRenderer.flipX = false;
		}
		else if(input.x < 0 )
		{
			m_spriteRenderer.flipX = true;
		}
		
	}

	public void SwordAttackAnime1()
	{
		m_anime.SetInteger("AttackType", 1);
		m_anime.SetTrigger("Attack");

	}

	public void SwordAttackAnime2()
	{
		m_anime.SetInteger("AttackType", 2);
		m_anime.SetTrigger("Attack");
	}

	public void BowAttackAnime()
	{

		m_anime.SetInteger("AttackType", 3);
		m_anime.SetTrigger("Attack");

	}

	public void HurtAniem()
	{
		m_anime.SetTrigger("isHit");
	}

	public void DeathAnime()
	{
		m_anime.SetTrigger("isDeath");
	}

	//アニメーションのイベント呼ぶ
	public void EndAttack()
	{
		m_canMoveAttack = false;
	}

	//アニメーションのイベントで呼ぶ
	public void StartAttack()
	{
		m_canMoveAttack =	true;
	}

}
