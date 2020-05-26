using UnityEngine;
using System.Collections;

public class Singleton<T> where T : new()
{
    protected static T m_instance;

    public static T GetInstance
    {
        get {
            if (m_instance == null)
            {
                m_instance = new T();
            }
            return m_instance;
           //i am branch
        }
    }

}
