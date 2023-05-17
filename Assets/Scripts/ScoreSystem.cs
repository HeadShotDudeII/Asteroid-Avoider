using TMPro;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] int scoreMuliplier = 3;
    private float score = 1;
    private bool shouldCount = true;
    // Update is called once per frame
    void Update()
    {
        if (!shouldCount) return;
        score += Time.deltaTime * scoreMuliplier;
        scoreText.text = Mathf.FloorToInt(score).ToString();
    }


    //used in continue game no need to reset score
    public void StartTimer()
    {
        shouldCount = true;

    }

    public int EndTimer()
    {
        shouldCount = false;
        scoreText.text = "You dided";
        return Mathf.FloorToInt(score);
    }
}
