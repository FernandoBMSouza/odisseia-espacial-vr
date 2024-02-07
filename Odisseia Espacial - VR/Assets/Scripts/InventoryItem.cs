using UnityEngine;
using UnityEngine.InputSystem;

public class InventoryItem : MonoBehaviour
{
    public bool inSlot;
    public Vector3 slotRotation = Vector3.zero;
    public InventorySlot currentSlot;
    public bool isGripButtonReleased = true;

    public void GripButton(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            isGripButtonReleased = false;

            //Debug.Log("Button was pressed");
            if (gameObject.GetComponent<InventoryItem>() == null)
            {
                return;
            }

            if (gameObject.GetComponent<InventoryItem>().inSlot)
            {
                gameObject.GetComponent<Rigidbody>().isKinematic = false;

                gameObject.GetComponentInParent<InventorySlot>().itemInSlot = null;
                gameObject.transform.parent = null;
                gameObject.GetComponent<InventoryItem>().inSlot = false;
                gameObject.GetComponent<InventoryItem>().currentSlot.ResetColor();
                gameObject.GetComponent<InventoryItem>().currentSlot = null;
            }
        }

        if (context.performed)
        {
            //Debug.Log("Button is being pressed");
        }

        if (context.canceled)
        {
            isGripButtonReleased = true;
            //Debug.Log("Button was released");
        }
    }
}