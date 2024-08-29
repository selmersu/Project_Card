using GameFramework.Fsm;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityGameFramework.Runtime;

public class PlayerLogic : EntityLogic
{
    private GameFramework.Fsm.IFsm<PlayerLogic> m_PlayerFsm;

    private FsmComponent Fsm = null;

    public Rigidbody2D rb;

    protected override void OnInit(object userData)
    {
        base.OnInit(userData);
        rb = GetComponent<Rigidbody2D>();

        Fsm = UnityGameFramework.Runtime.GameEntry.GetComponent<FsmComponent>();
        
        //��ҵ�����״̬��
        FsmState<PlayerLogic>[] playerStates = new FsmState<PlayerLogic>[] { 
            new Player_IdleState(),
            new Player_MoveState(),
        };
            
        //����״̬��
        m_PlayerFsm = Fsm.CreateFsm<PlayerLogic> (this, playerStates);

        //����վ��״̬
        m_PlayerFsm.Start<Player_IdleState>();

    }

    internal void Forward(float v)
    {
        rb.velocity = new Vector2(100 * v, rb.velocity.y);
    }
}
