using UnityEngine;

public class UI_Score : MonoBehaviour
{
    // GameManager에서 점수를 세고 있음
    // UiManager를 통해서
    // UI_Score 그 점수를 전달할거임
    // UI_Score는 자식에 있는 UI_Score_Text 의 
    // Text를 Score: 10 이런 식 으로 바꿔주면 됨
    private UI_Score_Text textScore;

    private void Awake()
    {
        textScore = GetComponentInChildren<UI_Score_Text>();
    }

    public void UpdateScore(int score)
    {
        textScore.SetText($"Score: {score}");
    }
}
