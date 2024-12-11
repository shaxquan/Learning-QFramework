using QFramework;
using UnityEngine;

public interface IAchievementSystem : ISystem
{
}

public class AchievementSystem : AbstractSystem, IAchievementSystem
{
    protected override void OnInit()
    {
        var model = this.GetModel<ICounterModel>();
        model.Count.Register(count =>
        {
            if (count == 10)
            {
                Debug.Log("You have unlocked an achievement!");
            }
            else if (count == 20)
            {
                Debug.Log("You have unlocked another achievement!");
            }
            else if (count == -10)
            {
                Debug.Log("You have unlocked a secret achievement!");
            }
        });
        
        // this.RegisterEvent<CountChangedEvent>(e =>
        // {
        //     if (model.Count.Value == 10)
        //     {
        //         Debug.Log("You have unlocked an achievement!");
        //     }
        //     else if (model.Count.Value == 20)
        //     {
        //         Debug.Log("You have unlocked another achievement!");
        //     }
        //     else if (model.Count.Value == -10)
        //     {
        //         Debug.Log("You have unlocked a secret achievement!");
        //     }
        // });
    }
}