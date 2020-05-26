using System.Collections.Generic;
using UnityEngine;
using ScriptUI;


public class UIPoolManager : Singleton<UIPoolManager>
{
    public UIPoolManager()
    {
        tickList = new List<UIComponent>();
        pools = new Dictionary<string, UIDialog>();
    }

    //---------Tick集合----------
    private List<UIComponent> tickList;

    public void Tick(float delta)
    {
        if (tickList.Count <= 0)
            return;

        foreach (var item in tickList)
        {
            if(item.isVisible)
                item.Tick(delta);
        }
    }

    public void AddTicker(UIComponent ui)
    {
        tickList.Add(ui);
    }

    public void RemoveTicker(UIComponent ui)
    {
        tickList.Remove(ui);
    }

    //------池子--------
    private Dictionary<string, UIDialog> pools;

    public void PushPool(UIDialog dia)
    {
        if (pools.ContainsKey(dia.Name))
        {
            return;
        }
        else
        {
            pools.Add(dia.Name, dia);
        }
    }

    public void PopPool(UIDialog dia)
    {
        if (pools.ContainsKey(dia.Name))
        {
            pools.Remove(dia.Name);
        }
        else
        {
            return;
        }
    }

    public UIDialog GetDialogInPool(string dia)
    {
        if (pools.ContainsKey(dia))
        {
            return pools[dia];
        }
        else
        {
            return null;
        }
    }

}
