﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Linq;

public class UI_Popup : UI_Base, IPointerDownHandler,IBeginDragHandler, IDragHandler,IEndDragHandler
{
    RectTransform _thisRec;
    Canvas _thisCanvas;

    Vector2 _beginRecPos;
    Vector2 _beginMousePos;
    Vector2 _moveMousePos;

    public RectTransform ThisRec { get => _thisRec; set => _thisRec = value; }
    public Canvas ThisCanvas { get => _thisCanvas; set => _thisCanvas = value; }

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
        ThisCanvas = Util.GetAndAddComponent<Canvas>(gameObject);

        ThisCanvas.overrideSorting= true;
        
        Bind<Text>(typeof(Texts));
        Bind<Button>(typeof(Buttons));

        
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        if (UI_Manager.UI.Count < 1)
            return;

        if (UI_Manager.UI.Link.First() == this)
            return;

        
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("BeginDrag");
        _beginRecPos = ThisRec.anchoredPosition;
        _beginMousePos = eventData.position;
        
    }
    public void OnDrag(PointerEventData eventData)
    {
        _moveMousePos = eventData.position - _beginMousePos  ;
        ThisRec.anchoredPosition = _beginRecPos + _moveMousePos;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("EndDrag");
    }
}
