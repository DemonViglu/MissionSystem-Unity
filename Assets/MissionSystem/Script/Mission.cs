using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DemonViglu.MissionSystem {
    public class Mission : MonoBehaviour {

        public MissionState missionState;

        public int missionId = -1;

        public List<int> preMissionIDs;

        [Tooltip("Request Number in the mission")]
        [SerializeField] private int _requestNum;

        [SerializeField] private int _rewardNum;

        [SerializeField] private bool _isNumPush;

        public bool canAutoAvailable;

        public bool isAchievement;




        public int currentMissionNum = 0;
        public int requestNum { get { return _requestNum; } private set { } }
        public int rewardNum { get { return _rewardNum; } private set { } }
        public bool isNumPush { get { return _isNumPush; } private set { } }



        public string title;
        public string content;
        [TextArea]
        public string description;
    }
}