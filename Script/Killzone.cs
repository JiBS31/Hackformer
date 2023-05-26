using UnityEngine;

public class Killzone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) // vérifie si l'objet entrant est le joueur
        {
            // réinitialise la position du joueur à sa position de départ
            collision.transform.position = new Vector2(276.1f, -18.28f); // ici on réinitialise la position à (0,0), mais il faut adapter selon la position de départ souhaitée
        }
    }
}


