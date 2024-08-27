using GameFramework.Event;
using GameFramework.Fsm;
using GameFramework.Procedure;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityGameFramework.Runtime;

public class ProcedureInit : ProcedureBase
{
    protected override void OnInit(IFsm<IProcedureManager> procedureOwner)
    {
        base.OnInit(procedureOwner);
    }

    protected override void OnEnter(IFsm<IProcedureManager> procedureOwner)
    {
        base.OnEnter(procedureOwner);

        Log.Debug("进入初始化流程==================>");

        GameEntry.Event.Subscribe(ShowEntitySuccessEventArgs.EventId, OnShowEntitySucc);

        GameEntry.Entity.ShowEntity<SquareEntityLogic>(1, "Assets/GameMain/Entities/Prefabs/Square.prefab", "Prefabs");
    }

    protected override void OnDestroy(IFsm<IProcedureManager> procedureOwner)
    {
        GameEntry.Event.Unsubscribe(ShowEntitySuccessEventArgs.EventId, OnShowEntitySucc);

        base.OnDestroy(procedureOwner);
    }
    
    private void OnShowEntitySucc(object sender, GameEventArgs e)
    {
        
    }
}
