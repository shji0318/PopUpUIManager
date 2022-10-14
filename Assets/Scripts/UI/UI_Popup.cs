using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UI_Popup : UI_Base, IBeginDragHandler, IDragHandler
{
    RectTransform _thisRec;
    Canvas _thisCanvas;

    Vector2 _beginRecPos;
    Vector2 _beginMousePos;
    Vector2 _moveMousePos;

    public RectTransform ThisRec { get => _thisRec; set => _thisRec = value; }

    enum Texts
    {
       TitleText
    }
    enum Buttons
    {
       ExitButton
    }

    public override void Init()
    {
        ThisRec = GetComponent<RectTransform>();

        Bind<Text>(typeof(Texts));
        Bind<Button>(typeof(Buttons));

        
    }


    public void OnBeginDrag(PointerEventData eventData)
    {
        _beginRecPos = ThisRec.anchoredPosition;
        _beginMousePos = eventData.position;
        
    }
    public void OnDrag(PointerEventData eventData)
    {
        _moveMousePos = eventData.position - _beginMousePos  ;
        ThisRec.anchoredPosition = _beginRecPos + _moveMousePos;
    }
}
