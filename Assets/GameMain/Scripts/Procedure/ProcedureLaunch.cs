using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameFramework;
using GameFramework.Procedure;
using UnityGameFramework.Runtime;
using ProcedureOwner = GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>;
using GameFramework.Event;
using System;
using GameFramework.DataTable;
using GameFramework.Fsm;
using System.Data;
using System.Linq;


public class ProcedureLaunch : ProcedureBase
{

    protected override void OnEnter(ProcedureOwner procedureOwner)
    {
        base.OnEnter(procedureOwner);

        Log.Debug("��ʼ����");
        

        //���ݱ��ȡ
        EventComponent Event = UnityGameFramework.Runtime.GameEntry.GetComponent<EventComponent>(); //��ȡ����¼����
        
        Event.Subscribe(LoadDataTableSuccessEventArgs.EventId, OnLoadDataTableSuccess); 

        DataTableBase dataTableBase = (DataTableBase)GameEntry.DataTable.CreateDataTable<DRPlayer>();

        dataTableBase.ReadData("Assets/GameMain/DataTables/Player_Data.txt", this);
        

        //��ȡ��ܳ������
        SceneComponent scene = UnityGameFramework.Runtime.GameEntry.GetComponent<SceneComponent>();

        scene.LoadScene("Assets/GameMain/Scenes/Menu.unity", this); //�л�Menu����

        ChangeState<ProcedureMenu>(procedureOwner); //�л�Menu����
    }

    /*protected override void OnLeave(ProcedureOwner procedureOwner, bool isShutdown)
    {
        GameEntry.Event.Unsubscribe(LoadDataTableSuccessEventArgs.EventId, OnLoadDataTableSuccess);

        base.OnLeave(procedureOwner, isShutdown);
    }*/

    private void OnLoadDataTableSuccess(object sender, GameEventArgs e)
    {
        //���Զ�ȡ������ɵ��ļ�����
        DataTableComponent DataTable = UnityGameFramework.Runtime.GameEntry.GetComponent<DataTableComponent>();  // ��ȡ������ݱ����
        // ������ݱ�
        IDataTable<DRPlayer> dtScene = DataTable.GetDataTable<DRPlayer>();

        // ���������,���Ҵ���һ�� List ���洢������
        List<DRPlayer> drPlayer = new List<DRPlayer>();
        dtScene.GetAllDataRows(drPlayer);
        Log.Debug("drPlayer:" + drPlayer.Count);
        // ���������
        /*DRPlayer[] drPlayer = dtScene.GetAllDataRows();
        Log.Debug("drPlayer:" + drPlayer.Length);*/

        // �����кŻ��ĳһ��
        DRPlayer drScene = dtScene.GetDataRow(2); // ��ֱ��ʹ�� dtScene[1]
        if (drScene != null)
        {
            // ���д��ڣ����Ի�ȡ������
            string name = drScene.Name;
            int atk = drScene.Atk;
            Log.Debug("name:" + name + ", atk:" + atk);
        }
        else
        {
            Log.Debug("���в�����");
        }
        // �������������������
        List<DRPlayer> drScenesWithCondition = drPlayer.Where(x => x.Id > 0).ToList();
        foreach (var Player in drScenesWithCondition)
        {
            Log.Debug($"Player ID: {Player.Id}, Name: {Player.Name}, Atk: {Player.Atk}");
        }

        //DRPlayer[] drScenesWithCondition = dtScene.GetAllDataRows(x => x.Id > 0);

        // ������������ĵ�һ��
        DRPlayer drSceneWithCondition = dtScene.GetDataRow(x => x.Name == "player1");
        Log.Debug($"������� - Name: {drSceneWithCondition.Name}, ID: {drSceneWithCondition.Id}, Atk: {drSceneWithCondition.Atk}");

    }

}
