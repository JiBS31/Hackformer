using UnityEngine;

public class KeyInteract : MonoBehaviour
{
    public KeyCode interactKey = KeyCode.E;
    public float moveSpeed = 5f;
    public float minY = 0f;
    public float maxY = 10f;
    public float zoomOutDistance = 10f;

    private bool isPlayerNearby = false;
    private bool isObjectSelected = false;
    private Vector2 mouseOffset;
    private Camera mainCamera;
    private Vector2 initialCameraPosition;

    void Start()
    {
        mainCamera = Camera.main;
        initialCameraPosition = mainCamera.transform.position;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = false;
            if (isObjectSelected)
            {
                // Si l'objet est en train d'�tre transport�, le l�che
                isObjectSelected = false;
                mainCamera.transform.position = initialCameraPosition;
            }
        }
    }

    void Update()
    {
        if (isPlayerNearby && Input.GetKeyDown(interactKey))
        {
            // Le joueur a appuy� sur la touche d'interaction
            Debug.Log("Le joueur a appuy� sur la touche d'interaction.");

            if (!isObjectSelected)
            {
                // Si aucun objet n'a �t� s�lectionn�, s�lectionne l'objet sous la souris
                Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

                if (hit.collider != null && hit.collider.CompareTag("Selectable"))
                {
                    isObjectSelected = true;
                    mouseOffset = hit.collider.transform.position * mousePos;

                    // �loigne la cam�ra pour avoir une vue globale du niveau
                    mainCamera.transform.position = new Vector3(transform.position.x, transform.position.y, -zoomOutDistance);
                }
            }
            else
            {
                // Si un objet a �t� s�lectionn�, le d�place verticalement
                Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector3 newPos = new Vector3(transform.position.x, mousePos.y + mouseOffset.y, transform.position.z);
                newPos.y = Mathf.Clamp(newPos.y, minY, maxY);
                transform.position = Vector3.Lerp(transform.position, newPos, Time.deltaTime * moveSpeed);

                if (Input.GetMouseButtonUp(0))
                {
                    isObjectSelected = false;

                    // Remet la cam�ra � sa position initiale
                    mainCamera.transform.position = initialCameraPosition;
                }
            }
        }
    }
}

