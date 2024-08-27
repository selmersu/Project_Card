using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameFramework;
using GameFramework.Procedure;
using UnityGameFramework.Runtime;
using ProcedureOwner = GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>;

public class ProcedureLaunch : ProcedureBase
{

    protected override void OnEnter(ProcedureOwner procedureOwner)
    {
        base.OnEnter(procedureOwner);

        Log.Debug("��ʼ����");
        SceneComponent scene = UnityGameFramework.Runtime.GameEntry.GetComponent<SceneComponent>();

        scene.LoadScene("Assets/GameMain/Scenes/Menu.unity", this); //�л�����

        ChangeState<ProcedureMenu>(procedureOwner);
    }

}
