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

        Log.Debug("初始场景");
        

        //数据表读取
        EventComponent Event = UnityGameFramework.Runtime.GameEntry.GetComponent<EventComponent>(); //获取框架事件组件
        
        Event.Subscribe(LoadDataTableSuccessEventArgs.EventId, OnLoadDataTableSuccess); 

        DataTableBase dataTableBase = (DataTableBase)GameEntry.DataTable.CreateDataTable<DRPlayer>();

        dataTableBase.ReadData("Assets/GameMain/DataTables/Player_Data.txt", this);
        

        //获取框架场景组件
        SceneComponent scene = UnityGameFramework.Runtime.GameEntry.GetComponent<SceneComponent>();

        scene.LoadScene("Assets/GameMain/Scenes/Menu.unity", this); //切换Menu场景

        ChangeState<ProcedureMenu>(procedureOwner); //切换Menu流程
    }

    /*protected override void OnLeave(ProcedureOwner procedureOwner, bool isShutdown)
    {
        GameEntry.Event.Unsubscribe(LoadDataTableSuccessEventArgs.EventId, OnLoadDataTableSuccess);

        base.OnLeave(procedureOwner, isShutdown);
    }*/

    private void OnLoadDataTableSuccess(object sender, GameEventArgs e)
    {
        //尝试读取加载完成的文件数据
        DataTableComponent DataTable = UnityGameFramework.Runtime.GameEntry.GetComponent<DataTableComponent>();  // 获取框架数据表组件
        // 获得数据表
        IDataTable<DRPlayer> dtScene = DataTable.GetDataTable<DRPlayer>();

        // 获得所有行,并且创建一个 List 来存储所有行
        List<DRPlayer> drPlayer = new List<DRPlayer>();
        dtScene.GetAllDataRows(drPlayer);
        Log.Debug("drPlayer:" + drPlayer.Count);
        // 获得所有行
        /*DRPlayer[] drPlayer = dtScene.GetAllDataRows();
        Log.Debug("drPlayer:" + drPlayer.Length);*/

        // 根据行号获得某一行
        DRPlayer drScene = dtScene.GetDataRow(2); // 或直接使用 dtScene[1]
        if (drScene != null)
        {
            // 此行存在，可以获取内容了
            string name = drScene.Name;
            int atk = drScene.Atk;
            Log.Debug("name:" + name + ", atk:" + atk);
        }
        else
        {
            Log.Debug("此行不存在");
        }
        // 获得满足条件的所有行
        List<DRPlayer> drScenesWithCondition = drPlayer.Where(x => x.Id > 0).ToList();
        foreach (var Player in drScenesWithCondition)
        {
            Log.Debug($"Player ID: {Player.Id}, Name: {Player.Name}, Atk: {Player.Atk}");
        }

        //DRPlayer[] drScenesWithCondition = dtScene.GetAllDataRows(x => x.Id > 0);

        // 获得满足条件的第一行
        DRPlayer drSceneWithCondition = dtScene.GetDataRow(x => x.Name == "player1");
        Log.Debug($"搜索结果 - Name: {drSceneWithCondition.Name}, ID: {drSceneWithCondition.Id}, Atk: {drSceneWithCondition.Atk}");

    }

}
