using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Linq;
using System;

public class UI_Popup : UI_Base, IPointerDownHandler, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    RectTransform _thisRec;
    Canvas _thisCanvas;

    public Action<UI_Popup> clickAction;

    Vector2 _beginRecPos;
    Vector2 _beginMousePos;
    Vector2 _moveMousePos;

    public RectTransform ThisRec { get => _thisRec; set => _thisRec = value; }
    public Canvas ThisCanvas { get => _thisCanvas; set => _thisCanvas = value; }
    
    public enum Texts
    {
       TitleText,
       ContentsText
    }
    public enum Buttons
    {
       ExitButton
    }
   
    public override void Init()    {
        
        Bind<Text>(typeof(Texts));
        Bind<Button>(typeof(Buttons));

        Util.GetAndAddComponent<GraphicRaycaster>(gameObject);
        
    }

    public void Awake()
    {
        ThisRec = Util.GetAndAddComponent<RectTransform>(gameObject);
        ThisCanvas = Util.GetAndAddComponent<Canvas>(gameObject);
        
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        clickAction(this);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("BeginDrag");
        _beginRecPos = ThisRec.anchoredPosition;
        _beginMousePos = eventData.position;

    }
    public void OnDrag(PointerEventData eventData)
    {
        _moveMousePos = eventData.position - _beginMousePos;
        ThisRec.anchoredPosition = _beginRecPos + _moveMousePos;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("EndDrag");
    }

    

}
