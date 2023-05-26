using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSlip : MonoBehaviour
{
    // Paramètres de suivi de la caméra
    public float cameraSpeed = 2f;
    public float followOffset = 2f;

    // Composants
    private Transform playerTransform;

    // Initialisation
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Mise à jour
    void LateUpdate()
    {
        // Suivre le joueur horizontalement avec une légère décalage
        float targetX = playerTransform.position.x + followOffset;
        float cameraX = Mathf.Lerp(transform.position.x, targetX, Time.deltaTime * cameraSpeed);
        transform.position = new Vector3(cameraX, transform.position.y, transform.position.z);
    }
}

