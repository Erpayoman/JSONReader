using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class TeamMembers 
{
    public string Title;
    public List<string> ColumnHeaders;
    public List<DataType> Data;



    [Serializable]
    public class DataType
    {
        public string ID;
        public string Name;
        public string Role;
        public string Nickname;
    }
}

