using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] GameObject gameOverHandler;
    [SerializeField] GameObject asteroidSpawner;


    public void Die()
    {
        asteroidSpawner.SetActive(false);
        gameOverHandler.SetActive(true);
        gameOverHandler.GetComponent<GameOverHandler>().EndGame();
        //gameObject.SetActive(false);
    }
}
