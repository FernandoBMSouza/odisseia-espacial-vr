using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public GameObject itemInSlot;
    public Image image;

    public void ResetColor()
    {
        image.color = Color.white;
    }
}