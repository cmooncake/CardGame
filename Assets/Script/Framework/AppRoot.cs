using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(SceneLoader))]
public class AppRoot : MonoBehaviour
{
    public static AppRoot Instance { get; private set; }
    public SceneLoader SceneLoader { get; private set; }
    public GameFlowManager GameFlow { get; private set; }
    // Start is called before the first frame update
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        SceneLoader = GetComponent<SceneLoader>();
        GameFlow = new GameFlowManager(SceneLoader);
        DontDestroyOnLoad(gameObject);
    }
}
