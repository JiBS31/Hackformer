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
        // V�rifie si le texte du bouton est "2"
        if (bouton.GetComponentInChildren<TextMeshProUGUI>().text == "2")
        {
            // V�rifie si l'objet n'est pas d�j� en d�placement
            if (!enDeplacement)
            {
                // D�marre le d�placement
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
        // D�fini la variable enDeplacement � true pour �viter les appels multiples
        enDeplacement = true;

        // Boucle tant que l'objet n'a pas atteint la position finale
        while (objetADeplacer.transform.position != positionFinale)
        {
            // D�place l'objet vers la position finale en utilisant une interpolation lin�aire (lerp)
            objetADeplacer.transform.position = Vector3.Lerp(objetADeplacer.transform.position, positionFinale, Time.deltaTime * vitesseDeplacement);

            // Attend la fin du frame pour continuer la boucle
            yield return new WaitForEndOfFrame();
        }

        // D�fini la variable enDeplacement � false pour permettre les appels suivants
        enDeplacement = false;

    }

}

