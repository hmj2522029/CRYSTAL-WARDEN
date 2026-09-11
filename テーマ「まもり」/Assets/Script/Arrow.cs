using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{

	[SerializeField] float m_speed;

	private Vector2 m_direction;
	private int m_damage;

	private void Start()
	{
		Destroy(gameObject, 5.0f);
	}

	private void Update()
	{

		transform.position += (Vector3)m_direction * m_speed * Time.deltaTime;

	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		Health health = other.GetComponentInParent<Health>();

		if (health == null) return;

		health.Damage(m_damage);

		//ìñÇΩÇ¡ÇΩÇÁè¡Ç∑
		Destroy(gameObject);

	}

	public void SetDamage(int damage)
	{
		m_damage = damage;
	}

	public void SetDirection(Vector2 direction)
	{
		m_direction = direction.normalized;
	}

}
