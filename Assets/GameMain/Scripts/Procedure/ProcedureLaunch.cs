using GameFramework.DataTable;
using GameFramework.Event;
using GameFramework.Fsm;
using GameFramework.Procedure;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityGameFramework.Runtime;

public class ProcedureLaunch : ProcedureBase
{
    private bool m_IsChangeProcedur = false;

    protected override void OnInit(IFsm<IProcedureManager> procedureOwner)
    {
        base.OnInit(procedureOwner);

        Log.Debug("流程开始");
    }

    protected override void OnEnter(IFsm<IProcedureManager> procedureOwner)
    {
        base.OnEnter(procedureOwner);

        GameEntry.UI.OpenUIForm("Assets/GameMain/UI/UITestForm.prefab", "Normal",this);

        GameEntry.Event.Subscribe(LoadDataTableSuccessEventArgs.EventId,OnLoadDataTableSucc);

        DataTableBase dataTableBase = (DataTableBase) GameEntry.DataTable.CreateDataTable<DREntity>();

        dataTableBase.ReadData("Assets/GameMain/DataTables/Entity.txt", this);

    }

    private void OnLoadDataTableSucc(object sender, GameEventArgs e)
    {
        LoadDataTableSuccessEventArgs ne = (LoadDataTableSuccessEventArgs)e;

        if (ne.UserData == this)
        {
            //加载完成

            IDataTable<DREntity> dt = GameEntry.DataTable.GetDataTable<DREntity>();

            foreach(DREntity entity in dt)
            {
                Log.Debug($"{entity.Id}=={entity.Name}=={entity.Attack}=={entity.Hp}");
            }
        }
    }

    protected override void OnUpdate(IFsm<IProcedureManager> procedureOwner, float elapseSeconds, float realElapseSeconds)
    {
        base.OnUpdate(procedureOwner, elapseSeconds, realElapseSeconds);

        if (m_IsChangeProcedur)
        {
            ChangeState<ProcedureInit>(procedureOwner);
        }
    }

    protected override void OnLeave(IFsm<IProcedureManager> procedureOwner, bool isShutdown)
    {
        GameEntry.Event.Unsubscribe(LoadDataTableSuccessEventArgs.EventId, OnLoadDataTableSucc);

        base.OnLeave(procedureOwner, isShutdown);
    }

    public void ChangeProcedure()
    {
        m_IsChangeProcedur = true;
    }
}
