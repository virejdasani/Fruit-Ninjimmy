using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitSpawner : MonoBehaviour
{

	public GameObject fruitPrefab1;
	public GameObject fruitPrefab2;
	public GameObject fruitPrefab3;
	public GameObject fruitPrefab4;
	public GameObject fruitPrefab5;

	public Transform[] spawnPoints;

	public float minDelay = .1f;
	public float maxDelay = 1f;

	GameObject youtuber;

	// Use this for initialization
	void Start()
	{
		StartCoroutine(SpawnFruits());
	}

	IEnumerator SpawnFruits()
	{
		while (true)
		{
			int randYoutuber = Random.Range(1, 6);

			if (randYoutuber == 1)
            {
				youtuber = fruitPrefab1;

			}

			if (randYoutuber == 2)
			{
				youtuber = fruitPrefab2;

			}

			if (randYoutuber == 3)
			{
				youtuber = fruitPrefab3;

			}

			if (randYoutuber == 4)
			{
				youtuber = fruitPrefab4;

			}

			if (randYoutuber == 5)
			{
				youtuber = fruitPrefab5;

			}

			float delay = Random.Range(minDelay, maxDelay);
			yield return new WaitForSeconds(delay);

			int spawnIndex = Random.Range(0, spawnPoints.Length);
			Transform spawnPoint = spawnPoints[spawnIndex];

			GameObject spawnedFruit = Instantiate(youtuber, spawnPoint.position, spawnPoint.rotation);
			Destroy(spawnedFruit, 5f);
		}
	}

}