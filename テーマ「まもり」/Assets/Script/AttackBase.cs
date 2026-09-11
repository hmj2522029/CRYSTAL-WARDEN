using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AttackBase : MonoBehaviour
{
	[SerializeField] protected int m_damage;

	protected bool m_isAttack;  //UŒ‚‚µ‚½‚©
	protected bool m_isRight;   //UŒ‚‚µ‚½•ûŒü(¶‰E•ûŒü‚Ì“ñ•ûŒü‚µ‚©‚È‚¢‚½‚ß)

	public bool IsAttack => m_isAttack;
	public bool IsRight => m_isRight;

	public void SetDirection(bool isRight)
	{
		m_isRight = isRight;
	}

	public void StartAttack()
	{
		m_isAttack = true;
		OnStartAttack();

	}

	public void EndAttack()
	{
		m_isAttack = false;
		OnEndAttack();
	}

	protected abstract void OnStartAttack();
	protected abstract void OnEndAttack();


}
