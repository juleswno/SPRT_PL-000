using UnityEngine;
using UnityEngine.InputSystem;

namespace Common.Scripts.Player
{
    public class InputManager : MonoBehaviour
    {
        private Vector2 movementInput;
        public Vector2 MovementInput => movementInput;

        public void OnMove(InputAction.CallbackContext context)
        {
            movementInput = context.ReadValue<Vector2>();
        }
    }
}


