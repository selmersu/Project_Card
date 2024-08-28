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
        Log.Debug("����˵�����");

        EventComponent Event = UnityGameFramework.Runtime.GameEntry.GetComponent<EventComponent>(); //���ؿ��Event���

        UIComponent UI = UnityGameFramework.Runtime.GameEntry.GetComponent<UIComponent>();  //���ؿ��UI���

        Event.Subscribe(OpenUIFormSuccessEventArgs.EventId, OnopenUIFormSuccess);

        UI.OpenUIForm("Assets/GameMain/UI/UI_Menu.prefab", "Normal",this);    //����UI_Menu
    }


    protected override void OnUpdate(ProcedureOwner procedureOwner, float elapseSeconds, float realElapseSeconds)
    {
        base.OnUpdate(procedureOwner, elapseSeconds, realElapseSeconds);

        if (m_IsChangeProcedure)
        {
            // ��ȡ��ܳ������
            SceneComponent Scene = UnityGameFramework.Runtime.GameEntry.GetComponent<SceneComponent>();

            // ж�����г���
            string[] loadedSceneAssetNames = Scene.GetLoadedSceneAssetNames();
            for (int i = 0; i < loadedSceneAssetNames.Length; i++)
            {
                Scene.UnloadScene(loadedSceneAssetNames[i]);
            }
            // ������Ϸ����
            Scene.LoadScene("Assets/GameMain/Scenes/Game.unity", this);

            ChangeState<ProcedureGame>(procedureOwner); //�л�Game����
        }
    }


    protected override void OnLeave(ProcedureOwner procedureOwner, bool isShutdown)
    {
        base.OnLeave(procedureOwner, isShutdown);

        GameEntry.Event.Unsubscribe(OpenUIFormSuccessEventArgs.EventId, OnopenUIFormSuccess);

        GameEntry.UI.CloseAllLoadedUIForms();   //�ر�����UI
    }

    private void OnopenUIFormSuccess(object sender, GameEventArgs e)
    {
        OpenUIFormSuccessEventArgs ne = (OpenUIFormSuccessEventArgs)e;
        // �ж�userData�Ƿ�Ϊ�Լ�
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
