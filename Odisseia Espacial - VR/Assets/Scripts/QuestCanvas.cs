using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestCanvas : MonoBehaviour
{
    [SerializeField] Canvas questCanvas;

    // Start is called before the first frame update
    void Start()
    {
        questCanvas.GetComponent<Canvas>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
