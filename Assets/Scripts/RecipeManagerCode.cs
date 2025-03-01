using UnityEngine;
using UnityEngine.UI;
using TMPro; // Alleen als je TextMeshPro gebruikt

public class RecipeManager : MonoBehaviour
{
    public TextMeshProUGUI recipeText;  // Beschrijvingstekst
    public TextMeshProUGUI titleText;   // Titeltekst (bijv. "Stap 1")
    public Button previousButton;       // Referentie naar de Vorige knop
    public string[] recipes;
    private int currentIndex = 0;

    void Start()
    {
        UpdateRecipe();
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

    void UpdateRecipe()
    {
        recipeText.text = recipes[currentIndex];
        titleText.text = "Stap " + (currentIndex + 1); // Titel updaten

        // Laat de Vorige knop verdwijnen als we op stap 1 zijn
        if (currentIndex == 0)
        {
            previousButton.gameObject.SetActive(false);
        }
        else
        {
            previousButton.gameObject.SetActive(true);
        }
    }
}
