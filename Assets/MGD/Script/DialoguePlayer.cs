using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialoguePlayer : MonoBehaviour
{

    public DialogueData dialogueData;
    public Text dialogueText;
    public float typingSpeed = 0.08f;

    private int cuurentLine = 0;
    private Coroutine typingCoroutine;

    [SerializeField]
    private GameObject MainUI;

    void Start()
    {
        ShowNextLine();
    }

    public void ShowNextLine()
    {
        if (typingCoroutine != null)
            StopCoroutine(typingCoroutine);
        if(cuurentLine< dialogueData.lines.Length)
        {
            typingCoroutine = StartCoroutine(TypeLine(dialogueData.lines[cuurentLine]));
            cuurentLine++;
        }
        else
        {
            //대사가 다 끝난 구간
            dialogueText.text = "";
        }

        
    }

    private IEnumerator TypeLine(string line)
    {
        dialogueText.text = "";

        //들어온 대사를 한글자 반영한다
        foreach (char letter in line.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }

        yield return new WaitForSeconds(2);
        this.gameObject.SetActive(false);
        MainUI.SetActive(true);
    }

}
