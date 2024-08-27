using System;
using System.Collections;
using System.Collections.Generic;
using GameFramework;
using GameFramework.Event;
using GameFramework.Procedure;
using UnityEngine;
using UnityGameFramework.Runtime;
using ProcedureOwner = GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>;

public class ProcedureMenu : ProcedureBase
{

    protected override void OnEnter(ProcedureOwner procedureOwner)
    {
        base.OnEnter(procedureOwner);
        Log.Debug("����˵�����");

        EventComponent Event = UnityGameFramework.Runtime.GameEntry.GetComponent<EventComponent>(); //���ؿ��Event���

        UIComponent UI = UnityGameFramework.Runtime.GameEntry.GetComponent<UIComponent>();  //���ؿ��UI���

        Event.Subscribe(OpenUIFormSuccessEventArgs.EventId, OnopenUIFormSuccess);

        UI.OpenUIForm("Assets/GameMain/UI/UI_Menu.prefab", "Normal",this);    //����UI
    }

    private void OnopenUIFormSuccess(object sender, GameEventArgs e)
    {
        OpenUIFormSuccessEventArgs ne = (OpenUIFormSuccessEventArgs)e;
        // �ж�userData�Ƿ�Ϊ�Լ�
        if (ne.UserData != this)
        {
            return;
        }
        Log.Debug("UI_Menu�ص��ɹ�");
    }
}
