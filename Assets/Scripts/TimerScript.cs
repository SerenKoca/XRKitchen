using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    public float startTijd = 60f; // Starttijd in seconden
    private float tijd;
    private bool timerActief = false;

    public TextMeshProUGUI timerText;
    public Button startKnop;
    public Button pauseKnop;
    public Button resetKnop;

    void Start()
    {
        tijd = startTijd;
        UpdateTimerText();

        // Knoppen koppelen aan functies
        startKnop.onClick.AddListener(StartTimer);
        pauseKnop.onClick.AddListener(PauseTimer);
        resetKnop.onClick.AddListener(ResetTimer);
    }

    void Update()
    {
        if (timerActief && tijd > 0)
        {
            tijd -= Time.deltaTime;
            UpdateTimerText();
        }
        else if (tijd <= 0 && timerActief)
        {
            timerActief = false;
            timerText.text = "Tijd is om!";
        }
    }

    void UpdateTimerText()
    {
        timerText.text = "Tijd: " + Mathf.Ceil(tijd).ToString();
    }

    public void StartTimer()
    {
        timerActief = true;
        startKnop.interactable = false; // Startknop uitschakelen
    }

    public void PauseTimer()
    {
        timerActief = false;
        startKnop.interactable = true; // Startknop weer inschakelen
    }

    public void ResetTimer()
    {
        tijd = startTijd;
        timerActief = false;
        UpdateTimerText();
        startKnop.interactable = true; // Startknop weer inschakelen
    }
}
