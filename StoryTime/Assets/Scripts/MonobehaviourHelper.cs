using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Some Unity APIs can only be called by a Monobehaviour, so this is a globally-acessible Monobehaviour instance that non-Monobehaviour classes can use to call those APIs for them
public class MonobehaviourHelper : MonoBehaviour
{
    private static MonobehaviourHelper s_instance;
    public static MonobehaviourHelper Instance
    {
        get
        {
            if (s_instance == null)
                s_instance = GameObject.FindObjectOfType<MonobehaviourHelper>();
            return s_instance;
        }
    }

    private void Awake()
    {
        s_instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public GameObject InstantiatePrefab(GameObject prefab, Vector3 position, Quaternion rotation)
    {
        return Instantiate(prefab, position, rotation);
    }
}
