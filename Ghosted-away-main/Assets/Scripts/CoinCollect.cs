using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollect : MonoBehaviour
{
    public int coinCount = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            CollectCoin(other.gameObject);
        }
    }

    private void CollectCoin(GameObject coin)
    {
        coinCount++;
        Destroy(coin);
    }
}