using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterSingleton : MonoBehaviour
{
    public static MasterSingleton main { get; private set; }
    public InputManager InputManager { get; private set; }
    public ObjectPooler ObjectPooler { get; private set; }

    [SerializeField] private InputManager inputManager;
    [SerializeField] private ObjectPooler objectPooler;

    private void Awake()
    {
        if (main != null)
        {
            Destroy(gameObject);
        }
        else
        {
            main = this;
        }

    }
}
