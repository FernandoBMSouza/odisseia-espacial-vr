using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MissionSetting", menuName = "Mission")]
public class MissionsObject : ScriptableObject
{
    [SerializeField] string missionName;
    [SerializeField] string missionDescription;
    [SerializeField] int collectedItems, totalItems;


    public string MissionName
    {
        get { return missionName; }
    }
    public string MissionDescription
    {
        get { return missionDescription; }
    }
    public int CollectedItems
    {
        get { return collectedItems; }
        set { collectedItems = value; }
    }

    public int TotalItens
    {
        get { return totalItems; }
    }

}
