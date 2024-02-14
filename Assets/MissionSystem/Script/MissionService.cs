using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
namespace DemonViglu.MissionSystem {
    public enum MissionState { notAvailable, notStart, onGoing, finished, over }
    public class MissionService : MonoBehaviour {

        [Header("Parameter")]
        public static MissionService instance;

        [SerializeField] private List<Mission> missions = new List<Mission>();
        [SerializeField] private List<IMission> missionObserver = new List<IMission>();
        /// <summary>
        /// Remember to judge the missionID in your funtion
        /// </summary>
        public event Action<int> OnProgressChanged;
        //public event Action<int> OnMissionBegin;
        //public event Action<int> OnMissionEnd;
        //public event Action<int> OnMissionOver;

        private void Awake() {
            if (instance != null) {
                Destroy(instance);
                Debug.LogError("Find another MissionService!");
            }
            instance = this;
        }

        private void Start() {
            RefreshAllMissionState();
            //missionObserver=FindMissionObserver();
            //missions = FindMissionList();
        }


        public void AddProgress(int missionID) {
            Mission tmpMission = FindMission(missionID);
            if (tmpMission == null) {
                return;
            }
            switch (tmpMission.missionState) {
                case MissionState.notAvailable:
                    for (int i = 0; i < tmpMission.preMissionIDs.Count; ++i) {
                        if (FindMission(tmpMission.preMissionIDs[i]).missionState <= MissionState.onGoing) {
                            Debug.Log("MISSIONSERVICE: Mission 的前置任务 Mission " + tmpMission.preMissionIDs[i] + " 还没完成呢");
                            return;
                        }
                    }
                    tmpMission.missionState++;

                    break;

                case MissionState.notStart:
                    tmpMission.missionState++;
                    Debug.Log("MISSIONSERVICE: Mission " + tmpMission.missionId + " 任务被接取了");

                    foreach (IMission p in missionObserver) {
                        p.OnMissionBegin(missionID);
                    }

                    break;

                case MissionState.onGoing:
                    tmpMission.missionState++;
                    Debug.Log("MISSIONSERVICE: Mission " + tmpMission.missionId + " 任务完成了");

                    foreach (IMission p in missionObserver) {
                        p.OnMissionEnd(missionID);
                    }

                    RefreshAllMissionState();
                    break;

                case MissionState.finished:
                    tmpMission.missionState++;
                    //one way to use
                    //another way to use
                    foreach (IMission p in missionObserver) {
                        p.OnMissionCompleted(missionID);
                    }
                    Debug.Log("MISSIONSERVICE: Mission " + tmpMission.missionId + " 任务结束了，（奖励领完）");
                    break;

                case MissionState.over:

                    foreach (IMission p in missionObserver) {
                        p.OnMissionOver(missionID);
                    }

                    Debug.Log("MISSIONSERVICE: Mission " + tmpMission.missionId + " 任务没了");
                    break;
            }
            OnProgressChanged?.Invoke(missionID);
        }

        public void AddMissionNum(int missionID, int deltaMissionNum) {
            Mission tmpMission = FindMission(missionID);
            if (tmpMission == null) {
                return;
            }
            if (!tmpMission.isNumPush) {
                Debug.Log("MISSIONSERVICE: The mission is not pushed by number");
                return;
            }
            switch (tmpMission.missionState) {
                case MissionState.notAvailable:
                    Debug.Log("MISSIONSERVICE: The Mission is not availbable!");
                    break;

                case MissionState.notStart:
                    Debug.Log("MISSIONSERVICE: The Mission has not been started!");
                    break;

                case MissionState.onGoing:
                    tmpMission = FindMission(missionID);
                    if (tmpMission.currentMissionNum + deltaMissionNum >= tmpMission.requestNum) {
                        tmpMission.currentMissionNum = tmpMission.requestNum;
                        AddProgress(missionID);
                    }
                    else {
                        tmpMission.currentMissionNum += deltaMissionNum;
                    }
                    break;

                case MissionState.finished:
                    Debug.Log("MISSIONSERVICE: The Mission has been finished!");
                    break;

                case MissionState.over:
                    Debug.Log("MISSIONSERVICE: The mission has been deleted!");
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
        /// If the mission haven't been finished, finish it directly
        /// </summary>
        /// <param name="missionID"></param>
        public void FinishMissionDirectly(int missionID) {
            Mission tmpMission = FindMission(missionID);
            if (tmpMission.missionState >= MissionState.finished) {
                return;
            }
            else {
                tmpMission.missionState = MissionState.onGoing;
                AddProgress(missionID);
            }
        }


        /// <summary>
        /// Refresh the MissionState, for some missions don't have preMission at start, it will go to notStart
        /// </summary>
        private void RefreshAllMissionState() {
            foreach (Mission a in missions) {
                if (a.missionState == MissionState.notAvailable) {
                    RefreshMissionState(a);
                }
            }
        }

        private void RefreshMissionState(Mission mission) {
            if (!mission.canAutoAvailable) {
                return;
            }
            for (int i = 0; i < mission.preMissionIDs.Count; ++i) {
                if (FindMission(mission.preMissionIDs[i]).missionState <= MissionState.onGoing) {
                    return;
                }
            }
            mission.missionState++;
            Debug.Log("Mission " + mission.missionId + " is Available!");
            if (mission.isAchievement) {
                AddProgress(mission.missionId);
            }
        }

        //private List<IMission> FindMissionObserver() {
        //    IEnumerable<IMission> missions= FindObjectsOfType<MonoBehaviour>().OfType<IMission>();
        //    return new List<IMission>(missions);
        //}

        //private List<Mission> FindMissionList() {
        //    IEnumerable<Mission> missions = FindObjectsOfType<MonoBehaviour>().OfType<Mission>();
        //    return new List<Mission>(missions);
        //}

        public void CheckInIMission(IMission missionObserver) {
            this.missionObserver.Add(missionObserver);
        }

        public List<Mission> GetMissions() {
            return this.missions;
        }

        public void SetMissionNotAvailable(int missionId) {
            FindMission(missionId).missionState = MissionState.notAvailable;
        }
    }
}