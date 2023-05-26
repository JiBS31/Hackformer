using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformX : MonoBehaviour
{
    private float startPosX;
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
            //R�cup�re la position de la souris.

            Vector2 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            this.gameObject.transform.localPosition = new Vector2(mousePos.x - startPosX, transform.localPosition.y);
        }
    }

    private void OnMouseDown()
    {

        //Si le joueur clique sur le clique gauche, celui-ci r�cup�re la position de la souris et le bouge sur l'axe X.
        if (Input.GetMouseButtonDown(0))
        { 
            Vector2 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            startPosX = mousePos.x - this.transform.localPosition.x;

            isBeingHelg = true;
        }
        
    }

    private void OnMouseUp()
    {
        isBeingHelg = false;
    }
}
