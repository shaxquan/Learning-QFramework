using System;
using QFramework;
using UnityEngine;

public class TypeEventSystemExample : MonoBehaviour
{
    interface IEvent
    {
        
    }
    struct EventA : IEvent
    {
        public int Count;
    }

    private void Start()
    {
        TypeEventSystem.Global.Register<IEvent>(e =>
        {
            if (e is EventA)
            {
                Debug.Log("event received!!");
            }
        }).UnRegisterWhenGameObjectDestroyed(gameObject);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            TypeEventSystem.Global.Send<IEvent>(new EventA()
            {
                Count = 10
            });
        }
    }
}
