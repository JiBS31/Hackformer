using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadLevel : MonoBehaviour
{
    public GameObject Dialogue;
    public GameObject Folder;
    public GameObject NotChargedButton;

    // Start is called before the first frame update
    void Start()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("SampleScene");
            Dialogue.SetActive(false);
            Folder.SetActive(false);
            NotChargedButton.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
