using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputObject : MonoBehaviour
{
    UI_Popup inven;
    UI_Popup stat;
    UI_Popup item;
    void Update()
    {
        OnKey();
    }

    public void OnKey()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            if (UI_Manager.UI.CancleUIOnKey(inven))
                return;

            inven = UI_Manager.UI.PopUI("Inven");            
        }
        else if(Input.GetKeyDown(KeyCode.S))
        {
            if (UI_Manager.UI.CancleUIOnKey(stat))
                return;

            stat = UI_Manager.UI.PopUI("Stat");
        }
        else if(Input.GetKeyDown(KeyCode.E))
        {
            if (UI_Manager.UI.CancleUIOnKey(item))
                return;

            item = UI_Manager.UI.PopUI("Item");
        }
        else if(Input.GetKeyDown(KeyCode.Escape))
        {
            UI_Manager.UI.CancleUI();
        }
    }    
}
