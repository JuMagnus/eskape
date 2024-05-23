using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectables : MonoBehaviour
{
     [SerializeField] private GameObject fx;
    private void OnTriggerEnter(Collider other)
    {
        CharacterControler player = other.GetComponent<CharacterControler>();
        if (player)
        {
            if (fx != null)
            {
                var newFx = Instantiate(fx, transform.position, Quaternion.identity);
                Destroy(newFx, 1f);
            }

            player.AddEnergy(200);

            Destroy(gameObject);
        }
    }
}
