using System;
using QFramework;
using UnityEditor;
using UnityEngine;

public class EditorCounterApp : EditorWindow, IController
{
    [MenuItem("CounterApp/Window")]
    public static void Open()
    {
        var window = GetWindow<EditorCounterApp>();
        window.Show();
    }

    private ICounterModel _model;
    private void OnEnable()
    {
        _model = this.GetModel<ICounterModel>();
    }

    private void OnDisable()
    {
        _model = null;
    }

    private void OnGUI()
    {
        if (GUILayout.Button("+"))
        {
            this.SendCommand<IncreaseCountCommand>();
        }
        GUILayout.Label(_model.Count.Value.ToString());
        if (GUILayout.Button("-"))
        {
            this.SendCommand<DecreaseCountCommand>();
        }
    }
    
    public IArchitecture GetArchitecture()
    {
        return CounterApp.Interface;
    }
}