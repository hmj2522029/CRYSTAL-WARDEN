using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms;

public class TitleManager : MonoBehaviour
{
    [Header("開始ボタン")]
    [SerializeField] InputAction m_pressAnyButton;  //PressAnyButton

    [Header("フェード等")]
    [SerializeField] CanvasGroupFade m_fade;        //フェード
    [SerializeField] CanvasGroup m_image;           //画面のフェード用の画像

    [Header("音")]
    [SerializeField] AudioClip m_click;     //クリック音

    private bool m_isInput;                    //入力を受け付けるかどうか
    private float m_ignoreInputTime = 1.5f;    //入力を無視する時間

    private void Start()
    {

        m_fade.FadeOut(m_image, 2f);    //見えるようにする

    }

    private void Update()
    {
        //入力を無視する時間が経過したら入力を受け付けるようにする
        if (!m_isInput)
        {
            
            m_ignoreInputTime -= Time.deltaTime;

            if (m_ignoreInputTime <= 0f)
            {
                m_isInput = true;
                m_ignoreInputTime = 0f;
            }

        }

        if (m_pressAnyButton.WasPressedThisFrame() && m_isInput)
        {
            //クリック音を鳴らす
            AudioManager.Instance.PlaySE(m_click);

            // シーン切り替え
            StartCoroutine(ChangeScene());

        }

    }

    private IEnumerator ChangeScene()
    {

        m_fade.FadeIn(m_image, 2f);     //見えなる

        yield return new WaitForSeconds(2f);

        SceneManager.LoadScene("GameScene");

    }

    private void OnEnable()
    {
        m_pressAnyButton.Enable();
    }

    private void OnDisable()
    {
        m_pressAnyButton.Disable();
    }


}
