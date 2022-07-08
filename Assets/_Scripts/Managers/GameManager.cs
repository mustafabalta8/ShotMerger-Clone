using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    public static GameStates GameState { get; private set; }

    private void Awake()
    {
        GameState = GameStates.MainMenu;
    }
    [Button]
    public void StartGame()
    {
        GameState = GameStates.InGame;
    }
    [Button]
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
public enum GameStates
{
    MainMenu,
    InGame
}
public enum Location
{
    Left,
    Right,
    Middle
}