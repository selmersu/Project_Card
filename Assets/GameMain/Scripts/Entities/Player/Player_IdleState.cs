using GameFramework.Fsm;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityGameFramework.Runtime;

public class Player_IdleState : FsmState<PlayerLogic>
{

    protected override void OnInit(IFsm<PlayerLogic> fsm)
    {
        
    }

    protected override void OnEnter(IFsm<PlayerLogic> fsm)
    {
        Log.Info("����վ��״̬");
    }

    protected override void OnUpdate(IFsm<PlayerLogic> fsm, float elapseSeconds, float realElapseSeconds)
    {
        // �����ҷ�����ƶ�
        float xInput = UnityEngine.Input.GetAxisRaw("Horizontal");
        if (xInput != 0)
        {
            // �л����ƶ�״̬
            ChangeState<Player_MoveState>(fsm);
        }
    }

    protected override void OnLeave(IFsm<PlayerLogic> fsm, bool isShutdown)
    {
        
    }

    protected override void OnDestroy(IFsm<PlayerLogic> fsm)
    {
        base.OnDestroy(fsm);
    }

}
