using UnityEngine;
using UnityEngine.UI;

public class ReceptKeuzeManager : MonoBehaviour
{
    [Header("Keuzeknoppen")]
    public Button voorgerechtKnop;
    public Button hoofdgerechtKnop;
    public Button dessertKnop;
    public Button terugKnop;

    [Header("Recept Canvassen")]
    public Canvas voorgerechtCanvas;
    public Canvas hoofdgerechtCanvas;
    public Canvas dessertCanvas;

    [Header("Keuze Menu Onderdelen")]
    public GameObject[] keuzeMenuOnderdelen; // Nieuw: hier zet je knoppen én images in die bij het menu horen

    void Start()
    {
        // Alle recept canvassen uitschakelen bij het starten
        voorgerechtCanvas.gameObject.SetActive(false);
        hoofdgerechtCanvas.gameObject.SetActive(false);
        dessertCanvas.gameObject.SetActive(false);

        // Terug-knop uitschakelen bij het starten
        terugKnop.gameObject.SetActive(false);

        // Knoppen koppelen aan functies
        voorgerechtKnop.onClick.AddListener(() => SelecteerReceptCanvas(voorgerechtCanvas));
        hoofdgerechtKnop.onClick.AddListener(() => SelecteerReceptCanvas(hoofdgerechtCanvas));
        dessertKnop.onClick.AddListener(() => SelecteerReceptCanvas(dessertCanvas));
        terugKnop.onClick.AddListener(TerugNaarKeuzeMenu);
    }

    void SelecteerReceptCanvas(Canvas receptCanvas)
    {
        // Deactiveer alle recept canvassen
        voorgerechtCanvas.gameObject.SetActive(false);
        hoofdgerechtCanvas.gameObject.SetActive(false);
        dessertCanvas.gameObject.SetActive(false);

        // Activeer de geselecteerde canvas
        receptCanvas.gameObject.SetActive(true);

        // Verberg alle onderdelen van het keuzemenu (knoppen en images)
        foreach (GameObject onderdeel in keuzeMenuOnderdelen)
        {
            onderdeel.SetActive(false);
        }

        // Toon de terug-knop
        terugKnop.gameObject.SetActive(true);
    }

    void TerugNaarKeuzeMenu()
    {
        // Deactiveer alle recept canvassen
        voorgerechtCanvas.gameObject.SetActive(false);
        hoofdgerechtCanvas.gameObject.SetActive(false);
        dessertCanvas.gameObject.SetActive(false);

        // Toon alle onderdelen van het keuzemenu (knoppen en images)
        foreach (GameObject onderdeel in keuzeMenuOnderdelen)
        {
            onderdeel.SetActive(true);
        }

        // Verberg de terug-knop
        terugKnop.gameObject.SetActive(false);
    }
}
