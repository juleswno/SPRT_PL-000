using UnityEngine;

public class EquipObject : MonoBehaviour
{
    public Transform equipParent;
    public Transform unEquipParent;

    private Transform originalParent;
    private Vector3 originLocalPos;
    private Quaternion originLocalRot;

    public Rigidbody rb;
    private float delay = 1f;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    
    //새로 장착 (E)
    public void OnEquip()
    {
        //원래의 위치 백업
        originalParent = transform.parent;
        originLocalPos = transform.localPosition;
        originLocalRot = transform.localRotation;
        
        rb.useGravity = false;
        rb.isKinematic = true;
        transform.SetParent(equipParent, false);
        transform.localPosition = new Vector3(1f, 1f, 1f);
        //transform.localRotation = Quaternion.Euler(17f, 0f, 19f);
    }

    //장착 해제 (Q)
    public void OnUnequip()
    {
        rb.useGravity = true;
        rb.isKinematic = false;
        
        transform.SetParent(unEquipParent ? unEquipParent : originalParent);
        transform.localPosition = originLocalPos;
        transform.localRotation = originLocalRot;
    }
}
