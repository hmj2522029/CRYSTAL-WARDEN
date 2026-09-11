using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowAttack : AttackBase
{

	[SerializeField] Arrow m_arrowPrefab;

	protected override void OnStartAttack()
	{
		//マウスカーソルの座標取得
		Vector3 mousePosition =
			Camera.main.ScreenToWorldPoint(Input.mousePosition);

		//方向の取得
		Vector2 direction =
			mousePosition - transform.position;

		//矢生成
		Arrow arrow = Instantiate(
			m_arrowPrefab,
			transform.position,
			Quaternion.identity
		);

		//矢の設定
		arrow.SetDirection(direction);
		arrow.SetDamage(m_damage);

		
		float angle = Mathf.Atan2(
			direction.y,
			direction.x
		) * Mathf.Rad2Deg;

		//矢を向きをマウスカーソルのほうに変える
		arrow.transform.rotation =
			Quaternion.Euler(0, 0, angle);

	}

	protected override void OnEndAttack()
	{

	}


}
