using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class Windoor : MonoBehaviour
{
    public GameObject Terminal;
    public GameObject Folder;
    public GameObject Bin;
    public GameObject Door;
    public GameObject FolderWindow;
    public GameObject FolderBin;
    private bool isInactive = true;
    private GameObject go;
    public PlayerMoves Player;
    public Camera MainCamera;
    public Camera HackCamera;
    public GameObject Mur;
    public List<TextMeshProUGUI> ReloadText;

    // Start is called before the first frame update
    void Start()
    {
        FolderBin.SetActive(false);
        FolderWindow.SetActive(false);
        Player = Player.GetComponent<PlayerMoves>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Switch(GameObject go)
    {
        go.SetActive(isInactive);
        isInactive = !isInactive;
    }
    
    public void PowerButton()
    {
        Terminal.SetActive(false);
        Player.GetComponent<PlayerMoves>().enabled = true;
        HackCamera.enabled = false;
        MainCamera.enabled = true;
        foreach (TextMeshProUGUI text in ReloadText)
        {
            text.enabled = true;
        }
        Mur.SetActive(false);
    }

    public void ExitFolderButton()
    {
        FolderWindow.SetActive(false);
    }

    public void ExitFolderButtonBin()
    {
        FolderBin.SetActive(false);
    }

    public void FolderOpen()
    {
        FolderWindow.SetActive(true);
    }

    public void Platform_exe()
    {
        Terminal.SetActive(false);
        MainCamera.enabled = false;
        HackCamera.enabled = true;
    }

    public void EmptyBin()
    {
        FolderBin.SetActive(true);
    }
}
