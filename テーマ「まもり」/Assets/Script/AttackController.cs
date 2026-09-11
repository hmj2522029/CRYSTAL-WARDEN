using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackController : MonoBehaviour
{

	[SerializeField] List<AttackBase> m_attacks;

	private AttackBase m_currentAttack;

	public void SelectAttack(int index)
	{
		//範囲内チェック
		if (index < 0 || index >= m_attacks.Count) return;

		m_currentAttack = m_attacks[index];


	}

	//アニメーションのイベントで呼ぶ
	public void StartAttackController()
	{
		if (m_currentAttack == null) return;

		m_currentAttack.StartAttack();

	}

	//アニメーションのイベントで呼ぶ
	public void EndAttackController()
	{
		if (m_currentAttack == null) return;

		m_currentAttack.EndAttack();
	}

	public void SetDirection(bool isRight)
	{
		if (m_currentAttack == null) return;

		m_currentAttack.SetDirection(isRight);

	}

}
