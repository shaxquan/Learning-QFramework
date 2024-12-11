using System;
using QFramework;
using UnityEngine;

public class EasyEventExample : MonoBehaviour
{
    public EasyEvent EventA = new EasyEvent();
    public EasyEvent<int> EventB = new EasyEvent<int>();

    public class EventC : EasyEvent<int, int> { }
    private EventC _eventC = new EventC();

    private void Start()
    {
        EventA.Register(() =>
        {
            Debug.Log("EasyEvent Triggered");
        }).UnRegisterWhenGameObjectDestroyed(gameObject);
        
        EventB.Register(count =>
        {
            Debug.Log("EasyEvent<int> Triggered:" + count);
        }).UnRegisterWhenGameObjectDestroyed(gameObject);

        EasyEvents.Register<EasyEvent<int, string, int>>();
        EasyEvents.Get<EasyEvent<int, string, int>>().Register((count, nm, count2) =>
        {
            Debug.Log("EasyEvent<int, string, int> Triggered:" + count + " " + nm + " " + count2);
        }).UnRegisterWhenGameObjectDestroyed(gameObject);

        _eventC.Register((a, b) =>
        {
            Debug.Log("EasyEvent<int, int> Triggered:" + a + " " + b);
        }).UnRegisterWhenGameObjectDestroyed(gameObject);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            EventA.Trigger();
            EventB.Trigger(10);
            EasyEvents.Get<EasyEvent<int, string, int>>().Trigger(10, "Hello", 20);
        }
    }
}