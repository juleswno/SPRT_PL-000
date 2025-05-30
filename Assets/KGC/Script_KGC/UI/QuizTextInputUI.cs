using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuizTextInputUI : MonoBehaviour
{
    public TMP_InputField inputField;
    public UnityEngine.UI.Button submitButton;
    public GameObject slotPrefab;
    public Transform slotParent;
    public string correctAnswer;
        
    private GameObject[] slots;

    private void Start()
    {
        CreateSlot();
        submitButton.onClick.AddListener(CheckAnswer);
    }

    void CreateSlot()
    {
        slots = new GameObject[correctAnswer.Length];

        for (int i = 0; i < correctAnswer.Length; i++)
        {
            GameObject slot = Instantiate(slotPrefab, slotParent);
            slot.GetComponentInChildren<TMP_Text>().text = "_";
            slots[i] = slot;
        }
    }

    void CheckAnswer()
    {
        string userInputText = inputField.text.Trim().ToLower();

        if (userInputText == correctAnswer.ToLower())
        {
            for (int i = 0; i < correctAnswer.Length; i++)
            {
                slots[i].GetComponentInChildren<TMP_Text>().text = correctAnswer[i].ToString().ToLower();
            }
        }
        else
        {
            for (int i = 0; i < correctAnswer.Length; i++)
            {
                slots[i].GetComponentInChildren<TMP_Text>().text = "_";
            }
        }
        
        
    }
}
