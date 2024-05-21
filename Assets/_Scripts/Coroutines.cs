using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class Coroutines : MonoBehaviour
{
    private static Coroutines instance
    {
        get
        {
            if (m_instatnce == null)
            {
                var go = new GameObject("[COROUTINE]");
                m_instatnce = go.AddComponent<Coroutines>();
                DontDestroyOnLoad(go);
            }
            return m_instatnce;
        }
    }

    private static Coroutines m_instatnce;

    public static Coroutine StartRoutine(IEnumerator enumerator)
    {
        return instance.StartCoroutine(enumerator);
    }

    public static void StopRoutine(Coroutine routine)
    {
        if (routine != null)
            instance.StopCoroutine(routine);
    }


}
