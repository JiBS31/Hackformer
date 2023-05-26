using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HackMomentOption : MonoBehaviour
{
    public GameObject UIHackmoment;
    public GameObject none_1;
    public GameObject none_2;
    public GameObject none_3;
    public GameObject Plateforme_Hack;
    public GameObject folder;

    // Start is called before the first frame update
    void Start()
    {
        UIHackmoment.SetActive(true);
        none_1.SetActive(true);
        none_2.SetActive(true);
        none_3.SetActive(true);
        Plateforme_Hack.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(folder == false)
        {
            none_1.SetActive(false);
            Plateforme_Hack.SetActive(true);
        }

    }
}
