using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodMonster : Enemy
{
    protected override void Attack()
    {
        if (m_probability.Check(70))
        {
            m_enemyAnimation.AttackAnime1();
            m_attackController.SelectAttack(BloodMonsterAttackIds.VerticalClawSlash);   
        }
        else
        {
            m_enemyAnimation.AttackAnime2();
            m_attackController.SelectAttack(BloodMonsterAttackIds.FangBite);
        }
    }

}
