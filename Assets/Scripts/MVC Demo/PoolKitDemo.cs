using System;
using QFramework;
using UnityEngine;

public class PoolKitDemo : MonoBehaviour
{
    class Fish
    {
    }

    class Bullet : IPoolable, IPoolType
    {
        public void OnRecycled()
        {
            Debug.Log("OnRecycled");
        }

        public bool IsRecycled { get; set; }
        
        public static Bullet Allocate()
        {
            return SafeObjectPool<Bullet>.Instance.Allocate();
        }
        
        public void Recycle2Cache()
        {
            SafeObjectPool<Bullet>.Instance.Recycle(this);
        }
    }

private void Start()
    {
        //SimpleObjectPool
        var pool = new SimpleObjectPool<Fish>(()=>new Fish(), null, 10);
        Debug.Log(pool.CurCount);       //50
        var fish = pool.Allocate();
        Debug.Log(pool.CurCount);       //49
        pool.Recycle(fish);
        Debug.Log(pool.CurCount);       //50

        var gameObjPool = new SimpleObjectPool<GameObject>(() =>
        {
            var gameObj = new GameObject("AGameObject");
            // init gameObj code 

            // gameObjPrefab = Resources.Load<GameObject>(""somePath/someGameObj"");
 
            return gameObj;
        }, (gameObj) =>
        {
            // reset code here
        });
        
        //SafeObjectPool
        SafeObjectPool<Bullet>.Instance.Init(50, 25);
        var bullet = Bullet.Allocate();
        Debug.Log(SafeObjectPool<Bullet>.Instance.CurCount);
        bullet.Recycle2Cache();
        Debug.Log(SafeObjectPool<Bullet>.Instance.CurCount);
        
        // can config object factory
        // 可以配置对象工厂
        SafeObjectPool<Bullet>.Instance.SetFactoryMethod(() =>
        {
            // bullet can be mono behaviour
            return new Bullet();
        });
 
        SafeObjectPool<Bullet>.Instance.SetObjectFactory(new DefaultObjectFactory<Bullet>());


        var names = ListPool<string>.Get();
        names.Add("Hello");

        names.Release2Pool();
        // or ListPool<string>.Release(names);


        var infos = DictionaryPool<string, string>.Get();
        infos.Add("name","Hello");

        infos.Release2Pool();
        // or DictionaryPool<string,string>.Release(names);
    }
}
