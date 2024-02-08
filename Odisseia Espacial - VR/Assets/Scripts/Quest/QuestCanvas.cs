using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuestCanvas : MonoBehaviour
{
    [SerializeField] Canvas questCanvas;
    [SerializeField] TextMeshProUGUI missionName, missionDescription, missionObjective;
    [SerializeField] MissionsObject missionObject;

    // Start is called before the first frame update
    void Start()
    {
        missionName.text = missionObject.MissionName;
        missionDescription.text = missionObject.MissionDescription;
        missionObjective.text = "Coletados " + missionObject.CollectedItems.ToString() + " / " + missionObject.TotalItens.ToString();
    }

    public void UpdateCollectedItems()
    {
        missionObject.CollectedItems++;
        missionObjective.text = "Coletados " + missionObject.CollectedItems.ToString() + " / " + missionObject.TotalItens.ToString();
    }
    
}
