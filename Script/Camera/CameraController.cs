using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target; // la cible � suivre
    public float followSpeed = 2f; // la vitesse de d�placement de la cam�ra
    public float smoothTime = 0.3f; // le temps de transition pour le glissement de la cam�ra
    public Vector2 offset = new Vector2(0, 2); // l'�cart entre la cam�ra et la cible

    private Vector3 velocity = Vector3.zero;

    void LateUpdate()
    {
        // calcule la position � laquelle la cam�ra doit se d�placer
        Vector3 targetPosition = new Vector3(target.position.x + offset.x, target.position.y + offset.y, transform.position.z);

        // d�place la cam�ra vers la position cible � une vitesse de suivi donn�e
        transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);

        // fait un glissement en utilisant la fonction SmoothDamp
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}







