using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target; // la cible à suivre
    public float followSpeed = 2f; // la vitesse de déplacement de la caméra
    public float smoothTime = 0.3f; // le temps de transition pour le glissement de la caméra
    public Vector2 offset = new Vector2(0, 2); // l'écart entre la caméra et la cible

    private Vector3 velocity = Vector3.zero;

    void LateUpdate()
    {
        // calcule la position à laquelle la caméra doit se déplacer
        Vector3 targetPosition = new Vector3(target.position.x + offset.x, target.position.y + offset.y, transform.position.z);

        // déplace la caméra vers la position cible à une vitesse de suivi donnée
        transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);

        // fait un glissement en utilisant la fonction SmoothDamp
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}







