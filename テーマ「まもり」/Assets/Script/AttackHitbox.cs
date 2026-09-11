using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackHitbox : MonoBehaviour
{
	[SerializeField] float m_directionalOffsetX;	//左右方向のアニメーションしかないため

	private BoxCollider2D m_collider;

	private int m_damage;
	private Vector2 m_offset;

	private void Awake()
	{
		m_collider = GetComponent<BoxCollider2D>();
	}

	private void Start()
	{
		DisableHitbox();
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		Health health = other.GetComponentInParent<Health>();

		if (health == null) return;

		health.Damage(m_damage);
	}

	public void EnableHitbox(int damage)
	{
		m_damage = damage;
		m_collider.enabled = true;
	}

	public void DisableHitbox()
	{
		m_collider.enabled = false;
	}

	//左右方向の二方向限定
	public void SetDirection(bool isRight)
	{
		Vector2 offset = m_collider.offset;

		offset.x = isRight ? m_directionalOffsetX : -m_directionalOffsetX;

		m_collider.offset = offset;
	}
}
