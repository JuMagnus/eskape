
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    
    public Transform chunkContainer;

    public List<GameObject> chunks;
    private void OnTriggerExit(Collider other)
    {
        Transform lasChunkEnd = other.gameObject.transform.Find("ChunkEnd");
        Instantiate(PickRandomChunks(), lasChunkEnd.position, Quaternion.identity, chunkContainer);
    }

    private GameObject PickRandomChunks()
    {
        return chunks[Random.Range(0, chunks.Count)];
    }
}
