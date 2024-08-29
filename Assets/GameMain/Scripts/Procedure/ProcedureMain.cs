using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameFramework;
using GameFramework.Procedure;
using ProcedureOwner = GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>;
using UnityGameFramework.Runtime;
public class ProcedureMain : ProcedureBase
{
    protected override void OnEnter(ProcedureOwner procedureOwner)
    {
        base.OnEnter(procedureOwner);
        Log.Debug("进入游戏主要场景流程");

        EntityComponent entityComponent = UnityGameFramework.Runtime.GameEntry.GetComponent<EntityComponent>();

        entityComponent.ShowEntity<PlayerLogic>(1, "Assets/GameMain/Entities/Player/Player.prefab", "Prefabs");

    }
}
