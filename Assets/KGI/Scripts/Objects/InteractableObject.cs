using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public interface IInteractable
{
    public void FloatScript(bool istrue);
}

public class InteractableObject : MonoBehaviour, IInteractable
{
    public TextMeshProUGUI discription;

    //스크립트 ui를 켜는 메서드
    public void FloatScript(bool istrue)
    {
        discription.gameObject.SetActive(istrue);
    }
}
