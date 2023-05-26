using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlatformeExecutor : MonoBehaviour
{
    public Camera MainCamera;
    public Camera HackCamera;
    public GameObject Terminal_UI;
    public TextMeshProUGUI EscapeText;
    public List<TextMeshProUGUI> ReloadText;
    public PlayerMoves Moves;
    public GameObject Player;
    public bool isActive = false;
    public GameObject Mur;
    [SerializeField] public List<GameObject> BlueCofter;

    // Start is called before the first frame update
    void Start()
    {
        Moves = Player.GetComponent<PlayerMoves>();
        EscapeText.enabled = false;
        foreach (GameObject Blue in BlueCofter)
        {
            Blue.SetActive(false);
        }
    }

    public void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            backTurnToPandallum();
        }
    }

    // Update is called once per frame
    public void backTurnToPandallum()
    {
        MainCamera.enabled = true;
        HackCamera.enabled = false;
        EscapeText.enabled = false;
        Moves.enabled = true;
        Mur.SetActive(false);
        Terminal_UI.SetActive(false);
        foreach (TextMeshProUGUI Text in ReloadText)
        {
            Text.enabled = true;
        }
        foreach (GameObject Blue in BlueCofter)
        {
            Blue.SetActive(false);
        }
    }



    public void Exexutor()
    {
        foreach (TextMeshProUGUI Text in ReloadText)
        {
            Text.enabled = false;
        }
        MainCamera.enabled = false;
        HackCamera.enabled = true;
        EscapeText.enabled = true;
        Terminal_UI.SetActive(false);
        foreach (GameObject Blue in BlueCofter)
        {
            Blue.SetActive(true);
        }
        isActive = true;
    }
}
