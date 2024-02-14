using DemonViglu.MissionSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonViglu_MissionService_TestExample : MonoBehaviour,IMission
{
    private void Start() {
        MissionService.instance.CheckInIMission(this);
    }
    public int MissionID;
    void IMission.OnMissionBegin(int missionID) {

    }

    void IMission.OnMissionCompleted(int missionID) {

    }

    void IMission.OnMissionEnd(int missionID) {
        if (missionID == MissionID) {
            Debug.Log("完成任务！，与爱莉希雅进行一次对话");
        }
    }

    void IMission.OnMissionOver(int missionID) {

    }
}
