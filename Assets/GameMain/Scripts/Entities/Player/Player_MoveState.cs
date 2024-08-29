using GameFramework.Fsm;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityGameFramework.Runtime;

public class Player_MoveState : FsmState<PlayerLogic>
{
    protected override void OnInit(IFsm<PlayerLogic> fsm)
    {
        
    }

    protected override void OnEnter(IFsm<PlayerLogic> fsm)
    {
        Log.Info("进入移动状态");
    }

    protected override void OnUpdate(IFsm<PlayerLogic> fsm, float elapseSeconds, float realElapseSeconds)
    {
        float xInput = Input.GetAxisRaw("Horizontal");
        if (xInput != 0)
        {
            //移动
            fsm.Owner.Forward(elapseSeconds * xInput);
        }
        else
        {
            ChangeState<Player_IdleState>(fsm);
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
