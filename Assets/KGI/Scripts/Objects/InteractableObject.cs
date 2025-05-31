using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public interface IInteractable
{
    public void FloatScript(bool istrue);
    public void OnInteract();
}

public class InteractableObject : MonoBehaviour, IInteractable
{
    public TextMeshProUGUI discription;
    public GameObject puzzleUIPanel;

    //스크립트 ui를 켜는 메서드
    public void FloatScript(bool istrue)
    {
        discription.gameObject.SetActive(istrue);
    }

    public void OnInteract()
    {
        if (puzzleUIPanel != null)
        {
            var puzzleUI= puzzleUIPanel.GetComponent<IPuzzleUI>();
            if (puzzleUI != null)
            {
                puzzleUI.UIOpen();
                puzzleUI.OnCorrect +=() => puzzleUI.UIClose();
            }
            else
            {
                Debug.Log("not found puzzleUIPanel");
            }
            
        }
    }
}
