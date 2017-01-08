using UnityEngine;
using System.Collections;

public class Soundtrack : MonoBehaviour {

    private static Soundtrack _instance;
    public int CurrentLevel;

    void Awake()
    {
        //if we don't have an [_instance] set yet
        if (!_instance)
        {
            _instance = this;
        }
        //otherwise, if we do, kill this thing
        else
        {
            Destroy(this.gameObject);
        }
      


        DontDestroyOnLoad(this.gameObject);
    }

    void Update()
    {
        if (Application.loadedLevel != CurrentLevel)
            Destroy(this.gameObject);
    }
}
