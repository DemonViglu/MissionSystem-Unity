using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mission : MonoBehaviour{

    public MissionState missionState;

    public int missionId = -1;

    public List<int> preMissionIDs;

    public int requestNum;

    public int rewardNum;

    [TextArea]
    public string description;
}
