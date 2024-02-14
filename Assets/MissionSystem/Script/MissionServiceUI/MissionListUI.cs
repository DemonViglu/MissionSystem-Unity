using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DemonViglu.MissionSystem {
    public class MissionListUI : MonoBehaviour {

        [SerializeField] private Text title;
        [SerializeField] private Text content;
        [SerializeField] private Text progress;
        [SerializeField] private GameObject rewardButton;

        [SerializeField] private int missionID;

        public event Action<int> onButtonClick;

        private void Start() {
            rewardButton.GetComponent<Button>().onClick.AddListener(() => {
                onButtonClick?.Invoke(missionID);
            });
        }
        public void SetMissionUI(Mission mission) {
            title.text = mission.title;
            content.text=mission.content;
            missionID = mission.missionId;


            switch (mission.missionState) {
                case MissionState.notAvailable:
                    break;
                case MissionState.notStart:
                    progress.gameObject.SetActive(false);
                    rewardButton.GetComponentInChildren<Text>().text = "接取!";
                    rewardButton.SetActive(true);
                    break;
                case MissionState.onGoing:
                    rewardButton.SetActive(false);
                    if (mission.isNumPush) {
                        progress.text = mission.currentMissionNum + "/" + mission.requestNum;
                    }
                    else {
                        progress.text = mission.missionState.ToString();
                    }
                    progress.gameObject.SetActive(true);
                    break;
                case MissionState.finished:
                    progress.gameObject.SetActive(false);
                    rewardButton.GetComponentInChildren<Text>().text = "奖励!";
                    rewardButton.SetActive(true);
                    break;
                case MissionState.over:
                    rewardButton.SetActive(false);
                    progress.text = "已领取";
                    break;
            
            }

        }
    }
}

