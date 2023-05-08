using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverHandler : MonoBehaviour
{
    [SerializeField] GameObject asteroidSpawner;
    [SerializeField] ScoreSystem scoreSystem;
    [SerializeField] TextMeshProUGUI scoreText;
    // Start is called before the first frame update
    public void PlayAgain()
    {
        Debug.Log("PlayAgain");
        SceneManager.LoadScene("Game");

    }

    public void ReturntoMain()
    {
        Debug.Log("Main");

        SceneManager.LoadScene("Main");
    }

    public void StopGame()
    {
        scoreText.text = "Your Score is: " + scoreSystem.GetFinalScore().ToString();
        asteroidSpawner.SetActive(false);

        //astroidspanwner stop
        //show the gameover UI setActive
    }
}
