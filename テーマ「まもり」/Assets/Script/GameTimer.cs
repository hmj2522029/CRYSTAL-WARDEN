using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTimer : MonoBehaviour
{

	[SerializeField] float m_limitTime = 60.0f; //制限時間
	[SerializeField] GameUI m_gameUI;			//UI

	private float m_remainingTime;      //残り時間
	private bool m_isTimeUp = false;    //時間切れしているかどうか

	public float RemainingTime => m_remainingTime;

	public bool IsTimeUp => m_isTimeUp;

	private void Start()
	{
		m_remainingTime = m_limitTime;
	}

	private void Update()
	{
		m_remainingTime -= Time.deltaTime;

		m_gameUI.Show(
			$"残り時間: {Mathf.CeilToInt(m_remainingTime)}秒", 
			GameUI.TextType.TimeLimit
			);

		if (m_remainingTime <= 0.0f)
		{
			m_remainingTime = 0.0f;

			//タイムアップを通知
			m_isTimeUp = true;
		}


	}
}
