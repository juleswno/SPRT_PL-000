using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public enum GameState
{
    Title,
    Loading,
    Playing,
    Paused,
    Puzzle,
    Solved,
    Abandoned,
    Failed
  }

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public GameState CurrentState { get; private set; } = GameState.Title;
    public UnityEvent<GameState> OnGameStateChanged = new UnityEvent<GameState>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        ChangeState(GameState.Title);

    }

    public void ChangeState(GameState newState)
    {
        if (newState == CurrentState) return;

        CurrentState = newState;
        Debug.Log("$[GameManager] State changed to: {newState}");
        OnGameStateChanged.Invoke(newState);
    }

    public void LoadScene(string sceneName, GameState afterLoadState = GameState.Playing)
    {
        StartCoroutine(LoadSceneRoutine(sceneName, afterLoadState));
    }

    private System.Collections.IEnumerator LoadSceneRoutine(string sceneName, GameState nextState)
    {
        ChangeState(GameState.Loading);
        AsyncOperation op = SceneManager.LoadSceneAsync(sceneName);
        while (!op.isDone) yield return null;

        yield return new WaitForSeconds(0.3f);
        ChangeState(nextState);
    }

    public bool IsPlaying() => CurrentState == GameState.Playing;
    public bool IsPaused() => CurrentState == GameState.Paused;
}
