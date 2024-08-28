using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameFramework;
using GameFramework.Procedure;
using ProcedureOwner = GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>;
using UnityGameFramework.Runtime;
public class ProcedureGame : ProcedureBase
{
    protected override void OnEnter(ProcedureOwner procedureOwner)
    {
        base.OnEnter(procedureOwner);
        Log.Debug("进入游戏流程");

        EntityComponent entityComponent = UnityGameFramework.Runtime.GameEntry.GetComponent<EntityComponent>();

        entityComponent.ShowEntity<SquareEntityLogic>(1, "Assets/GameMain/Entities/Prefabs/Square.prefab", "Prefabs");

    }
}
