using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitDoor : MonoBehaviour
{

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Application.Quit();
    }
}
