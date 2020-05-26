using System.Collections.Generic;
using UnityEngine;
using System;


public class GameManager : SingletonBase<GameManager>
{

    private void Start()
    {
        Init();

        ScriptUI.UIManager.GetInstance.Open("MainSceneDialog");
    }

    void Init()
    {
        ScriptUI.UIManager.GetInstance.Init();
    }


    private void Update()
    {
        float delta = Time.deltaTime;

        ScriptUI.UIManager.GetInstance.Tick(delta);
    }
}
