using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CollectItem : MonoBehaviour
{
    [SerializeField]MissionsObject mission;
    [SerializeField]UnityEvent OnItemCollected;
    // Start is called before the first frame update
    void Start()
    {
        mission.CollectedItems = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Quest Item") 
        {
            Destroy(collision.gameObject);
            OnItemCollected.Invoke();
        }
    }
}
