using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollect : MonoBehaviour
{
    public int coinCount = 0;
    private bool invincible = false;
    private bool speedBoost = false;
    private PlayerNavMeshMovement playerMovementScript;

    private void Start()
    {
        playerMovementScript = GetComponentInChildren<PlayerNavMeshMovement>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            CollectCoin(other.gameObject);
        }
        else if (other.CompareTag("Invincibility"))
        {
            CollectInvincibility();
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Speed"))
        {
            CollectSpeedBoost();
            Destroy(other.gameObject);
        }
    }

    private void CollectCoin(GameObject coin)
    {
        coinCount++;
        Destroy(coin);
    }

    private void CollectInvincibility()
    {
        invincible = true;
        Debug.Log("Invincibility collected!");
        // Add invincibility effects or logic here
    }

    private void CollectSpeedBoost()
    {
        speedBoost = true;
        playerMovementScript.movementSpeed = 50f;
        StartCoroutine(ResetSpeedBoost());
        Debug.Log("Speed boost collected!");
    }

    private IEnumerator ResetSpeedBoost()
    {
        yield return new WaitForSeconds(15f);
        playerMovementScript.movementSpeed = 30f;
        speedBoost = false;
    }
}