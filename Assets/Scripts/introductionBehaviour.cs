using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class introductionBehaviour : MonoBehaviour
{
    [SerializeField]
    private dialogueScript dialogueScript;

    [SerializeField]
    private mainMenuScript mainMenuScript;

    void Start()
    {
        StartCoroutine(manageScene());
    }

    IEnumerator manageScene()
    {
        yield return new WaitForSeconds(2);

        print(dialogueScript.isActive);
        dialogueScript.gameObject.SetActive(true);
        dialogueScript.StartDialogue();

        yield return new WaitUntil(() => !dialogueScript.isActive);

        mainMenuScript.gameObject.GetComponent<Animator>().SetBool("activeMenu", true);
        mainMenuScript.gameObject.SetActive(true);
    }

}
