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
        Log.Debug("进入菜单流程");

        EventComponent Event = UnityGameFramework.Runtime.GameEntry.GetComponent<EventComponent>(); //加载框架Event组件

        UIComponent UI = UnityGameFramework.Runtime.GameEntry.GetComponent<UIComponent>();  //加载框架UI组件

        Event.Subscribe(OpenUIFormSuccessEventArgs.EventId, OnopenUIFormSuccess);

        UI.OpenUIForm("Assets/GameMain/UI/UI_Menu.prefab", "Normal",this);    //加载UI
    }

    private void OnopenUIFormSuccess(object sender, GameEventArgs e)
    {
        OpenUIFormSuccessEventArgs ne = (OpenUIFormSuccessEventArgs)e;
        // 判断userData是否为自己
        if (ne.UserData != this)
        {
            return;
        }
        Log.Debug("UI_Menu回调成功");
    }
}
