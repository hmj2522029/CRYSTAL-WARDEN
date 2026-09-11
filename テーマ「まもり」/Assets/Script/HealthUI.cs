using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{

	[SerializeField] Health m_health;	//HP
	[SerializeField] Image m_hpGauge;	//HPƒQ[ƒW‰æ‘œ
	[SerializeField] Image m_hpFrame;   //HP‚Ì˜g‰æ‘œ

	private void Start()
	{
		m_hpFrame.enabled = false;
		m_hpGauge.enabled = false;
	}

	private void Update()
	{
		float hpRate = (float)m_health.CurrentHp / m_health.MaxHp;

		m_hpGauge.fillAmount = hpRate;


		if(m_health.CurrentHp < m_health.MaxHp)
		{
			m_hpFrame.enabled = true;
			m_hpGauge.enabled = true;

		}

	}

}
