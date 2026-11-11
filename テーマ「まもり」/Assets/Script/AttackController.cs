using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro.EditorUtilities;
using UnityEngine;

public class AttackController : MonoBehaviour
{

    [System.Serializable]
    public class Attack
    {
        public AttackBase attack;   //攻撃の種類
        public string attackId;     //攻撃のID(名前)
    }


    [SerializeField] List<Attack> m_attacks;

	private AttackBase m_currentAttack;

	public void SelectAttack(string name)
	{
        foreach (var attack in m_attacks)
        {

            if (attack.attackId == name)
            {
                m_currentAttack = attack.attack;
                return;
            }

        }

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
