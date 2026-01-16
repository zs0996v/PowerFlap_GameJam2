using UnityEngine;

public class PipeSpawnScript : MonoBehaviour
{
    public GameObject pipe;
    public GameObject boostPowerUp;
    public float spawnRate = 2;
    private float timer = 0;
    public float heightOffset = 10;
    [Range(0f, 1f)] public float boostSpawnChance = 0.3f;

    void Start()
    {
        spawnPipe();
    }

    void Update()
    {
        if (!LogicScript.gameIsOver)
        {
            if (timer < spawnRate)
            {
                timer += Time.deltaTime;
            }
            else
            {
                spawnPipe();
                timer = 0;
            }
        }
    }

    void spawnPipe()
    {
        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;

        GameObject newPipe = Instantiate(
            pipe,
            new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0),
            transform.rotation
        );

        if (Random.value <= boostSpawnChance)
        {
            Transform pipeMiddle = newPipe.transform.Find("Middle Pipe");
            if (pipeMiddle != null)
            {
                GameObject boost = Instantiate(boostPowerUp, pipeMiddle.position, Quaternion.identity);
                boost.transform.SetParent(newPipe.transform);
            }
        }
    }
}
