using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CollectItem : MonoBehaviour
{
    [SerializeField]MissionsObject mission;
    [SerializeField]UnityEvent OnItemCollected;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Quest Item") 
        {
            Destroy(collision.gameObject);
            OnItemCollected.Invoke();
        }
    }
}
