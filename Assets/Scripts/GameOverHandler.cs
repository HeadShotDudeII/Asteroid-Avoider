using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverHandler : MonoBehaviour
{
    [SerializeField] GameObject asteroidSpawner;
    [SerializeField] GameObject gameOverDisplay;

    [SerializeField] ScoreSystem scoreSystem;
    [SerializeField] TextMeshProUGUI scoreText;

    public void Awake()
    {
        gameOverDisplay.SetActive(false);
    }

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


    // called when player die
    public void EndGame()
    {
        int finalScore = scoreSystem.EndTimer();
        scoreText.text = $"Your Score is: {finalScore}";
        asteroidSpawner.SetActive(false);
        gameOverDisplay.SetActive(true);


        //astroidspanwner stop
        //show the gameove r UI setActive
    }

    public void ContinueGame()
    {
        scoreSystem.StartTimer();
        asteroidSpawner.SetActive(true);
        gameOverDisplay.SetActive(false);


    }

}
