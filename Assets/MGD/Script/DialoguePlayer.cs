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
            //��簡 �� ���� ����
            dialogueText.text = "";
        }

        
    }

    private IEnumerator TypeLine(string line)
    {
        dialogueText.text = "";

        //���� ��縦 �ѱ��� �ݿ��Ѵ�
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
