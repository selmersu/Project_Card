using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityGameFramework.Runtime;

public class UI_Menu : UIFormLogic
{
    [SerializeField]
    private Button m_BtnStart;

    private ProcedureMenu m_ProcedureMenu;

    protected override void OnInit(object userData)
    {
        base.OnInit(userData);

        m_ProcedureMenu = (ProcedureMenu) userData;

        m_BtnStart.onClick.AddListener(OnStartClick);
    }

    private void OnStartClick()
    {
        m_ProcedureMenu.ChangeProcedure();
    }
}
