using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class mainMenuScript : MonoBehaviour
{

    [SerializeField]
    private GameObject settingsMenu;
    //private Button startBtn, settingsBtn;

    public void activateSettings()
    {
        settingsMenu.SetActive(true);
        gameObject.SetActive(false);
    }

    public void deactivateSettings()
    {
        settingsMenu?.SetActive(false);
        gameObject.SetActive(true);
    }

    public void startGame()
    {
        SceneManager.LoadScene(1); // Pasar a la siguiente escena (Cap1 = index 1)
    }
}
