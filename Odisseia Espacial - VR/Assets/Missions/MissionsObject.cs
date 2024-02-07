using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MissionSetting", menuName = "Mission")]
public class MissionsObject : ScriptableObject
{
    [SerializeField] Canvas canvas;
    [SerializeField] string missionName;
    [SerializeField] string missionDescription;

    public string MissionName
    {
        get { return missionName; }
    }
    public string MissionDescription
    {
        get { return missionDescription; }
    }
}
