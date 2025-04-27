using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class RecipeTimerManager : MonoBehaviour
{
    [Header("Recepten")]
    public TextMeshProUGUI recipeText;
    public TextMeshProUGUI titleText;
    public Button previousButton;
    public Button nextButton;
    public string[] recipes;
    public float[] stepTimes;

    private int currentIndex = 0;

    [Header("Timer")]
    public TextMeshProUGUI timerText;
    public Button startKnop;
    public Button pauseKnop;
    public Button resetKnop;

    private float tijd;
    private bool timerActief = false;
    private bool timerBeschikbaar = false;

    void Start()
    {
        UpdateRecipe();

        // Knoppen koppelen aan functies
        startKnop.onClick.AddListener(StartTimer);
        pauseKnop.onClick.AddListener(PauseTimer);
        resetKnop.onClick.AddListener(ResetTimer);
        nextButton.onClick.AddListener(NextRecipe);
        previousButton.onClick.AddListener(PreviousRecipe);
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

    public void UpdateRecipe()
    {
        // Timer altijd stoppen bij het wisselen van stap
        timerActief = false;
        startKnop.interactable = true;

        recipeText.text = recipes[currentIndex];
        titleText.text = "Stap " + (currentIndex + 1);

        // Vorige-knop alleen tonen vanaf stap 2
        previousButton.gameObject.SetActive(currentIndex > 0);

        // Volgende-knop verbergen als laatste stap bereikt is
        nextButton.gameObject.SetActive(currentIndex < recipes.Length - 1);

        // Check of de timer beschikbaar is
        if (stepTimes[currentIndex] > 0)
        {
            tijd = stepTimes[currentIndex];
            UpdateTimerText();
            timerBeschikbaar = true;
            startKnop.gameObject.SetActive(true);
        }
        else
        {
            timerText.text = "-";
            timerBeschikbaar = false;
            startKnop.gameObject.SetActive(false);
        }
    }

    public void NextRecipe()
    {
        if (currentIndex < recipes.Length - 1)
        {
            currentIndex++;
            UpdateRecipe();
        }
    }

    public void PreviousRecipe()
    {
        if (currentIndex > 0)
        {
            currentIndex--;
            UpdateRecipe();
        }
    }

    void UpdateTimerText()
    {
        int minuten = Mathf.FloorToInt(tijd / 60);
        int seconden = Mathf.FloorToInt(tijd % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minuten, seconden);
    }

    public void StartTimer()
    {
        if (timerBeschikbaar)
        {
            timerActief = true;
            startKnop.interactable = false;
        }
    }

    public void PauseTimer()
    {
        timerActief = false;
        startKnop.interactable = true;
    }

    public void ResetTimer()
    {
        if (timerBeschikbaar)
        {
            tijd = stepTimes[currentIndex];
            timerActief = false;
            UpdateTimerText();
            startKnop.interactable = true;
        }
    }
}
