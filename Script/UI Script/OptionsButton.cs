using UnityEngine;
using UnityEngine.UI;

public class OptionsButton : MonoBehaviour
{
    public GameObject optionsMenuUI; // le menu des options
    public Button optionsButton; // le bouton "Options"
    public GameObject keyBindingsUI; // l'interface pour modifier les touches
    private bool keyBindingsActive = false; // indique si l'interface pour modifier les touches est active

    void Start()
    {
        //Désactive le menu d'option au lancement du jeu
        optionsMenuUI.SetActive(false);

        // ajoute un événement de clic au bouton "Options"
        optionsButton.onClick.AddListener(OpenOptionsMenu);
    }

    void OpenOptionsMenu()
    {
        // cache l'interface de pause
        optionsMenuUI.SetActive(true);

        if (keyBindingsActive == false)
        {
            // active l'interface pour modifier les touches si elle n'est pas déjà active
            keyBindingsUI.SetActive(true);
            keyBindingsActive = true;
        }
        else
        {
            // désactive l'interface pour modifier les touches si elle est déjà active
            keyBindingsUI.SetActive(false);
            keyBindingsActive = false;
        }
    }
}
