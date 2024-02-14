using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DemonViglu.MissionSystem {
    public class MissionUIManager : MonoBehaviour,IMission {

        [SerializeField] private Button missionEntryButton;
        [SerializeField] private GameObject missionListUIPanel;

        [SerializeField] private GameObject missionListUIPrefab;
        [SerializeField] private GameObject missionListUIContent;


        [SerializeField] private GameObject achievementUI;
        [SerializeField] private Text achievementTitle;
        [SerializeField] private Text achievementDescription;

        [SerializeField] private MissionService missionService;

        List<Mission> missions = new List<Mission>();

        private void Start() {
            missionEntryButton.onClick.AddListener(() =>
            {
                missionListUIPanel.SetActive(!missionListUIPanel.activeSelf);
                RefreshMissionListUI();
            });
            missionService.OnProgressChanged += RefreshMissionListUI;
            missionService.CheckInIMission(this);
        }
        
        private void RefreshMissionListUI(int missionId=0) {
            for (int i = 0; i < missionListUIContent.transform.childCount; ++i) {
                Destroy(missionListUIContent.transform.GetChild(i).gameObject);
            }
            missions =missionService.GetMissions();
            foreach(var mission in missions) {
                if (mission.missionState == MissionState.notAvailable) {
                    continue;
                }
                else {
                    GameObject tmp = Instantiate(missionListUIPrefab, missionListUIContent.transform);
                    tmp.GetComponent<MissionListUI>().SetMissionUI(mission);
                    tmp.GetComponent<MissionListUI>().onButtonClick += AddProgress;
                }
            }
        }

        public void AddProgress(int missionId) {
            missionService.AddProgress(missionId);
        }

        void IMission.OnMissionBegin(int missionID) {
        }

        void IMission.OnMissionEnd(int missionID) {
            Mission tmp=missionService.FindMission(missionID);
            if (tmp.isAchievement) {
                StartCoroutine("ShowAchievement", tmp);
            }
        }

        void IMission.OnMissionCompleted(int missionID) {
        }

        void IMission.OnMissionOver(int missionID) {
        }

        IEnumerator ShowAchievement(Mission mission) {

            achievementTitle.text = mission.title;
            achievementDescription.text = mission.description;
            achievementUI.SetActive(true);
            yield return new WaitForSeconds(1.5f);
            achievementUI.SetActive(false);
        }
    }
}

