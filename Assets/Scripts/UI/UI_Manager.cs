using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class UI_Manager : MonoBehaviour
{
    private static UI_Manager instance;    

    int _popupOrder = 10;
    
    Transform _pRoot;
    Transform _sRoot;


    public static UI_Manager UI { get => instance; set => instance = value; }
    Stack<UI_Popup> _popupStack = new Stack<UI_Popup>();

    

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
        if (!(_popupStack.Count >= 0))
            return;

        UI_Popup pUI = _popupStack.Pop();

        Destroy(pUI);
        _popupOrder--;
    }

    public void PopUI(string name)
    {
        UI_Popup go = Util.Instantiate(name).GetAndAddComponent<UI_Popup>();

        go.ThisRec.anchoredPosition = new Vector3(_popupOrder - 10, 0, 0);        
        go.transform.parent = _pRoot;

        _popupStack.Push(go);

        Canvas canvas = go.gameObject.GetAndAddComponent<Canvas>();
        canvas.overrideSorting = true;
        canvas.sortingOrder = _popupOrder;
        _popupOrder++;
    }
    
}
