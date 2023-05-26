using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Text;
using System;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    public string[] lines;
    public float speedText;
    private int Index;
    public GameObject DialogueBox;
    public PlayerMoves Playermoves;
    public Rigidbody2D rbplayer;

    private void Start()
    {
        dialogueText.text = string.Empty;
        StartDialogue();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            if(dialogueText.text == lines[Index])
            {
                nextLine();
            }
            else
            {
                StopAllCoroutines();
                dialogueText.text = lines[Index];
            }
        }
    }

    void StartDialogue()
    {
        Index = 0;
        StartCoroutine(TypeLine());

    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[Index].ToCharArray())
        {
            dialogueText.text += c;
            yield return new WaitForSeconds(speedText);
        }
    }


    //Prochain texte du dialogue.
    void nextLine()
    {

        if(Index < lines.Length - 1)
        {
            Index++;
            dialogueText.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            gameObject.SetActive(false);
            DialogueBox.SetActive(false);
        }
    }

}
