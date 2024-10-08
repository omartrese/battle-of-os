using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        yield return new WaitUntil(() => !dialogueScript.isActive);

        SceneManager.LoadScene(2); //Load chapter 2

    }
}
