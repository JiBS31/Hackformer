using UnityEngine;

public class OverMousseButton : MonoBehaviour
{
    // la distance de d�placement vers la gauche
    public float deplacementGauche = 1f;

    // la vitesse de d�placement
    public float vitesseDeplacement = 5f;

    // la position de d�part du bouton
    private Vector3 positionDepart;

    // le composant RectTransform du bouton
    private RectTransform rectTransform;

    void Start()
    {
        // R�cup�re le composant RectTransform du bouton
        rectTransform = GetComponent<RectTransform>();

        // Sauvegarde la position de d�part du bouton
        positionDepart = rectTransform.position;
    }

    void Update()
    {
        // D�place le bouton vers la position de d�part
        rectTransform.position = Vector3.Lerp(rectTransform.position, positionDepart, vitesseDeplacement * Time.deltaTime);
    }

    public void OnPointerEnter()
    {
        // D�place le bouton vers la gauche lorsque la souris survole le bouton
        rectTransform.position -= new Vector3(deplacementGauche, 0f, 0f);
    }

    public void OnPointerExit()
    {
        // D�place le bouton vers la position de d�part lorsque la souris quitte le bouton
        rectTransform.position = positionDepart;
    }
}


