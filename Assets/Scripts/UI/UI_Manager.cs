using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    private static UI_Manager instance;

    int _count = 0;
    int _popupOrder = 10;
    
    Transform _pRoot;
    Transform _sRoot;

    LinkedList<UI_Popup> _lLink = new LinkedList<UI_Popup>();
    public int Count { get => _count; set => _count = value; }
    public int PopupOrder { get => _popupOrder; set => _popupOrder = value; }
    public static UI_Manager UI { get => instance; set => instance = value; }
    public LinkedList<UI_Popup> Link { get => _lLink; set => _lLink = value; }
    
    public void Awake()
    {
        if(UI==null)
        {
            UI = this;
        }
        else
        {
            Destroy(this);
        }

        _pRoot = Util.FindOrNew("PopupRoot").transform;       
    }

    public void CancleUI()
    {
        if (!(Link.Count > 0))
            return;

        UI_Popup up = Link.First();        
        Link.RemoveFirst();
        Destroy(up.gameObject);
        PopupOrder--;
        Count--;
        if (Count == 0)
            PopupOrder = 10;
    }

    public bool CancleUIOnKey(UI_Popup up)
    {
        if (up == null)
            return false;

        Link.Remove(up);
        Destroy(up.gameObject);
        Count--;
        if (Count == 0)
            PopupOrder = 10;
        return true;
    }
    
    public UI_Popup PopUI(string name)
    {
        UI_Popup go = Util.Instantiate(name).GetAndAddComponent<UI_Popup>();

        go.clickAction -= ClickFocus;
        go.clickAction += ClickFocus;

        go.transform.SetParent(_pRoot);
        go.ThisRec.anchoredPosition = new Vector3((Count * 10f)-10, 0, 0);

        Link.AddFirst(go);

        Canvas canvas = go.gameObject.GetAndAddComponent<Canvas>();
        canvas.overrideSorting = true;
        canvas.sortingOrder = PopupOrder;        
        PopupOrder++;
        Count++;
        return go;
    }

    public void ClickFocus(UI_Popup up)
    {        
        if (Count <= 1)
            return; 

        if (up == Link.First())
            return;

        Link.Remove(up);
        Link.AddFirst(up);
        up.ThisCanvas.sortingOrder = _popupOrder++;        
    }
}
