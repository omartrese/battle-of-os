using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class chatperTwoBehaviour : MonoBehaviour
{
    [SerializeField]
    private dialogueScript dialogueScript;

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
        SceneManager.LoadScene(3); // Load Chapter two match (first game combat)

    }
}
