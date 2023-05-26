using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;

public class PositionPlatforme : MonoBehaviour
{
    public Button bouton;
    public GameObject objetADeplacer;
    public Vector3 positionFinale;
    public float vitesseDeplacement = 100.0f;
    public GameObject folderOk;
    public GameObject folderOk2;

    private bool enDeplacement = false;

    void Start()
    {
        folderOk.SetActive(false);
        folderOk2.SetActive(false);
    }

    public void DeplacerObjet()
    {
        // Vérifie si le texte du bouton est "2"
        if (bouton.GetComponentInChildren<TextMeshProUGUI>().text == "2")
        {
            // Vérifie si l'objet n'est pas déjà en déplacement
            if (!enDeplacement)
            {
                // Démarre le déplacement
                StartCoroutine(Deplacer());
            }
        }
    }

    private void Update()
    {
        if(enDeplacement == true)
        {
            folderOk2.SetActive(true);
        }
    }

    IEnumerator Deplacer()
    {
        // Défini la variable enDeplacement à true pour éviter les appels multiples
        enDeplacement = true;

        // Boucle tant que l'objet n'a pas atteint la position finale
        while (objetADeplacer.transform.position != positionFinale)
        {
            // Déplace l'objet vers la position finale en utilisant une interpolation linéaire (lerp)
            objetADeplacer.transform.position = Vector3.Lerp(objetADeplacer.transform.position, positionFinale, Time.deltaTime * vitesseDeplacement);

            // Attend la fin du frame pour continuer la boucle
            yield return new WaitForEndOfFrame();
        }

        // Défini la variable enDeplacement à false pour permettre les appels suivants
        enDeplacement = false;

    }

}

