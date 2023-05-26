using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformY : MonoBehaviour
{
    private float startPosY;
    private bool isBeingHelg = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isBeingHelg == true)
        {
            //Récupère la position de la souris.

            Vector2 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            this.gameObject.transform.localPosition = new Vector2(transform.localPosition.x, mousePos.y - startPosY);
        }
    }

    private void OnMouseDown()
    {

        //Si le joueur clique sur le clique gauche, celui-ci récupère la position de la souris et le bouge sur l'axe X.
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            startPosY = mousePos.y - this.transform.localPosition.y;

            isBeingHelg = true;
        }

    }

    private void OnMouseUp()
    {
        isBeingHelg = false;
    }
}
