using System;
using UnityEngine;

public class CubeObject : MonoBehaviour
{
    [SerializeField] private GameObject screen;
    [SerializeField] private GameObject descriptionUI;
    
    [SerializeField] private MonoBehaviour playerController;
    
    [HideInInspector] public bool isRayOn;

    private void Update()
    {
        OnScreen();
    }

    private void OnScreen()
    {
        if (Input.GetKeyDown(KeyCode.E) && isRayOn)
        {
            screen.SetActive(true);
            
            if (playerController != null)
                playerController.enabled = false;
            
            if (descriptionUI != null)
                descriptionUI.SetActive(false);
        }
    }

    public void OffScreen()
    {
        screen.SetActive(false);
        
        if (playerController != null)
            playerController.enabled = true;
        
        if (descriptionUI != null)
            descriptionUI.SetActive(true);
    }
}
