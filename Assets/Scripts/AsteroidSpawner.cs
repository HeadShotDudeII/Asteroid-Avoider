using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] asteroidPrefabs;
    [SerializeField] float spawnTimeGap = 1f; //secs
    [SerializeField] private Vector2 forceRange;

    [SerializeField] Camera mainCamer;

    private float spawnTimer;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        SpawCounter();
    }

    private void SpawCounter()
    {
        spawnTimer -= Time.deltaTime;

        if (spawnTimer <= 0)
        {
            Spawn();
            spawnTimer = spawnTimeGap;

        }

    }

    private void Spawn()
    {
        int side = Random.Range(0, 4); // left top right bottom
        Vector2 spawnPos = Vector2.zero;
        Vector2 spawnDirection = Vector2.zero;


        switch (side)
        {
            case 0: //left
                spawnPos = new Vector2(0, Random.value);
                spawnDirection = new Vector2(1f, Random.Range(-1f, 1f));
                break;
            case 1: //right
                spawnPos = new Vector2(1, Random.value);
                spawnDirection = new Vector2(-1, Random.Range(-1f, 1f));
                break;
            case 2: //Bottom
                spawnPos = new Vector2(Random.value, 0);
                spawnDirection = new Vector2(Random.Range(-1f, 1f), 1f);

                break;
            case 3: //Top
                spawnPos = new Vector2(Random.value, 1);
                spawnDirection = new Vector2(Random.Range(-1f, 1f), -1f);

                break;

        }

        Vector3 spawnWorldPos = mainCamer.ViewportToWorldPoint(spawnPos);
        spawnWorldPos.z = 0;
        GameObject asteroidInstance = Instantiate(asteroidPrefabs[Random.Range(0, asteroidPrefabs.Length)], spawnWorldPos, Quaternion.Euler(0, 0, Random.Range(0, 360f)));
        asteroidInstance.GetComponent<Rigidbody>().velocity = spawnDirection.normalized * Random.Range(forceRange.x, forceRange.y);


    }
}
