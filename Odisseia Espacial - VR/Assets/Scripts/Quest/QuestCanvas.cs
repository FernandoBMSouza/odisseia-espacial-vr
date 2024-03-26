using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class QuestCanvas : MonoBehaviour
{
    [SerializeField] Canvas questCanvas;
    [SerializeField] TextMeshProUGUI missionName, missionDescription, missionObjective;
    [SerializeField] MissionsObject missionObject;

    void Start()
    {
        missionObject.CollectedItems = 0;
        missionName.text = missionObject.MissionName;
        missionDescription.text = missionObject.MissionDescription;
        missionObjective.text = "Finalizado " + missionObject.CollectedItems.ToString() + " / " + missionObject.TotalItens.ToString();
    }

    public void UpdateCollectedItems()
    {
        if(missionObject.CollectedItems >= missionObject.TotalItens)
        {
            return;
        }
        else
        {
            missionObject.CollectedItems++;
            missionObjective.text = "Finalizado " + missionObject.CollectedItems.ToString() + " / " + missionObject.TotalItens.ToString();
        }
    }
}
