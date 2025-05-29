using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipObject : MonoBehaviour
{
    public GameObject EquipPrefab;
    private GameObject currentInstance;
    public Transform equipParent;
    public Transform unEquipParent;

    public Rigidbody rb;
    private float delay = 1f;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    
    //새로 장착 (E)
    public void OnEquip()
    {
        rb.useGravity = false;
        if (currentInstance != null)
            return;
        currentInstance = Instantiate(EquipPrefab, equipParent);
    }

    //장착 해제 (Q)
    public void OnUnequip()
    {
        if (currentInstance == null)
            return;
    
        rb.useGravity = true;
        currentInstance.transform.SetParent(unEquipParent);
        EquipPrefab = null;
        StartCoroutine(DelayAction(() => rb.useGravity = false, delay));
    }

    private IEnumerator DelayAction(Action action, float seconds)
    {
        yield return new WaitForSeconds(seconds);
        action();
    }

}
