using UnityEngine;
using UnityEngine.UI;

public class UI_Score_Text : MonoBehaviour
{
    private Text text;

    private void Awake()
    {
        text = GetComponent<Text>();
    }

    public void SetText(string message)
    {
        text.text = message;
    }

}
