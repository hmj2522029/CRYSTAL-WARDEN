using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkAnimation : MonoBehaviour
{
	[SerializeField] float m_interval = 0.1f;	//“_–Å‚·‚éŠÔŠu
	[SerializeField] int m_count = 5;			//“_–Å‚Ì‰ñ”

	private SpriteRenderer m_spriteRenderer;

	private void Awake()
	{
		m_spriteRenderer = GetComponent<SpriteRenderer>();
	}

	public IEnumerator Blink()
	{
		//“_–Åˆ—
		for (int i = 0; i < m_count; i++)
		{
			m_spriteRenderer.enabled = false;
			yield return new WaitForSeconds(m_interval);

			m_spriteRenderer.enabled = true;
			yield return new WaitForSeconds(m_interval);
		}
	}


}
