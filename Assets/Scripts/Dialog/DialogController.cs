using UnityEngine;
using TMPro;

public class DialogController : MonoBehaviour
{
    public static DialogController instance;

    [SerializeField] TextMeshProUGUI dialogText, nameText;
    [SerializeField] GameObject dialogBox, nameBox;
    
    [SerializeField] string[] dialogSentences;
    [SerializeField] int currentSenteces;

    private bool dialogJustStarted;

    void Start()
    {
        instance = this;
        dialogText.text = dialogSentences[currentSenteces];
    }
    void Update()
    {
        DialogLogic();
    }
    private void DialogLogic()
    {
        if (dialogBox.activeInHierarchy)
        {
            if (Input.GetButtonUp("Fire1"))
            {
                if (!dialogJustStarted)
                {
                    currentSenteces++;
                    if (currentSenteces >= dialogSentences.Length)
                    {
                        dialogBox.SetActive(false);
                    }
                    else
                    {
                        dialogText.text = dialogSentences[currentSenteces];
                    }
                }
                else
                {
                    dialogJustStarted = false;
                }
            }
        }
    }
    public void ActivatedDialog(string[] newSentencesToUse)
    {
        dialogSentences = newSentencesToUse;
        currentSenteces = 0;

        dialogText.text = dialogSentences[currentSenteces];
        dialogBox.SetActive(true);

        dialogJustStarted = true;
    }
    public bool IsDialogBoxActive()
    {
        return dialogBox.activeInHierarchy;
    }
}
