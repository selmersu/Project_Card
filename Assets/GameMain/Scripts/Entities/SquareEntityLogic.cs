using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityGameFramework.Runtime;

public class SquareEntityLogic : EntityLogic
{
    private Vector3 m_Rot = new Vector3(0,5,0);

    protected override void OnUpdate(float elapseSeconds, float realElapseSeconds)
    {
        base.OnUpdate(elapseSeconds, realElapseSeconds);

        transform.Rotate(m_Rot);
    }
    
}
