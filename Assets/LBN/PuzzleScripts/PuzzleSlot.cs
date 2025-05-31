using UnityEngine;

public class PuzzleSlot : MonoBehaviour
{
    public ItemType requiredType;        // �¾ƾ� �ϴ� ���� Ÿ��
    public PuzzleManager manager;

    private bool isCorrect = false;
    public bool IsCorrect => isCorrect;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Item"))
        {
            ItemData item = other.GetComponent<ItemData>();
            if (item != null && item.itemType == requiredType)
            {
                isCorrect = true;
                manager.CheckAllSlots();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Item"))
        {
            ItemData item = other.GetComponent<ItemData>();
            if (item != null && item.itemType == requiredType)
            {
                isCorrect = false;
                manager.CheckAllSlots();
            }
        }
    }
}


