using QFramework;
using UnityEngine;
using UnityEngine.UI;

public class CounterAppController : MonoBehaviour, IController
{
    private ICounterModel _model;
    private Button BtnAdd;
    private Button BtnSub;

    private void Start()
    {
        _model = this.GetModel<ICounterModel>();
        Debug.Log(_model.Count);
        
        BtnAdd.onClick.AddListener(() =>
        {
            this.SendCommand<IncreaseCountCommand>();
        });
        
        BtnSub.onClick.AddListener(() =>
        {
            this.SendCommand<DecreaseCountCommand>();
        });

        _model.Count.RegisterWithInitValue(count =>
        {
            UpdateView();
        }).UnRegisterWhenGameObjectDestroyed(gameObject);

        // this.RegisterEvent<CountChangedEvent>(e =>
        // {
        //     UpdateView();
        // }).UnRegisterWhenGameObjectDestroyed(gameObject);
    }

    private void UpdateView()
    {
        Debug.Log(_model.Count);
    }

    public IArchitecture GetArchitecture()
    {
        return CounterApp.Interface;
    }
}