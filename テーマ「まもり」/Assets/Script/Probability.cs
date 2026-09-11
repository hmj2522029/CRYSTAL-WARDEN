using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Probability : MonoBehaviour
{
	public bool Check(int probability)
	{
		probability = Mathf.Clamp(probability, 0, 100);

		return Random.Range(0, 100) < probability;
	}

}
