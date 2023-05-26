using UnityEngine;

public class OverMousseButton : MonoBehaviour
{
    // la distance de déplacement vers la gauche
    public float deplacementGauche = 1f;

    // la vitesse de déplacement
    public float vitesseDeplacement = 5f;

    // la position de départ du bouton
    private Vector3 positionDepart;

    // le composant RectTransform du bouton
    private RectTransform rectTransform;

    void Start()
    {
        // Récupère le composant RectTransform du bouton
        rectTransform = GetComponent<RectTransform>();

        // Sauvegarde la position de départ du bouton
        positionDepart = rectTransform.position;
    }

    void Update()
    {
        // Déplace le bouton vers la position de départ
        rectTransform.position = Vector3.Lerp(rectTransform.position, positionDepart, vitesseDeplacement * Time.deltaTime);
    }

    public void OnPointerEnter()
    {
        // Déplace le bouton vers la gauche lorsque la souris survole le bouton
        rectTransform.position -= new Vector3(deplacementGauche, 0f, 0f);
    }

    public void OnPointerExit()
    {
        // Déplace le bouton vers la position de départ lorsque la souris quitte le bouton
        rectTransform.position = positionDepart;
    }
}


