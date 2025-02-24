using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private int goldToGive;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.root.TryGetComponent<HeroGold>(out HeroGold heroGold))
        {
            heroGold.AddGold(goldToGive);
        }

        Destroy(gameObject);
    }
}
