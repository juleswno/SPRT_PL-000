using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizTrigger : MonoBehaviour
{
    public QuizTextInputUI quizTextInputUI;
    public GameObject quizPanel;
    private void Start()
    {
        quizTextInputUI.OnCorrect += ClearCorrect;
    }

    void ClearCorrect()
    {
        StartCoroutine(CorrectAnimation());
    }

    public IEnumerator CorrectAnimation()
    {
        //애니메이션이나 연츌
        yield return new WaitForSeconds(3f);
        quizPanel.SetActive(false);
    }
}