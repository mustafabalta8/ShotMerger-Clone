using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class GameManager : MonoBehaviour
{
    public static GameStates GameState { get; private set; }

    private void Awake()
    {
        GameState = GameStates.InGame;
    }
    [Button]
    public void StopGame()
    {
        GameState = GameStates.MainMenu;
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