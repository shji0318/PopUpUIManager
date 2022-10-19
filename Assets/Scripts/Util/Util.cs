using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Util 
{

    public static T Load<T>(string name) where T : UnityEngine.Object
    {
        T go = Resources.Load<T>($"Prefabs/{name}");
        
        if (go == null)
            return null;

        return go;
    }

    public static GameObject Instantiate (string name, Transform parent = null) 
    {
        GameObject original = Load<GameObject>(name);

        if (original == null)
            return null;

        GameObject go = Object.Instantiate(original,parent);
        go.name = original.name;

        return go;
        
    }

    public static T GetAndAddComponent<T> (this GameObject go) where T : Component
    {
        T component = go.GetComponent<T>();
        if(component == null)
        {
            component = go.AddComponent<T>();
        }

        return component;
    }

    public static T FindChild<T>(GameObject parentGo, string name) where T : UnityEngine.Object
    {
        if (parentGo == null)
            return null;

        foreach(T component in parentGo.GetComponentsInChildren<T>())
        {
            if (component.name == name || string.IsNullOrEmpty(name))
                return component;
        }

        return null;
    }

    public static GameObject FindOrNew(string name,Transform parent = null) 
    {
        GameObject go = GameObject.Find(name);

        if (go == null)
            go = new GameObject { name = name};

        if (parent != null)
            go.transform.parent = parent;
        return go;
    }
}
