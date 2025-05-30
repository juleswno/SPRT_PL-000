using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Interaction : MonoBehaviour
{
    //플레이어가 ray를 쏴서 오브젝트에 맞도록

    public float checkRate = 0.05f;
    private float lastCheckTime;

    public float maxCheckDistance = 5;
    public LayerMask layerMask;
    
    public GameObject curInteractGameObject;
    public IInteractable curInteractable;

    private EquipObject curEquipObject;
    private Camera cam;
    private bool isItem;
    
    private void Start()
    {
        cam = Camera.main;
    }

    private void Update()
    {
        if (Time.time - lastCheckTime > checkRate)
        {
            lastCheckTime = Time.time;
            
            Ray ray = cam.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
            RaycastHit hit;
            
            //layerMask를 object로 설정, object 레이어가 붙어있는 오브젝트에 반응
            if (Physics.Raycast(ray, out hit, maxCheckDistance, layerMask))
            {
                if (hit.collider.gameObject != curInteractGameObject)
                {
                    curInteractGameObject = hit.collider.gameObject;
                    curInteractable = hit.collider.GetComponent<IInteractable>(); 
                    curEquipObject = hit.collider.GetComponent<EquipObject>();
                    curInteractable?.FloatScript(true); 
                }

                if (hit.collider.gameObject.CompareTag("Item"))
                    isItem = true;
            }
            else
            {
                if (curInteractable != null)
                {
                    curInteractable.FloatScript(false);
                }
                curInteractGameObject = null;
                curInteractable = null;
                isItem = false;
            }
            
            UnInteractInput();
        }
    }

    //Inspecter창에서 event와 연결
    public void OnInteractInput(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started && curInteractGameObject != null && isItem)
        {
            curEquipObject.OnEquip();
            curInteractable?.FloatScript(false);
            curInteractGameObject = null;
            curInteractable = null;
        }
    }

    //작동이 잘 되는지 확인 후 InputSystem으로 옮기기
    public void UnInteractInput()
    {
        if (Input.GetKeyDown(KeyCode.Q) && curEquipObject != null)
        {
            curEquipObject.OnUnequip();
        }
    }
}
