using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class Player : MonoBehaviour
{


    [SerializeField] private int mission_1ID;
    [SerializeField] private int mission_2ID;

    [Header("Gold")]
    public int GoldNum;

    private void Start() {
        MissionService.instance.OnMissionComplete += OnMission_1Complete;
        MissionService.instance.OnMissionComplete += OnMission_2Complete;
    }


    public void Mission_1Logic() {
        MissionService.instance.AddProgress(mission_1ID);
    }
    public void Mission_2Logic() {
        MissionService.instance.AddProgress(mission_2ID);
    }
    public void OnMission_1Complete(int missionID) {
        if (missionID == mission_1ID) {
            Debug.Log("Mission_1 is Finished successfully!");
            GoldNum += MissionService.instance.FindMission(missionID).rewardNum;
        }
    }

    public void OnMission_2Complete(int missionID) {
        if (missionID == mission_2ID) {
            Debug.Log("Mission_2 is Finished successfully!");
            GoldNum += MissionService.instance.FindMission(missionID).rewardNum;
        }
    }

}
