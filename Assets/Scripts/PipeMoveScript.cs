using UnityEngine;

public class PipeMoveScript : MonoBehaviour
{
    public float baseMoveSpeed = 5f;
    public static float speedMultiplier = 1f;
    public float deadZone = -45;

    void Update()
    {
        if (!LogicScript.gameIsOver)
        {
            transform.position += Vector3.left * baseMoveSpeed * speedMultiplier * Time.deltaTime;
            if (transform.position.x < deadZone)
            {
                Destroy(gameObject);
            }
        }
    }
}
