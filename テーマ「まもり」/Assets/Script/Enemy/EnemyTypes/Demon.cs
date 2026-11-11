using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demon : Enemy
{
    protected override void Attack()
    {
        if (m_probability.Check(70))
        {
            m_enemyAnimation.AttackAnime1();
            m_attackController.SelectAttack(DemonAttackIds.KnifeStab);
        }
        else
        {
            m_enemyAnimation.AttackAnime2();
            m_attackController.SelectAttack(DemonAttackIds.VerticalKnifeSlash);
        }
    }
}
