using System;
using UnityEngine;


public interface IPuzzleUI
{
    event Action OnCorrect;
    void UIOpen();
    void UIClose();
}
