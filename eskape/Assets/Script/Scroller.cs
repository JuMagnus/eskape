
using UnityEngine;

public class Scroller : MonoBehaviour
{
    
    public Transform chunksContainer;
    public Transform collectableContainer;
    [SerializeField] private CharacterControler characterControler;

    void Update()
    {
        var velocity = Vector3.back * characterControler.currentSpeed * Time.deltaTime;
        characterControler.TravelDistance(velocity.magnitude);
        foreach (Transform child in chunksContainer)
        {
            child.position += velocity;
        }
        foreach (Transform child in collectableContainer)
        {
            child.position += velocity;

        }
    }
}
