using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MySingleton : SingletonClass<MySingleton>
{
    public void PrintWarningLog()
    {
        Debug.Log("shoot sound");
    }
}
