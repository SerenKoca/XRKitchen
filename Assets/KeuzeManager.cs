using UnityEngine;
using UnityEngine.UI;

public class ReceptKeuzeManager : MonoBehaviour
{
    [Header("Keuzeknoppen")]
    public Button voorgerechtKnop;
    public Button hoofdgerechtKnop;
    public Button dessertKnop;
    public Button terugKnop; // Terug-knop

    [Header("Recept Canvassen")]
    public Canvas voorgerechtCanvas;
    public Canvas hoofdgerechtCanvas;
    public Canvas dessertCanvas;

    void Start()
    {
        // Alle canvassen uitschakelen bij het starten
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
        // Deactiveer alle canvassen
        voorgerechtCanvas.gameObject.SetActive(false);
        hoofdgerechtCanvas.gameObject.SetActive(false);
        dessertCanvas.gameObject.SetActive(false);

        // Activeer de geselecteerde canvas
        receptCanvas.gameObject.SetActive(true);

        // Verberg de keuzeknoppen
        voorgerechtKnop.gameObject.SetActive(false);
        hoofdgerechtKnop.gameObject.SetActive(false);
        dessertKnop.gameObject.SetActive(false);

        // Toon de terug-knop
        terugKnop.gameObject.SetActive(true);
    }

    void TerugNaarKeuzeMenu()
    {
        // Deactiveer alle canvassen
        voorgerechtCanvas.gameObject.SetActive(false);
        hoofdgerechtCanvas.gameObject.SetActive(false);
        dessertCanvas.gameObject.SetActive(false);

        // Toon de keuzeknoppen
        voorgerechtKnop.gameObject.SetActive(true);
        hoofdgerechtKnop.gameObject.SetActive(true);
        dessertKnop.gameObject.SetActive(true);

        // Verberg de terug-knop
        terugKnop.gameObject.SetActive(false);
    }
}