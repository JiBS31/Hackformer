using Unity.VisualScripting;
using UnityEngine;

public class KeyFloatting : MonoBehaviour
{

    public GameObject Player;
    public GameObject KeyObject;
    public float Distance = 0.01f;

    public bool isVisible = false;

    public void Update()
    {
        IsVisible();
    }

    private void IsVisible()
    {
        float DistanceJoueurObjet = Vector2.Distance(transform.position, Player.transform.position);

        if (DistanceJoueurObjet <= Distance && !isVisible)
        {
            isVisible = true;
        }
        else if (DistanceJoueurObjet > Distance && isVisible)
        {
            isVisible = false;
        }
            KeyObject.SetActive(isVisible);
    }
}

