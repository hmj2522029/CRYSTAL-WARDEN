using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameUI : MonoBehaviour
{
	public enum TextType
	{
		TimeLimit,      //制限時間のテキスト
		WinorLoss		//勝敗のテキスト
	}

	[System.Serializable]
	public class UIText
	{
		public TextType type;           //テキストの種類
		public TextMeshProUGUI text;    //対応するテキスト
	}

	[SerializeField] List<UIText> m_textList;   //このシーンで使用するテキスト

	private Dictionary<TextType, TextMeshProUGUI> m_texts;  //テキストの種類とテキストの対応を管理

	private void Awake()
	{
		m_texts = new Dictionary<TextType, TextMeshProUGUI>();

		foreach (var uiText in m_textList)
		{
			m_texts.Add(uiText.type, uiText.text);
		}

	}

	private void Start()
	{
		foreach (var uiText in m_textList)
		{
			Hide(uiText.type);
		}
	}


	public void Show(string message, TextType type)
	{
		m_texts[type].text = message;
	}


	public void Hide(TextType type)
	{
		m_texts[type].text = "";
	}
}
