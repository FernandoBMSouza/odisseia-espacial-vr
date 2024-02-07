using System;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public GameObject itemInSlot;
    public Image slotImage;
    Color originalColor;

    void Start()
    {
        slotImage = GetComponent<Image>();
        originalColor = slotImage.color;
    }

    // Chamado todos os frames em que um objeto "other" está colidindo com o colisor
    private void OnTriggerStay(Collider other)
    {
        if (itemInSlot != null)
            return;

        GameObject obj = other.gameObject;

        // Checa se obj tem o script dos itens, para saber se é um item
        if (!IsItem(obj))
            return;

        // Checa se o jogador soltou o item, caso sim ele entra no slot
        InventoryItem otherItem = other.GetComponent<InventoryItem>();

        if (otherItem.isGripButtonReleased)
        {
            InsertItem(obj);
            otherItem.isGripButtonReleased = false;
        }
    }

    private void InsertItem(GameObject obj)
    {
        obj.GetComponent<Rigidbody>().isKinematic = true;
        obj.transform.SetParent(gameObject.transform, true);
        obj.transform.localPosition = Vector3.zero;
        obj.transform.localEulerAngles = obj.GetComponent<InventoryItem>().slotRotation;
        obj.GetComponent<InventoryItem>().inSlot = true;
        obj.GetComponent<InventoryItem>().currentSlot = this;
        itemInSlot = obj;
        slotImage.color = Color.gray;
    }

    private bool IsItem(GameObject obj)
    {
        return obj.GetComponent<InventoryItem>();
    }

    public void ResetColor()
    {
        slotImage.color = originalColor;
    }

    
}
