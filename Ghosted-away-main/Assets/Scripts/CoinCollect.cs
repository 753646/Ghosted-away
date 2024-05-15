using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollect : MonoBehaviour
{
    public int coinCount = 0;
    private PlayerNavMeshMovement playerMovementScript;
    private GameEnding gameEndingScript;

    private void Start()
    {
        playerMovementScript = GetComponentInChildren<PlayerNavMeshMovement>();
        gameEndingScript = FindObjectOfType<GameEnding>();
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
        Debug.Log("Invincibility collected!");
        StartCoroutine(DisableGameEndingForDuration(15f));
    }
    private IEnumerator DisableGameEndingForDuration(float duration)
    {
        if (gameEndingScript != null)
        {
            gameEndingScript.enabled = false;
            yield return new WaitForSeconds(duration);
            gameEndingScript.enabled = true;
        }
    }

    private void CollectSpeedBoost()
    {
        playerMovementScript.movementSpeed = 50f;
        StartCoroutine(ResetSpeedBoost());
        Debug.Log("Speed boost collected!");
    }

    private IEnumerator ResetSpeedBoost()
    {
        yield return new WaitForSeconds(15f);
        playerMovementScript.movementSpeed = 30f;
    }
}