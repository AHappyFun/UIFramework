using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ScriptUI
{
    public class UITestDialog: UIDialog
    {
        //------UI  Component--------
        public Text hpTxt;
        public Button button;
        public Image image;

        protected override void BindUIComponent()
        {
            base.BindUIComponent();
            Layer = UILayer.GetInstance.UITipsLayer;

            hpTxt = GetComponentByPath("hp", typeof(Text)) as Text;
            button = GetComponentByPath("btn", typeof(Button)) as Button;
            image = GetComponentByPath("Image", typeof(Image)) as Image;
        }

        public override void Tick(float delta)
        {
            base.Tick(delta);

            hpTxt.text = delta.ToString();
        }

        //--------周期-----------
        protected override void OnShow()
        {
            base.OnShow();
            //Gray(true);
            UIManager.GetInstance.SetUIImage("UISprite/sprite_001", image);
        }

        protected override void OnHide()
        {
            base.OnHide();
        }

        protected override void AddListener()
        {
            base.AddListener();
            button.onClick.AddListener(ButtonClick);
        }

        protected override void RemoveListener()
        {
            base.RemoveListener();
            button.onClick.RemoveAllListeners();
        }

        protected override void OnClose()
        {
            base.OnClose();
            hpTxt = null;
            button = null;
            image = null;
        }

        //------Cllback------
        private static void ButtonClick()
        {
            Debug.Log("OK!!!!");
        }
    }
}
