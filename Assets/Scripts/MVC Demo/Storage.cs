﻿using QFramework;
using UnityEngine;

public interface IStorage : IUtility
{
    void SaveInt(string key, int value);
    int LoadInt(string key, int defaultValue);
}

public class Storage  : IStorage
{
    public void SaveInt(string key, int value)
    {
        PlayerPrefs.SetInt(key, value);
    }
    
    public int LoadInt(string key, int defaultValue)
    {
        return PlayerPrefs.GetInt(key, defaultValue);
    }
}