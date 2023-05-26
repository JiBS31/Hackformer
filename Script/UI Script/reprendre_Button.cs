using UnityEngine;
using UnityEngine.UI;

public class reprendre_Button : MonoBehaviour
{
    public GameObject pauseMenuUI; // le menu de pause
    public Button resumeButton; // le bouton "Reprendre"

    void Start()
    {
        // ajoute un événement de clic au bouton "Reprendre"
        resumeButton.onClick.AddListener(ResumeGame);
    }

    void ResumeGame()
    {
        // cache l'interface de pause
        pauseMenuUI.SetActive(false);

        // remet le temps en échelle normale pour reprendre le jeu
        Time.timeScale = 1f;

        // remet la musique en marche si besoin
        // AudioManager.Instance.PlayMusic();

        // réactive les contrôles du joueur si besoin
        // PlayerController.Instance.enabled = true;

        // affiche le curseur de la souris si besoin
        // Cursor.visible = false;
    }
}
