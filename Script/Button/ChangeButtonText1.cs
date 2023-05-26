using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChangeButtonText1 : MonoBehaviour
{
    public Button bouton1;
    public Button bouton2;

    public void ChangerTexte()
    {
        // Vérifie si le texte du bouton est "Plateforme"
        if (bouton1.GetComponentInChildren<TextMeshProUGUI>().text == "Plateforme")
        {
            // Change le texte du premier bouton en "1"
            bouton1.GetComponentInChildren<TextMeshProUGUI>().text = "1";
            // Change le texte du deuxième bouton en "2"
            bouton2.GetComponentInChildren<TextMeshProUGUI>().text = "2";
        }
    }
}

