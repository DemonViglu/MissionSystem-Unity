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
            Debug.Log("������񣡣��밮��ϣ�Ž���һ�ζԻ�");
        }
    }

    void IMission.OnMissionOver(int missionID) {

    }
}
