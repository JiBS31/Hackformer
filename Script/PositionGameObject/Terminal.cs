using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Terminal : MonoBehaviour
{
    public GameObject player;
    public float distance = 2f;
    public GameObject boutonCaché;
    public GameObject TerminalMachine;
    public Camera MainCamera;
    public Camera HackCamera;
    private bool isCameraEnabled;
    public float SpeedLerp;
    private Animator animPlayer;
    private Rigidbody2D rbplayer;
    public GameObject mur;
    public GameObject Windoor;
    public GameObject Folder;
    public GameObject PowerWindow;
    public List<TextMeshProUGUI> ReloadText;

    private void Start()
    {
        Windoor.SetActive(false);
        mur.SetActive(false);
        boutonCaché.SetActive(false);
        HackCamera.enabled = false;
        animPlayer = player.GetComponent<Animator>();
    }

    void Update()
    {
        // Vérifie si le joueur est à proximité du GameObject
        if (Vector2.Distance(player.transform.position, TerminalMachine.transform.position) <= distance)
        {
            boutonCaché.SetActive(true);

            // Vérifie si le joueur appuie sur la touche "E"
            if (Input.GetKeyDown(KeyCode.E))
            {
                player.GetComponent<PlayerMoves>().enabled = false;
                animPlayer.SetBool("isRunning", false);
                mur.SetActive(true);
                Windoor.SetActive(true);
                Folder.SetActive(false);
                foreach (TextMeshProUGUI Text in ReloadText)
                {
                    Text.enabled = false;
                }
                PowerWindow.SetActive(false);

            }

        }
        else
        {
            boutonCaché.SetActive(false);
            
        }

    }
}

