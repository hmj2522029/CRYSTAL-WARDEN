using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class EnemySpawner : MonoBehaviour
{

	[SerializeField] List<Enemy> m_enemyPrefab;     //敵のプレファブ
	[SerializeField] Transform m_target;			//敵が追従するオブジェクト
	[SerializeField] float m_spawnInterval;			//再度リスポーンする時の時間

	private float m_spawnTime;              //時間
	private bool m_isGameEnd = false;		//ゲームが終わったかどうか
	private List<Transform> m_spawnPoints;	//リスポーン地点
	private Probability m_probability;      //確率


	private void Awake()
	{
		m_probability = GetComponent<Probability>();

		//自分の子を登録
		m_spawnPoints = new List<Transform>();
		foreach (Transform child in transform)
		{
			m_spawnPoints.Add(child);
		}
	}

	private void Update()
	{
		if(m_isGameEnd) return;

		m_spawnTime -= Time.deltaTime;
		
		if(m_spawnTime <= 0)
		{
			SpawnEnemy();
		}
	}


	private void SpawnEnemy()
	{
		Enemy enemyPrefab = null;

		//敵を選択
		for (int i = 0; i < m_enemyPrefab.Count; i++)
		{
			if (m_probability.Check(m_enemyPrefab[i].SpawnProbability))
			{
				enemyPrefab = m_enemyPrefab[i];
				break;
			}

		}

		//必ずしも敵が選択されるわけではないのでもし選択されていなかった場合
		if (enemyPrefab == null)
		{
			SpawnEnemy();
			return;
		}

		//出現地点をランダムに選択
		int spawnIndex = Random.Range(0, m_spawnPoints.Count);

		//Prefabを生成
		Enemy enemy = Instantiate(
			enemyPrefab,
			m_spawnPoints[spawnIndex].position,
			Quaternion.identity
		);

		//敵の追従するオブジェクトの設定
		enemy.GetComponent<TargetTracking>().SetTarget(m_target);

		//敵の戻る時の場所を設定
		enemy.SetReturnPosition(m_spawnPoints[spawnIndex]);

		//再度スポーンさせるための設定
		m_spawnTime = m_spawnInterval;
	}

	private void SpawnStop()
	{
		m_isGameEnd = true;
	}

	private void OnEnable()
	{
		GameManager.OnGameEnd += SpawnStop;
	}

	private void OnDisable()
	{
		GameManager.OnGameEnd -= SpawnStop;
	}


}
