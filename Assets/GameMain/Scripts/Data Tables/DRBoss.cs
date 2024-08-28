using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityGameFramework.Runtime;

public class DRBoss : DataRowBase
{
    public int m_id;
    public override int Id => m_id;

    public string Name { get; protected set; }
    public int Hp { get; protected set; }
    public int Atk { get; protected set; }
    public int Defense { get; protected set; }
    public int Crit_Rate { get; protected set; }


    public override bool ParseDataRow(string dataRowString, object userData)
    {
        string[] colString = dataRowString.Split('\t');

        int index = 1;

        m_id = int.Parse(colString[index++]);

        Name = colString[index++];

        Hp = int.Parse(colString[index++]);

        Atk = int.Parse(colString[index++]);

        Defense = int.Parse(colString[index++]);

        Crit_Rate = int.Parse(colString[index++]);

        return true;
    }
}
