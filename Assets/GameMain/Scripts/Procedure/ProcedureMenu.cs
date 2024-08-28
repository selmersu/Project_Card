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
    private bool m_IsChangeProcedure = false;

    protected override void OnEnter(ProcedureOwner procedureOwner)
    {
        base.OnEnter(procedureOwner);
        Log.Debug("进入菜单流程");

        EventComponent Event = UnityGameFramework.Runtime.GameEntry.GetComponent<EventComponent>(); //加载框架Event组件

        UIComponent UI = UnityGameFramework.Runtime.GameEntry.GetComponent<UIComponent>();  //加载框架UI组件

        Event.Subscribe(OpenUIFormSuccessEventArgs.EventId, OnopenUIFormSuccess);

        UI.OpenUIForm("Assets/GameMain/UI/UI_Menu.prefab", "Normal",this);    //加载UI_Menu
    }


    protected override void OnUpdate(ProcedureOwner procedureOwner, float elapseSeconds, float realElapseSeconds)
    {
        base.OnUpdate(procedureOwner, elapseSeconds, realElapseSeconds);

        if (m_IsChangeProcedure)
        {
            // 获取框架场景组件
            SceneComponent Scene = UnityGameFramework.Runtime.GameEntry.GetComponent<SceneComponent>();

            // 卸载所有场景
            string[] loadedSceneAssetNames = Scene.GetLoadedSceneAssetNames();
            for (int i = 0; i < loadedSceneAssetNames.Length; i++)
            {
                Scene.UnloadScene(loadedSceneAssetNames[i]);
            }
            // 加载游戏场景
            Scene.LoadScene("Assets/GameMain/Scenes/Game.unity", this);

            ChangeState<ProcedureGame>(procedureOwner); //切换Game流程
        }
    }


    protected override void OnLeave(ProcedureOwner procedureOwner, bool isShutdown)
    {
        base.OnLeave(procedureOwner, isShutdown);

        GameEntry.Event.Unsubscribe(OpenUIFormSuccessEventArgs.EventId, OnopenUIFormSuccess);

        GameEntry.UI.CloseAllLoadedUIForms();   //关闭所有UI
    }

    private void OnopenUIFormSuccess(object sender, GameEventArgs e)
    {
        OpenUIFormSuccessEventArgs ne = (OpenUIFormSuccessEventArgs)e;
        // 判断userData是否为自己
        if (ne.UserData != this)
        {
            return;
        }
    }

    public void ChangeProcedure()
    {
        m_IsChangeProcedure = true;
    }
}
