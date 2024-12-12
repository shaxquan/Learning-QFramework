using System.Linq;
using QFramework;
using UnityEngine;

public class BindableDictionaryExample : MonoBehaviour
{
    private BindableDictionary<string, string> mDictionary = new BindableDictionary<string, string>();

    private void Start()
    {
        mDictionary.OnCountChanged.Register(count => { print("count:" + count); })
            .UnRegisterWhenGameObjectDestroyed(gameObject);

        mDictionary.OnAdd.Register((key, value) => { print("add:" + key + "," + value); })
            .UnRegisterWhenGameObjectDestroyed(gameObject);

        mDictionary.OnRemove.Register((key, value) => { print("remove:" + key + "," + value); })
            .UnRegisterWhenGameObjectDestroyed(gameObject);

        mDictionary.OnReplace.Register((key, oldValue, newValue) =>
        {
            print("replace:" + key + "," + oldValue + "," + newValue);
        }).UnRegisterWhenGameObjectDestroyed(gameObject);

        mDictionary.OnClear.Register(() => { print("clear"); }).UnRegisterWhenGameObjectDestroyed(gameObject);
    }

    private string mKeyToDelete = null;

    private void OnGUI()
    {
        IMGUIHelper.SetDesignResolution(640, 360);

        GUILayout.Label("Count:" + mDictionary.Count);
        GUILayout.BeginVertical("box");

        foreach (var kv in mDictionary)
        {
            GUILayout.BeginHorizontal("box");
            GUILayout.Label($"{kv.Key},{kv.Value}");
            if (GUILayout.Button("-"))
            {
                mKeyToDelete = kv.Key;
            }

            GUILayout.EndHorizontal();
        }

        if (GUILayout.Button("add"))
        {
            var key = "key" + Random.Range(0, 100);
            if (!mDictionary.ContainsKey(key))
            {
                mDictionary.Add("key" + Random.Range(0, 100), "value" + Random.Range(0, 100));
            }
        }

        if (mDictionary.Count > 0)
        {
            if (GUILayout.Button("remove"))
            {
                mDictionary.Remove(mDictionary.Keys.First());
            }

            if (GUILayout.Button("replace"))
            {
                mDictionary[mDictionary.Keys.First()] = "replaced value" + Random.Range(0, 100);
            }

            if (GUILayout.Button("clear"))
            {
                mDictionary.Clear();
            }
        }

        GUILayout.EndVertical();


        if (mKeyToDelete.IsNotNullAndEmpty())
        {
            mDictionary.Remove(mKeyToDelete);
            mKeyToDelete = null;
        }
    }
}