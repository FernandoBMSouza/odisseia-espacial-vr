using UnityEngine;

public class Item : MonoBehaviour
{
    public bool inSlot;
    public bool collidingWithSlot;
    public Slot currentSlot;
    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.GetComponent<Slot>())
        {
            collidingWithSlot = true;
            currentSlot = other.gameObject.GetComponent<Slot>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<Slot>())
        {
            collidingWithSlot = false;
            currentSlot = null;
        }
    }

    private void FixedUpdate()
    {
        if (inSlot)
        {
            transform.localPosition = Vector3.zero;
            transform.localEulerAngles = Vector3.zero;
        }
    }

    public void InsertInSlot()
    {
        if (collidingWithSlot)
        {
            Debug.Log("Entrei no Slot");
            inSlot = true;
            currentSlot.itemInSlot = this.gameObject;
            transform.SetParent(currentSlot.transform, true);
            rb.isKinematic = true;
            currentSlot.image.color = Color.gray;
        }
        else
        {
            transform.parent = null;
            rb.isKinematic = false;
        }
    }

    public void RemoveFromSlot()
    {
        if(inSlot)
        {
            //rb.isKinematic = false; --> Não precisa dessa linha pq passei ela pro else da InsertInSlot() pra resolver o erro
            inSlot = false;
            transform.parent = null;

            currentSlot.ResetColor();
            currentSlot.itemInSlot = null;
        }
    }
}
