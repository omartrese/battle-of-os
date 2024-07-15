using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chapterOneBehaviour : MonoBehaviour
{
    [SerializeField]
    private dialogueScript dialogueScript;

    void Start()
    {
        StartCoroutine(manageScene());
    }

    IEnumerator manageScene()
    {
        yield return new WaitForSeconds(10); // The title fade-in-out animation has 8s duration

        print(dialogueScript.isActive);
        dialogueScript.gameObject.SetActive(true);
        dialogueScript.StartDialogue();


    }
}
