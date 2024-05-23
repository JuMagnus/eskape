using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class CollectableSpawner : MonoBehaviour
{
    [SerializeField] private float Size = 5;
    [SerializeField] private float timer = 0f;
    [SerializeField] private float maxTime = 6f;
    [SerializeField] private float minTime = 3f;

    [SerializeField] private List<GameObject> collectables = new List<GameObject>();
    [SerializeField] private Transform collectableContainer;

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= Random.Range(minTime, maxTime))
        {
            timer = 0f;
            SpawnCollectable();
        }
    }

    private void SpawnCollectable()
    {
        Vector3 spawnPosition = transform.position + new Vector3(Random.Range(-Size, Size), 0.5f, 0);
        GameObject collectable = PickRandomCollectable();
        Instantiate(collectable, spawnPosition, Quaternion.identity, collectableContainer);
    }

    private GameObject PickRandomCollectable()
    {
        return collectables[Random.Range(0, collectables.Count)];
    }

}
