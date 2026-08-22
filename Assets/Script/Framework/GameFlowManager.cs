using UnityEngine;
public class GameFlowManager
{
    public GameFlowState CurrentState { get; private set; } 
        = GameFlowState.Boot;

    private readonly SceneLoader _sceneLoader;

    public GameFlowManager(SceneLoader sceneLoader)
    {
        _sceneLoader = sceneLoader;
    }

    public void ChangeState(GameFlowState newState)
    {
        if (CurrentState == newState)
        {
            return;
        }

        string sceneName = GetSceneName(newState);
        if (string.IsNullOrEmpty(sceneName))
        {
            Debug.LogError($"No scene configured for state: {newState}");
            return;
        }

        CurrentState = newState;
        _sceneLoader.LoadScene(sceneName);
    }

    private string GetSceneName(GameFlowState state)
    {
        switch (state)
        {
            case GameFlowState.Boot:
                return "BootApp";

            case GameFlowState.DeckEditor:
                return "BuildDeck";

            default:
                return null;
        }
    }
}
