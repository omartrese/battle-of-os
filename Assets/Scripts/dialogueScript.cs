using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UIElements;
using System.Net.Http.Headers;

public class dialogueScript : MonoBehaviour
{
    private const string STORYTELLER = "storyteller", TUX = "tux", GNU = "gnu", WINDOWS = "windows", MACOS = "macos";

    private enum Sounds
    {
        Storyteller,
        Tux,
        Gnu,
        Windows,
        Macos
    }

    [SerializeField]
    private string[] lines;
    [SerializeField]
    private string[] owners;
    [SerializeField]
    private AudioClip[] audioSources;

    [SerializeField]
    private TextMeshProUGUI dialogueText;
    [SerializeField]
    private TextMeshProUGUI dialogueOwner;
    [SerializeField]
    private float textSpeed = 1f;
    [SerializeField]
    private AudioSource audioSource;
   
    private int index;

    [HideInInspector]
    public bool isActive; 
  
    void Start()
    {
        dialogueText.text = string.Empty;
        //StartDialogue(); 
        gameObject.SetActive(false);
        isActive = true;
    }

    void Update()
    {
       if(Input.GetMouseButtonDown(0))
        {
            if(dialogueText.text == lines[index])
            {
                NextLine();
            } else
            {
                StopAllCoroutines();
                dialogueText.text = lines[index];
            }
        } 
    }

    public void StartDialogue()
    {
        index = 0;
        StartCoroutine(WriteLine());
    }

    IEnumerator WriteLine()
    {

        int sound;

        switch(owners[index].ToLower())
        {
            case STORYTELLER:
                dialogueOwner.text = "Storyteller";
                sound = (int)Sounds.Storyteller;
                break;
            case TUX:
                dialogueOwner.text = "Tux";
                sound = (int)Sounds.Tux;
                break;
            case GNU:
                dialogueOwner.text = "Gnu";
                sound = (int)Sounds.Gnu;
                break;

            default:
                dialogueOwner.text = "Storyteller";
                sound = (int)Sounds.Storyteller;
                break;
        }

        foreach (char letter in lines[index].ToCharArray()) 
        {
            dialogueText.text += letter;
            //audioSource.PlayOneShot(clickSound);
            audioSource.PlayOneShot(audioSources[sound]);
            yield return new WaitForSeconds(textSpeed);
        }

    }

    public void NextLine()
    {
        if(index < lines.Length - 1)
        {
            index++;
            dialogueText.text = string.Empty;
            StartCoroutine(WriteLine());
        } else
        {
            gameObject.SetActive(false);
            isActive = false;
        }
    }

}
