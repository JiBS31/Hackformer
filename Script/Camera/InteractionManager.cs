using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    public float interactionRadius = 1.0f; // Rayon dans lequel le joueur peut interagir
    public float cameraZoomDistance = 20.0f; // Distance � laquelle la cam�ra se d�place lors de l'interaction
    public float cameraSlideSpeed = 5.0f; // Vitesse � laquelle la cam�ra glisse
    public float cameraSlideDistance = 10.0f; // Distance de glissement de la cam�ra
    public KeyCode interactKey = KeyCode.E; // Touche utilis�e pour l'interaction

    private Transform player; // R�f�rence au GameObject "Player"
    private Transform interactableAsset; // R�f�rence au GameObject "InteractableAsset"
    private Camera mainCamera; // R�f�rence � la cam�ra principale de la sc�ne

    private bool canInteract = false; // Indique si le joueur peut interagir avec l'asset
    private bool isCameraSliding = false; // Indique si la cam�ra est en train de glisser
    private Vector3 targetCameraPosition; // Position cible de la cam�ra pour le glissement

    void Start()
    {
        // R�cup�ration des r�f�rences aux GameObjects "Player", "InteractableAsset" et � la cam�ra principale
        player = GameObject.FindGameObjectWithTag("Player").transform;
        interactableAsset = GameObject.FindGameObjectWithTag("InteractableAsset").transform;
        mainCamera = Camera.main;
    }

    void Update()
    {
        if (canInteract && Input.GetKeyDown(interactKey))
        {
            // Si le joueur appuie sur la touche d'interaction, on d�sactive le script de mouvement du joueur
            player.GetComponent<PlayerMoves>().enabled = false;

            // On d�sactive �galement le script de suivi de cam�ra
            mainCamera.GetComponent<CameraController>().enabled = false;

            // On d�termine la position cible de la cam�ra pour le glissement
            targetCameraPosition = new Vector3(interactableAsset.position.x, interactableAsset.position.y, -cameraZoomDistance - cameraSlideDistance);

            // On indique que la cam�ra doit glisser
            isCameraSliding = true;
        }

        if (isCameraSliding)
        {
            // Si la cam�ra doit glisser, on la d�place progressivement vers sa position cible
            mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, targetCameraPosition, Time.deltaTime * cameraSlideSpeed);

            // Si la cam�ra a atteint sa position cible, on indique que la glissade est termin�e
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


