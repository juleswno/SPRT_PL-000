using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    public PuzzleSlot[] slots;
    public GameObject door;

    public void CheckAllSlots()
    {
        foreach (var slot in slots)
        {
            if (!slot.IsCorrect)
                return;
        }

        OpenDoor();
    }

    private void OpenDoor()
    {
        door.SetActive(false); // ¹® ¿­¸²
    }
}
