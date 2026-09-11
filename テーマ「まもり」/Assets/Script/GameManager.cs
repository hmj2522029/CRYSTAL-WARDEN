using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	public static event System.Action OnGameEnd;

	[SerializeField] Health m_crystalHealth;    //クリスタルのHP
	[SerializeField] Health m_playerHealth;     //プレイヤーのHP
	[SerializeField] GameUI m_gameUI;			//UI
	[SerializeField] CanvasGroupFade m_fade;	//フェード
	[SerializeField] CanvasGroup m_background;	//フェードさせるCanvas

	private GameTimer m_timer;			//タイマー
	private bool m_isGameEnd = false;	//ゲームが終わったかどうか

	private void Awake()
	{
		m_timer = GetComponent<GameTimer>();
	}

	private void Update()
	{

		if(m_isGameEnd) return;

		//クリスタルのHPが0になった場合(ゲームオーバー)
		if(m_crystalHealth.IsDeath)
		{
			m_isGameEnd = true;

			OnGameEnd?.Invoke();

			//プレイヤーも即死
			m_playerHealth.InstantDeath();

			m_gameUI.Show("ゲームオーバー", GameUI.TextType.WinorLoss);

			//シーン遷移
			StartCoroutine(SceneTransition());
		}

		//タイムアップしているか(ゲームクリア)
		if (m_timer.IsTimeUp)
		{
			m_isGameEnd = true;

			OnGameEnd?.Invoke();

			m_gameUI.Show("ゲームクリア", GameUI.TextType.WinorLoss);

			//シーン遷移
			StartCoroutine(SceneTransition());
		}

	}

	

	private IEnumerator SceneTransition()
	{

		yield return new WaitForSeconds(2f);

		m_fade.FadeIn(m_background, 2.0f);

		yield return new WaitForSeconds(2.5f);

		SceneManager.LoadScene("TitleScene");

	}



}
