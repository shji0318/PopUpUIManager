using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

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

        UI_Popup pUI = Link.First();        
        Link.RemoveFirst();
        Destroy(pUI);
        PopupOrder--;
        Count--;
    }

    public void PopUI(string name)
    {
        UI_Popup go = Util.Instantiate(name).GetAndAddComponent<UI_Popup>();

        go.ThisRec.anchoredPosition = new Vector3(PopupOrder, 0, 0);        
        go.transform.parent = _pRoot;

        Link.AddFirst(go); // 

        Canvas canvas = go.gameObject.GetAndAddComponent<Canvas>();
        canvas.overrideSorting = true;
        canvas.sortingOrder = PopupOrder;
        PopupOrder++;
    }
    
    
    
}
