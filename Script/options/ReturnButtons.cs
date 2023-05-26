using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnButtons : MonoBehaviour
{
    public GameObject Return;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void returnButton()
    {
        Return.SetActive(false);
    }
}
