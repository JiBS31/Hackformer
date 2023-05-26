using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSlip : MonoBehaviour
{
    // Param�tres de suivi de la cam�ra
    public float cameraSpeed = 2f;
    public float followOffset = 2f;

    // Composants
    private Transform playerTransform;

    // Initialisation
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Mise � jour
    void LateUpdate()
    {
        // Suivre le joueur horizontalement avec une l�g�re d�calage
        float targetX = playerTransform.position.x + followOffset;
        float cameraX = Mathf.Lerp(transform.position.x, targetX, Time.deltaTime * cameraSpeed);
        transform.position = new Vector3(cameraX, transform.position.y, transform.position.z);
    }
}

