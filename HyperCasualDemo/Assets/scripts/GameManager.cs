using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
    {
        Start,
        Pause,
        End
    }

public class GameManager : MonoBehaviour//
{
    
    private LevelManager _levelManager;
    private UIManager _uiManager;
    public GameState currentGameState;
    public player _player;
    private int score;

    
    void Start()
    {
        _levelManager = GetComponent<LevelManager>();  //obje oluşturulduktan sonra inspector ekranından bulunmalıdır ..!
        _uiManager = GameObject.FindWithTag("MainUI").GetComponent<UIManager>();
        currentGameState = GameState.Pause;  
        _player =  GameObject.FindWithTag("Player").GetComponent<player>();
    }

    public void startGame()
    {
        currentGameState = GameState.Start;
        _levelManager.startLevel();
    }

    public void startNextGame()
    {
        currentGameState = GameState.Start;
        _levelManager.startNextLevel();   
    }

    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.S))
        {
            startGame();
        }

        if(Input.GetKeyDown(KeyCode.N))
        {
            startNextGame();
        }

        _uiManager.showPoint(_player.coffeeCount*10);  
    }

    public void EndGame()
    {
        _levelManager.endLevel();
        currentGameState = GameState.End;
        _uiManager.EndLevel();
        //Debug.Log("Level tamam");
    }
}
