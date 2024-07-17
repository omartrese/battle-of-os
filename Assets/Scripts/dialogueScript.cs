using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class dialogueScript : MonoBehaviour
{
    private const string STORYTELLER = "storyteller", TUX = "tux", GNU = "gnu", WIN_DEFENDER = "windefender", WINDOWS = "windows", MACOS = "macos";

    private enum Characters
    {
        Storyteller,
        Tux,
        Gnu,
        WinDefender,
        Windows,
        Macos
    }

    [SerializeField]
    private string[] lines;
    [SerializeField]
    private string[] owners;
    [SerializeField]
    private AudioClip[] audioClips;
    [SerializeField]
    private Sprite[] ownerSprites;

    [SerializeField]
    private TextMeshProUGUI dialogueText;
    [SerializeField]
    private TextMeshProUGUI dialogueOwner;
    [SerializeField]
    private float textSpeed = 1f;
    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private Image ownerImage;


   
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

                sound = (int)Characters.Storyteller;

                ownerImage.gameObject.SetActive(false);
                break;

            case TUX:
                dialogueOwner.text = "Tux";
                
                sound = (int)Characters.Tux;

                ownerImage.gameObject.SetActive(true);
                ownerImage.sprite = ownerSprites[(int)Characters.Tux - 1];
                break;
                
            case GNU:
                dialogueOwner.text = "Gnu";

                sound = (int)Characters.Gnu;

                ownerImage.gameObject.SetActive(true);
                ownerImage.sprite = ownerSprites[(int)Characters.Gnu - 1];
                break;

            case WIN_DEFENDER:
                dialogueOwner.text = "Windows Defender";

                sound = (int)Characters.WinDefender;

                ownerImage.gameObject.SetActive(true);
                ownerImage.sprite = ownerSprites[(int)Characters.WinDefender - 1];
                break;

            default:
                dialogueOwner.text = "Storyteller";

                sound = (int)Characters.Storyteller;

                ownerImage.gameObject.SetActive(false);
                break;
        }

        foreach (char letter in lines[index].ToCharArray()) 
        {
            dialogueText.text += letter;
            //audioSource.PlayOneShot(clickSound);
            audioSource.PlayOneShot(audioClips[sound]);
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
