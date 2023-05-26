using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuHUD : MonoBehaviour
{
    public GameObject canvas;
    private bool isPaused = false;

    // Start is called before the first frame update
    void Start()
    {
        canvas.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            canvas.SetActive(!canvas.activeSelf);
            isPaused = !isPaused;
            Time.timeScale = isPaused ? 0f : 1f;
        }
    }
}
