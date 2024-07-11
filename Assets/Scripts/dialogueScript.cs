using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class dialogueScript : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI dialogueText;
    [SerializeField]
    private string[] lines;
    [SerializeField]
    private float textSpeed = 1f;
    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip clickSound;

   
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
        foreach (char letter in lines[index].ToCharArray()) 
        {
            dialogueText.text += letter;
            audioSource.PlayOneShot(clickSound);
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
