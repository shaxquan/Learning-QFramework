using QFramework;
using UnityEngine;

public class CounterApp : Architecture<CounterApp>
{
    protected override void Init()
    {
        this.RegisterSystem<IAchievementSystem>(new AchievementSystem());
        this.RegisterUtility<IStorage>(new Storage());
        this.RegisterModel<ICounterModel>(new CounterModel());
    }

    protected override void ExecuteCommand(ICommand command)
    {
        Debug.Log("Before Command Execute: " + command.GetType().Name);
        base.ExecuteCommand(command);
        Debug.Log("After Command Execute: " + command.GetType().Name);
    }
}