using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    public float interactionRadius = 1.0f; // Rayon dans lequel le joueur peut interagir
    public float cameraZoomDistance = 20.0f; // Distance à laquelle la caméra se déplace lors de l'interaction
    public float cameraSlideSpeed = 5.0f; // Vitesse à laquelle la caméra glisse
    public float cameraSlideDistance = 10.0f; // Distance de glissement de la caméra
    public KeyCode interactKey = KeyCode.E; // Touche utilisée pour l'interaction

    private Transform player; // Référence au GameObject "Player"
    private Transform interactableAsset; // Référence au GameObject "InteractableAsset"
    private Camera mainCamera; // Référence à la caméra principale de la scène

    private bool canInteract = false; // Indique si le joueur peut interagir avec l'asset
    private bool isCameraSliding = false; // Indique si la caméra est en train de glisser
    private Vector3 targetCameraPosition; // Position cible de la caméra pour le glissement

    void Start()
    {
        // Récupération des références aux GameObjects "Player", "InteractableAsset" et à la caméra principale
        player = GameObject.FindGameObjectWithTag("Player").transform;
        interactableAsset = GameObject.FindGameObjectWithTag("InteractableAsset").transform;
        mainCamera = Camera.main;
    }

    void Update()
    {
        if (canInteract && Input.GetKeyDown(interactKey))
        {
            // Si le joueur appuie sur la touche d'interaction, on désactive le script de mouvement du joueur
            player.GetComponent<PlayerMoves>().enabled = false;

            // On désactive également le script de suivi de caméra
            mainCamera.GetComponent<CameraController>().enabled = false;

            // On détermine la position cible de la caméra pour le glissement
            targetCameraPosition = new Vector3(interactableAsset.position.x, interactableAsset.position.y, -cameraZoomDistance - cameraSlideDistance);

            // On indique que la caméra doit glisser
            isCameraSliding = true;
        }

        if (isCameraSliding)
        {
            // Si la caméra doit glisser, on la déplace progressivement vers sa position cible
            mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, targetCameraPosition, Time.deltaTime * cameraSlideSpeed);

            // Si la caméra a atteint sa position cible, on indique que la glissade est terminée
            if (mainCamera.transform.position == targetCameraPosition)
            {
                isCameraSliding = false;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Si le joueur entre dans le rayon d'interaction de l'asset, on indique qu'il peut interagir
        if (other.CompareTag("Player"))
        {
            canInteract = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        // Si le joueur sort du rayon d'interaction de l'asset, on indique qu'il ne peut plus interagir
        if (other.CompareTag("Player"))
        {
            canInteract = false;
        }
    }
}


