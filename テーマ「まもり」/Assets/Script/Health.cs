using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
	[SerializeField] int health;	//HP

	private int m_currentHp;    //Œ»Ý‚ÌHP
	private int m_maxHp;		//Å‘åHP
	private bool m_isDeath;		//Ž€‚ñ‚Å‚¢‚é‚©‚Ç‚¤‚©

	public bool IsDeath => m_isDeath;

	public int CurrentHp => m_currentHp;

	public int MaxHp => m_maxHp;

	private void Awake()
	{
		m_currentHp = health;
		m_maxHp = health;
	}

	public void Damage(int damage)
	{
		if(m_isDeath) return;

		m_currentHp -= damage;

		if (m_currentHp <= 0)
		{
			m_currentHp = 0;
			m_isDeath = true;
		}
	}

	public void InstantDeath()
	{
		m_isDeath = true;
		m_currentHp = 0;
	}

}
