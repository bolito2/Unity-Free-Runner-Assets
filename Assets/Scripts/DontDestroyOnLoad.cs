using UnityEngine;
using System.Collections;

public class DontDestroyOnLoad : MonoBehaviour {

    public static DontDestroyOnLoad instance;

	void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if(instance != this)
        {
            Destroy(gameObject);
        }
    }
}
