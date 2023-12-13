using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public enum MissionState { notOpen, notStart, onGoing, finished, over }
public class MissionService : MonoBehaviour
{

    [Header("Parameter")]
    public static MissionService instance;

    [SerializeField]private List<Mission> missions = new List<Mission>();
    /// <summary>
    /// Remember to judge the missionID in your funtion
    /// </summary>
    public event Action<int> OnMissionComplete;

    private void Awake() {
        if (instance != null) {
            Destroy(instance);
            Debug.LogError("Find another MissionService!");
        }
        instance = this;
    }

    private void Start() {
        RefreshAllMissionState();
    }


    public void AddProgress(int missionID) {
        Mission tmpMission=FindMission(missionID);
        if(tmpMission == null) {
            return;
        }

        switch (tmpMission.missionState) {
            case MissionState.notOpen:
                for(int i = 0; i < tmpMission.preMissionIDs.Count; ++i) {
                    if (FindMission(tmpMission.preMissionIDs[i]).missionState <= MissionState.onGoing) {
                        Debug.Log("Mission 的前置任务 Mission " + tmpMission.preMissionIDs[i] + " 还没完成呢");
                        return;
                    }
                }
                tmpMission.missionState++;

                break;

            case MissionState.notStart:
                tmpMission.missionState++;
                Debug.Log("Mission " + tmpMission.missionId + " 任务被接取了");
                break;

            case MissionState.onGoing:
                tmpMission.missionState++;
                Debug.Log("Mission " + tmpMission.missionId + " 任务完成了");
                RefreshAllMissionState();
                break;

            case MissionState.finished:
                tmpMission.missionState++;
                OnMissionComplete(missionID);
                Debug.Log("Mission " + tmpMission.missionId + " 任务结束了，（奖励领完）");
                break;

            case MissionState.over:
                Debug.Log("Mission " + tmpMission.missionId + " 任务没了");
                break;
        
        }

    }

    /// <summary>
    /// Get the MissionState
    /// </summary>
    /// <param name="missionID">the id you look for</param>
    /// <returns></returns>
    public MissionState GetMissionState(int missionID) {
        return FindMission(missionID).missionState;
    }

    /// <summary>
    /// return the Mission having the missionID;
    /// </summary>
    /// <param name="missionID"></param>
    /// <returns></returns>
    public Mission FindMission(int missionID) {
        for (int i = 0; i < missions.Count; ++i) {
            if (missions[i].missionId == missionID) {
                return missions[i];
            }
        }
        Debug.LogError("Couldn't find the mission " + missionID + " !");
        return null;
    }

    /// <summary>
    /// Refresh the MissionState, for some missions don't have preMission at start, it will go to notStart
    /// </summary>
    private void RefreshAllMissionState() {
        foreach(Mission a in missions) {
            if (a.missionState == MissionState.notOpen) {
                RefreshMissionState(a);
            }
        }
    }

    private void RefreshMissionState(Mission mission) {
        for (int i = 0; i < mission.preMissionIDs.Count; ++i) {
            if (FindMission(mission.preMissionIDs[i]).missionState <= MissionState.onGoing) {
                return;
            }
        }
        mission.missionState++;
        Debug.Log("Mission " + mission.missionId + " is Available!");
    }
}
