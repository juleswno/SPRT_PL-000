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
    private CubeObject curCubeObject;
    private Camera cam;
    
    private bool isItem;
    private bool isInteraction= true;
    
    private Outline curOutline;
    
    private void Start()
    {
        cam = Camera.main;
    }

    private void Update()
    {
        if(!isInteraction)
            return;
        
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
                    curOutline=hit.collider.GetComponent<Outline>();
                    
                    curInteractable?.FloatScript(true); 
                    
                }

                if (curOutline != null)
                {
                    curOutline.enabled = true;
                }

                if (hit.collider.gameObject.CompareTag("Item"))
                    isItem = true;
                
                curCubeObject = hit.collider.GetComponent<CubeObject>();
                
                if (curCubeObject != null)
                    curCubeObject.isRayOn = true;

            }
            else
            {
                if (curInteractable != null)
                {
                    curInteractable.FloatScript(false);
                }

                if (curCubeObject != null)
                {
                    curCubeObject.isRayOn = false;
                }

                curCubeObject = null;
                curInteractGameObject = null;
                curInteractable = null;
                if (curOutline != null)
                {
                    curOutline.enabled = false;
                }

                isItem = false;
            }
            
            UnInteractInput();
        }
    }
    //--------------------------변경사항------------------------------
    public void LockInteraction()=>isInteraction = true;
    public void UnlockInteraction()=>isInteraction = false;
    
    public void ClearInteraction()
    {
        curInteractable.FloatScript(false);
        curInteractGameObject = null;
        curInteractable = null;
        curEquipObject = null;
        curCubeObject = null;
        curOutline.enabled = false;
        isItem = false;
    }
    //---------------------------------------------------------------

    //Inspecter창에서 event와 연결
    public void OnInteractInput(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started && curInteractGameObject != null && isItem)
        {
            if (curEquipObject != null)
            {
                curEquipObject.OnEquip();
            }
            curInteractable?.OnInteract();
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
