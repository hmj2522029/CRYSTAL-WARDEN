using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	[SerializeField] int m_spawnProbability = 50;	//出る確率

	protected EnemyAnimation m_enemyAnimation;      //アニメーション
	protected AttackController m_attackController;  //攻撃
	protected Probability m_probability;            //確率
	private TargetTracking m_targetTracking;		//追従
	private Movement m_movement;                    //移動
	private Health m_health;                        //HP
	private Collider2D[] m_colliders;				//敵に付いている全てのコライダー(攻撃のコライダーも)

	private bool m_isDeath = false;     //死んでいるか
	private bool m_isGameEnd = false;   //ゲームが終わったかどうか
	private bool m_isRight = false;     //方向(左右方向の二方向限定だから)
	private Transform m_returnPosition;	//戻る位置

	public int SpawnProbability => m_spawnProbability;

	private void Awake()
	{

		m_enemyAnimation = GetComponent<EnemyAnimation>();
		m_movement = GetComponent<Movement>();
		m_attackController = GetComponent<AttackController>();
		m_targetTracking = GetComponent<TargetTracking>();
		m_health = GetComponent<Health>();
		m_probability = GetComponent<Probability>();
		m_colliders = GetComponentsInChildren<Collider2D>();

	}

	private void Update()
	{
		if (m_isDeath) return;

		//死んだら死亡アニメーションの再生
		if (m_health.IsDeath && !m_isDeath)
		{
			m_isDeath = m_health.IsDeath;
			StartCoroutine(DeathProcess());

			return;
		}

		//左右方向の判定
		if (m_targetTracking.InputDir.x > 0)
		{
			m_isRight = true;
		}
		else if (m_targetTracking.InputDir.x < 0)
		{
			m_isRight = false;
		}

		//移動
		m_movement.Move(m_targetTracking.InputDir, m_targetTracking.Speed);

		//移動アニメーション
		m_enemyAnimation.MoveAnime(m_targetTracking.InputDir);

		//方向
		m_attackController.SetDirection(m_isRight);

		//ゲームが終わっている場合は攻撃をさせない
		if(m_isGameEnd) return;

		//攻撃アニメーション
		if (!m_targetTracking.IsMove && !m_enemyAnimation.CanMoveAttack)
		{
            Attack();

			//本来はアニメーションのイベントの方で呼ぶが切り替えの速度よりUpdateの方が早いため手動で呼ぶ
			m_enemyAnimation.StartAttack();

		}

	}

    protected virtual void Attack()
    {
        //派生クラスで実装する
    }


    private IEnumerator DeathProcess()
	{
		m_enemyAnimation.DeathAnime();
		m_movement.Stop();

		//全てのコライダーを無効化する
		foreach (Collider2D collider in m_colliders)
		{
			collider.enabled = false;
		}

		yield return new WaitForSeconds(1.5f);

		Destroy(transform.gameObject);
	}

	private void ReturnToBase()
	{
		m_targetTracking.SetTarget(m_returnPosition);
		m_isGameEnd = true;
	}

	public void SetReturnPosition(Transform transform)
	{
		m_returnPosition = transform;
	}

	private void OnEnable()
	{
		GameManager.OnGameEnd += ReturnToBase;
	}

	private void OnDisable()
	{
		GameManager.OnGameEnd -= ReturnToBase;
	}
}
