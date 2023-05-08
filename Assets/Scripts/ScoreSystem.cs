using TMPro;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] int scoreMuliplier = 3;
    private float score = 1;
    private bool isStopped = false;
    // Update is called once per frame
    void Update()
    {
        if (isStopped) return;
        score += Time.deltaTime * scoreMuliplier;
        scoreText.text = Mathf.FloorToInt(score).ToString();
    }

    public int GetFinalScore()
    {
        isStopped = true;
        return Mathf.FloorToInt(score);
    }
}
