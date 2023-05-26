using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;

public class FolderPick : MonoBehaviour
{
    public GameObject bouton;
    public GameObject boutonNonCharged;
    public GameObject Folder;

    private void Start()
    {
        if (!Folder.GetComponent<Renderer>().isVisible)
        {
            Folder.GetComponent<DialogueFolder>().enabled = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Vérifie si le GameObject en collision est celui que nous voulons ramasser
        if (collision.gameObject.CompareTag("ObjetARamasser"))
        {
            // Détruit le GameObject
            Destroy(collision.gameObject);

            // Change le texte du bouton
            bouton.GetComponentInChildren<TextMeshProUGUI>().text = "Plateforme";
            boutonNonCharged.GetComponentInChildren<TextMeshProUGUI>().text = "Plateforme";
            boutonNonCharged.GetComponentInChildren<TextMeshProUGUI>().color = Color.red;

        }

    }
}





