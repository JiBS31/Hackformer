using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Text;
using System;

public class DialogueFolder : MonoBehaviour
{
    public TextMeshProUGUI dialogueTextFolder;
    public string[] linesFolder;
    public float speedTextFolder;
    private int IndexFolder;
    public GameObject DialogueBoxFolder;
    public PlayerMoves Playermoves;
    public Rigidbody2D rbplayer;

    private void Start()
    {
        dialogueTextFolder.text = string.Empty;
        StartDialogueFolder();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            if (dialogueTextFolder.text == linesFolder[IndexFolder])
            {
                nextLineFolder();
            }
            else
            {
                StopAllCoroutines();
                dialogueTextFolder.text = linesFolder[IndexFolder];
            }
        }
    }

    void StartDialogueFolder()
    {
        IndexFolder = 0;
        StartCoroutine(TypeLineFolder());

    }

    IEnumerator TypeLineFolder()
    {
        foreach (char c in linesFolder[IndexFolder].ToCharArray())
        {
            dialogueTextFolder.text += c;
            yield return new WaitForSeconds(speedTextFolder);
        }
    }


    //Prochain texte du dialogue.
    void nextLineFolder()
    {

        if (IndexFolder < linesFolder.Length - 1)
        {
            IndexFolder++;
            dialogueTextFolder.text = string.Empty;
            StartCoroutine(TypeLineFolder());
        }
        else
        {
            gameObject.SetActive(false);
            DialogueBoxFolder.SetActive(false);
        }
    }
}
