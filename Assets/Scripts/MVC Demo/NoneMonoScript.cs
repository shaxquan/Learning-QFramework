using System.Collections.Generic;
using QFramework;

public class NoneMonoScript : IUnRegisterList
{
    struct EventA
    {
    }
    
    public List<IUnRegister> UnregisterList { get; } = new List<IUnRegister>();

    void Start()
    {
        TypeEventSystem.Global.Register<EventA>(a =>
        {
 
        }).AddToUnregisterList(this);
    }

    void OnDestroy()
    {
        this.UnRegisterAll();
    } 
}
