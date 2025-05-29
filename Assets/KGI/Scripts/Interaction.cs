using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    //플레이어가 ray를 쏴서 오브젝트에 맞도록

    public float checkRate = 0.05f;
    private float lastCheckTime;

    public float maxCheckDistance = 5;
    public LayerMask layerMask;
    
    public GameObject curInteractctGameObject;
    public IInteractable curInteractable;
    
    private Camera camera;
    
    private void Start()
    {
        camera = Camera.main;
    }

    private void Update()
    {
        if (Time.time - lastCheckTime > checkRate)
        {
            lastCheckTime = Time.time;
            
            Ray ray = camera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
            RaycastHit hit;
            
            //layerMask를 object로 설정, object 레이어가 붙어있는 
            if (Physics.Raycast(ray, out hit, maxCheckDistance, layerMask))
            {
                if (hit.collider.gameObject != curInteractctGameObject)
                {
                    curInteractctGameObject = hit.collider.gameObject;
                    curInteractable = hit.collider.GetComponent<IInteractable>(); 
                    curInteractable.FloatScript(true); 
                }
            }
            else
            {
                if (curInteractable != null)
                {
                    curInteractable.FloatScript(false);
                }
                curInteractctGameObject = null;
                curInteractable = null;
            }
        }
    }
}
