using System.Collections;
using UnityEngine;

public class BoostPowerUpScript : MonoBehaviour
{
    public float boostMultiplier = 1.8f;
    public float boostDuration = 5f;

    private static Coroutine activeBoostCoroutine;
    private static BoostPowerUpScript instance;

    private void Awake()
    {
        instance = this;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            AudioManager.instance.PlayPowerUpSound();
            if (activeBoostCoroutine != null)
            {
                instance.StopCoroutine(activeBoostCoroutine);
            }
            activeBoostCoroutine = instance.StartCoroutine(Boost());
            Destroy(gameObject);
        }
    }

    IEnumerator Boost()
    {
        PipeMoveScript.speedMultiplier = boostMultiplier;
        float timer = 0f;
        while (timer < boostDuration)
        {
            if (LogicScript.gameIsOver)
            {
                PipeMoveScript.speedMultiplier = 1f;
                activeBoostCoroutine = null;
                yield break;
            }
            timer += Time.deltaTime;
            yield return null;
        }
        PipeMoveScript.speedMultiplier = 1f;
        activeBoostCoroutine = null;
    }

    public static void StopBoost()
    {
        if (activeBoostCoroutine != null && instance != null)
        {
            instance.StopCoroutine(activeBoostCoroutine);
            activeBoostCoroutine = null;
        }
        PipeMoveScript.speedMultiplier = 1f;
    }
}
