using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UI_Base : MonoBehaviour
{

    public abstract void Init();

    public void Start()
    {
        Init();
    }

    public static Dictionary<Type, UnityEngine.Object[]> dic = new Dictionary<Type, UnityEngine.Object[]>();

    public void Bind<T>(Type tpye) where T : UnityEngine.Object
    {
        string[] names = Enum.GetNames(tpye);

        UnityEngine.Object[] obj = new UnityEngine.Object[names.Length];

        for(int i = 0; i<names.Length; i++)
        {
            obj[i] = Util.FindChild<T>(gameObject, names[i]);
        }
    }

    public T Get<T>(int idx) where T : UnityEngine.Object
    {
        UnityEngine.Object[] obj;
        if (dic.TryGetValue(typeof(T), out obj) == false)
            return null;

        return obj[idx] as T;
    }
}
