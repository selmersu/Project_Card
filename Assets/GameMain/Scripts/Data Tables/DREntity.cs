using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityGameFramework.Runtime;

public class DREntity : DataRowBase
{
    public int m_id;

    public override int Id => m_id;

    public string Name
    {
        get;
        private set;
    }

    public string Attack
    {
        get;
        private set;
    }

    public string Hp
    {
        get;
        private set;
    }

    public override bool ParseDataRow(string dataRowString, object userData)
    {
        string [] colString = dataRowString.Split('\t');

        int index = 1;

        m_id = int.Parse(colString[index++]);

        Name = colString[index++];

        Attack = colString[index++];

        Hp = colString[index++];

        return true;


    }

}
