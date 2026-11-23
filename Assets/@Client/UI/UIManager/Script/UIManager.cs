using UnityEngine;

public class UIManager : MonoBehaviour
{
    private UI_Score uiScore;
    private UI_GameOver uiGameOver;
    private UI_GameClear uiGameClear;
    private UI_Title uiTitle;


    private void Awake()
    {
        uiScore = GetComponentInChildren<UI_Score>();
        uiGameOver = GetComponentInChildren<UI_GameOver>();
        uiGameClear = GetComponentInChildren<UI_GameClear>();
    }

    public void Init()
    {
        uiGameClear.gameObject.SetActive(false);
        uiGameOver.gameObject.SetActive(false);
    }

    public void UpdateScoreUI(int score)
    {
        uiScore.UpdateScore(score);
    }

    public void ShowGameOverUI()
    {
        uiGameOver.gameObject.SetActive(true);
    }

    public void ShowGameClearUI()
    {
        uiGameClear.gameObject.SetActive(true);
    }

}
