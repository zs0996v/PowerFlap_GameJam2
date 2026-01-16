using System.Collections;
using UnityEngine;

public class BoostPowerUpScript : MonoBehaviour
{
    public float boostMultiplier = 1.8f;
    public float boostDuration = 10f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            AudioManager.instance.PlayPowerUpSound();
            StartCoroutine(Boost());
            Destroy(gameObject);
        }
    }

    IEnumerator Boost()
    {
        PipeMoveScript.speedMultiplier = boostMultiplier;
        yield return new WaitForSeconds(boostDuration);
        PipeMoveScript.speedMultiplier = 1f;
    }
}
