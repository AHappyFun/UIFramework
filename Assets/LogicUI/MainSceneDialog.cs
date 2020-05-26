using System;
using System.Collections.Generic;
using UnityEngine;
using ScriptUI;
using UnityEngine.UI;

public class MainSceneDialog: UIDialog
{
    //------UI Component--------
    public Button[] buttons = new Button[3];

    protected override void BindUIComponent()
    {
        base.BindUIComponent();
        Layer = UILayer.GetInstance.UIPanelLayer;

        for (int i = 0; i < 3; i++)
        {
            buttons[i] = GetComponentByPath("Var/g_btn/btn"+i, typeof(Button)) as Button;
        }
    }

    //--------周期-----------

    protected override void AddListener()
    {
        base.AddListener();
        buttons[0].onClick.AddListener(BangPaiClick);
    }

    protected override void OnClose()
    {
        base.OnClose();
        OnHide();
    }

    //------Callback------
    private void BangPaiClick()
    {
        UIManager.GetInstance.Open("UITestDialog");
    }
}

