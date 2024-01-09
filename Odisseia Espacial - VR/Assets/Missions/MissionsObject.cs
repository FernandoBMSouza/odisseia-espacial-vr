using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MissionSetting", menuName = "Mission")]
public class MissionsObject : ScriptableObject
{
    [SerializeField] string missionName;
    [SerializeField] string missionDescription;
    [SerializeField] GameObject missionReward;

    public string MissionName
    {
        get { return missionName; }
    }
    public string MissionDescription
    {
        get { return missionDescription; }
    }
    public GameObject MissionReward
    {
        get { return missionReward; }
    }
}
