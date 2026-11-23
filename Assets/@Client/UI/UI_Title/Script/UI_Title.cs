using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class UI_Title : MonoBehaviour
{
    private UI_Title_Button_GameStart buttonGameStart;

    private void Awake()
    {
        buttonGameStart = GetComponentInChildren<UI_Title_Button_GameStart>();
    }

    private void Start()
    {
        SetButtonEvent();
    }

    public void SetButtonEvent()
    {
        buttonGameStart.SetEvent(ChangeScene);
    }

    private void ChangeScene()
    {
        SceneManager.LoadScene("GameScene");
    }

}
