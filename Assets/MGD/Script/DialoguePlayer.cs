using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialoguePlayer : MonoBehaviour
{
    public DialogueData[] dialogueDatas; //��ȭ ������
    public Text dialogueText; //��ȭ�� �ݿ��ϴ� Text
    public float typingSpeed = 0.05f; //Ÿ���� �ӵ�

    public float delayBetweenLines = 1.0f; //���� ���
    private int currentDetalndex = 0; //���� ��ȭ ��
    private int currentLine = 0; //
    private Coroutine typingCoroutine; //Ÿ���� �ڷ�ƾ

    private void Start()
    {
        ShowDialogue(0);
    }

    private void ShowDialogue(int index)
    {
        if (index < 0 || index >= dialogueDatas.Length)
        {
            return;
        }

        currentDetalndex = index;
        currentLine = 0;
        ShowNextLine();
    }

    private void ShowNextLine()
    {
        if (typingCoroutine != null)
            StopCoroutine(typingCoroutine);

        DialogueData data = dialogueDatas[currentDetalndex];

        if (currentLine < data.lines.Length)
        {
            typingCoroutine = StartCoroutine(TypeLine(data.lines[currentLine]));
            currentLine++;
        }
        //��ȭ�� ���� ����
        else
        {
            dialogueText.text = "";
            Debug.Log("��ȭ ����!");
        }
    }

    //�ѱ��ھ� ������ ȿ��
    IEnumerator TypeLine(string line)
    {
        dialogueText.text = "";
        //�ѱ��ھ� ���´�
        foreach (char letter in line)
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }

        yield return new WaitForSeconds(delayBetweenLines);

        ShowNextLine();
    }

}
