using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animals;
    private Vector3 location;
    private float xRange = 15f;
    private float zPos = 20f;
    private float spawnTimer = 2f;
    private float timeCount;

    private void Update()
    {
        if (GameManager.isGameStarted)
        {
            timeCount += Time.deltaTime;
            if (timeCount > spawnTimer)
            {
                SpawnAnimal();
                timeCount = 0f;
            }
        }
        if (!GameManager.isGameStarted)
        {
            DestroyAllAnimals();
            timeCount = 0;
        }
    }

    private void SpawnAnimal()
    {
            var count = animals.Length;
            var index = Random.Range(0, count);
            location = new Vector3(Random.Range(-xRange, xRange + 1), 0f, zPos);
            Instantiate(animals[index], location, animals[index].transform.rotation);
    }

    private void DestroyAllAnimals()
    {
            var animalsOnScene = GameObject.FindGameObjectsWithTag("Animal");
            var count = animalsOnScene.Length;
            for (int i = 0; i < count; i++)
            {
                Destroy(animalsOnScene[i]);
            }
    }
}
