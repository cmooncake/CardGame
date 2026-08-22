using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFlowButton : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private GameFlowState _targetState;

    public void Navigate()
    {
        if (AppRoot.Instance == null)
        {
            Debug.LogError("AppRoot is missing. Start the game from BootApp.");
            return;
        }

        AppRoot.Instance.GameFlow.ChangeState(_targetState);
    }
}
