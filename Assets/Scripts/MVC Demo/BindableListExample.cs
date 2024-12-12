using QFramework;
using UnityEngine;
using UnityEngine.UI;

public class BindableListExample : MonoBehaviour
{

    private BindableList<string> mNameList = new BindableList<string>();

    public Text NameTextTemplate;
    public Transform ContentRoot;

    private void Start()
    {
        NameTextTemplate.Hide();

        mNameList.OnCountChanged.Register(count => { print("count:" + count); })
            .UnRegisterWhenGameObjectDestroyed(gameObject);

        mNameList.OnAdd.Register((index, newName) =>
        {
            print("add:" + index + "," + newName);

            NameTextTemplate.InstantiateWithParent(ContentRoot)
                .SiblingIndex(index)
                .Show()
                .text = newName;

        }).UnRegisterWhenGameObjectDestroyed(gameObject);

        mNameList.OnMove.Register((oldIndex, newIndex, nameItem) =>
        {
            print("move:" + oldIndex + "," + newIndex + "," + nameItem);

            ContentRoot.GetChild(oldIndex).SiblingIndex(newIndex);

        }).UnRegisterWhenGameObjectDestroyed(gameObject);

        mNameList.OnRemove.Register((index, nameItem) =>
        {
            print("remove:" + index + "," + nameItem);

            ContentRoot.GetChild(index).DestroyGameObjGracefully();

        }).UnRegisterWhenGameObjectDestroyed(gameObject);

        mNameList.OnReplace.Register((index, oldName, newName) =>
        {
            print("replace:" + index + "," + oldName + "," + newName);

            ContentRoot.GetChild(index).GetComponent<Text>().text = newName;
        }).UnRegisterWhenGameObjectDestroyed(gameObject);

        mNameList.OnClear.Register(() =>
        {
            print("clear");
            ContentRoot.DestroyChildren();

        }).UnRegisterWhenGameObjectDestroyed(gameObject);
    }

    private string mNameToRemove = null;

    private void OnGUI()
    {
        IMGUIHelper.SetDesignResolution(640, 360);
        GUILayout.Label("count:" + mNameList.Count);
        GUILayout.BeginVertical("box");

        foreach (var nameItem in mNameList)
        {
            GUILayout.BeginHorizontal("box");
            GUILayout.Label(nameItem);
            if (GUILayout.Button("-"))
            {
                mNameToRemove = nameItem;
            }


            GUILayout.EndHorizontal();
        }

        if (mNameToRemove.IsNotNullAndEmpty())
        {
            mNameList.Remove(mNameToRemove);
            mNameToRemove = null;
        }

        GUILayout.EndVertical();
        if (GUILayout.Button("add"))
        {
            mNameList.Add("liangxie" + UnityEngine.Random.Range(0, 100));
        }

        if (mNameList.Count > 0)
        {
            if (GUILayout.Button("remove at 0"))
            {
                mNameList.RemoveAt(0);
            }

            if (GUILayout.Button("replace at 0"))
            {
                mNameList[0] = "replaced name" + UnityEngine.Random.Range(0, 100);
            }

            if (mNameList.Count > 1)
            {
                if (GUILayout.Button("move 0 -> 1"))
                {
                    mNameList.Move(0, 1);
                }
            }

            if (GUILayout.Button("clear"))
            {
                mNameList.Clear();
            }
        }
    }
}