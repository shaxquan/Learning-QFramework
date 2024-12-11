using QFramework;

public class CounterApp : Architecture<CounterApp>
{
    protected override void Init()
    {
        this.RegisterSystem<IAchievementSystem>(new AchievementSystem());
        this.RegisterUtility<IStorage>(new Storage());
        this.RegisterModel<ICounterModel>(new CounterModel());
    }
}