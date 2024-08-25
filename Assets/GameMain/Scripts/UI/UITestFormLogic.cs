using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityGameFramework.Runtime;

public class UITestFormLogic : UIFormLogic
{
    [SerializeField]
    private Button m_BtnChange;

    private ProcedureLaunch m_ProcedureLaunch;

    protected override void OnInit(object userData)
    {
        base.OnInit(userData);

        m_ProcedureLaunch = (ProcedureLaunch) userData;

        m_BtnChange.onClick.AddListener(OnChangeClick);

    }

    private void OnChangeClick()
    {
        m_ProcedureLaunch.ChangeProcedure();
    }
}
