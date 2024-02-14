using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DemonViglu.DialogSystemManager;
using UnityEngine.Events;

/// <summary>
/// 对话事件持有类，基于DemonViglu_DIalogSystem_TestExample改写
/// 用于给对话选项绑定事件
/// </summary>
public class DialogEventHandle : MonoBehaviour
{
    [SerializeField] private DialogSystemManager m_dialogSystemManager;
    [Serializable]  public class StringEvent : UnityEvent <string> {}

    public StringEvent stringEvent;

    private void Start() {
        m_dialogSystemManager.missionEventHandler._OnEveryMissionEnd += OnMissionSOEnd;
        m_dialogSystemManager.missionEventHandler._OnMissionTreeEnd += OnMissionTreeEnd;
        m_dialogSystemManager.missionEventHandler._OnOptionClick += ClickOption;
    }

    private void OnMissionSOEnd(int index) {
        Debug.Log("DialogSO is finish which is index :" + index +" in the SOManager");
    }

    private void OnMissionTreeEnd(int index) {
        Debug.Log("DialogSO Tree is finish which is index :" + index + " in the SOManager");
    }

    public void UseObjectToCallBack() {
        Debug.Log("I'm Trigger by the MissionObject in the Hierachy, look at the eventHandler for help");
    }

    public void ClickOption(int SOindex,int optionIndex) {
        Debug.Log(SOindex + "->" + optionIndex + " 's event is called");
    }
}


