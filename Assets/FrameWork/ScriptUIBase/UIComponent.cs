using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ScriptUI
{
    public class UIComponent : UIBase
    {
        public Transform Layer;
        //public Transform parentTransform;   //组件父物体
        //public UIComponent parent;          //逻辑父物体
        //public Transform selfTransform;     //组件自己

        public bool isVisible = false;
        public bool isGray = false;

        protected override void Init()
        {
            base.Init();
            OnPrepare();
        }

        protected virtual void BindUIComponent() { }

        protected virtual void MoveLayer() { }

        protected virtual void OnPrepare()
        {
            GenChildPathMap(transform);
            BindUIComponent();
            MoveLayer();

            TryCreate();
            TryAddListener();

            SetVisible(true);

            InitRefresh();
        }

        public virtual void Hide()
        {
            SetVisible(false);
        }

        public virtual void Show()
        {
            //parse args 

            //设置可见
            SetVisible(true);

            //手动刷新(有些面板不需要tick刷新)
            InitRefresh();
        }

        public virtual void Tick(float delta)
        {
            //if (!isLoaded)
            //    return;
        }


        //控制显隐的入口
        public virtual void SetVisible(bool show)
        {
            if (isVisible == show) return;

            isVisible = show;
            RefreshVisible();
        }

        private void RefreshVisible()
        {
            if (root == null) return;
            root.gameObject.SetActive(isVisible);

            if (isVisible)
            {
                TryOnShow();
            }
            else
            {
                TryOnHide();
            }
        }
 

        //-------子类需要复写的周期方法---------
        protected virtual void OnCreate()
        {
            Debug.Log("OnCreate");
        }

        protected virtual void AddListener()
        {
            Debug.Log("AddListener");
        }

        protected virtual void RemoveListener()
        {
            Debug.Log("RemoveListener");
        }

        protected virtual void OnShow()
        {
            Debug.Log("OnShow");
        }

        protected virtual void OnHide()
        {
            Debug.Log("OnHide");
            Hide();
        }

        protected virtual void OnRefresh()
        {
            Debug.Log("OnRefresh");
        }

        protected virtual void OnClose()
        {
            Debug.Log("OnColse");
            Hide();
            TryRemoveListener();
        }

        //------周期方法--------
        private void TryCreate()
        {
            try
            {
                OnCreate();
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        private void TryAddListener()
        {
            try
            {
                AddListener();
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        private void TryRemoveListener()
        {
            try
            {
                RemoveListener();
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        private void TryOnShow()
        {
            try
            {
                OnShow();
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        private void TryOnHide()
        {
            try
            {
                OnHide();
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        private void TryRefresh()
        {
            try
            {
                OnRefresh();
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        protected void TryOnClose()
        {
            try
            {
                OnClose();
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        private void InitRefresh()
        {
            //refresh other

            //
            TryRefresh();
        }

        //---------组件置灰---------
        protected void Gray(bool isGray)
        {
            if (this.isGray == isGray)
            {
                return;
            }
            this.isGray = isGray;

            Graphic[] graphs = GetGraphicComponents();
            Material gray;
            if (isGray)
                gray = UIManager.GetInstance.GetGrayMaterial();
            else
                gray = null;

            for (int i = 0; i < graphs.Length; i++)
            {
                graphs[i].material = gray;
            }

        }

        private Graphic[] GetGraphicComponents()
        {
            Graphic[] images;
            images = transform.GetComponentsInChildren<Graphic>();
            return images;
        }
    }
}
