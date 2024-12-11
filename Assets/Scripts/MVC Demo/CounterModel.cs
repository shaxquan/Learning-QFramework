using QFramework;

public interface ICounterModel : IModel
{
    BindableProperty<int> Count { get; }
}

public class CounterModel : AbstractModel, ICounterModel
{
    public BindableProperty<int> Count { get; } = new BindableProperty<int>();
    
    // private int _count;
    // private Storage _storage;

    // public int Count
    // {
    //     get => _count;
    //     set
    //     {
    //         if (_count != value)
    //         {
    //             _count = value;
    //             _storage.SaveInt(nameof(Count), value);
    //         }
    //     }
    // }
    
    protected override void OnInit()
    {
        var storage = this.GetUtility<IStorage>();
        // _count = _storage.LoadInt(nameof(Count), 0);
        Count.Value  = storage.LoadInt(nameof(Count), 0);

        Count.Register(count =>
        {
            storage.SaveInt(nameof(Count), count);
        });
    }
}