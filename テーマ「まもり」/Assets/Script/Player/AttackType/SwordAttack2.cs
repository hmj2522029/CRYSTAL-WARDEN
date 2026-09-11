using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack2 : AttackBase
{
    [SerializeField] AudioClip m_attackSE;    //攻撃音

    private AttackHitbox m_hitbox;

	private void Awake()
	{
		m_hitbox = GetComponent<AttackHitbox>();
	}

	private void Update()
	{

		m_hitbox.SetDirection(m_isRight);
		
	}

	protected override void OnStartAttack()
	{
        //攻撃音を鳴らす
        AudioManager.Instance.PlaySE(m_attackSE, 0.7f);

        m_hitbox.EnableHitbox(m_damage);    //当たり判定の有効化

	}
	protected override void OnEndAttack()
	{

		m_hitbox.DisableHitbox();   //当たり判定の無効化
	}
}
