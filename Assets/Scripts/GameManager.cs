using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//*Creacion de enumerado
public enum GameState
{
    menu,
    inGame,
    gameOver
}
//El manager debe saber en que estado esta el juego (usar IENUMERATE)
public class GameManager : MonoBehaviour
{
    // Inicializacion de una variable tipo GameStats ( enumerable)
    public GameState currentGameState = GameState.menu;

    // inicializacion del una variable para el Singleton
    public static GameManager sharedInstance;
    // private PlayerController controller;


    void Awake()
    {
        if (sharedInstance == null)
        {
            sharedInstance = this;
        }
        Time.timeScale = 0f;
    }

    private void Start()
    {
        // controller = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Submit") && currentGameState != GameState.inGame)
        {
            StartGame();
        }
        if (Input.GetButtonDown("Cancel"))
        {
            BackToMenu();
        }
    }


    public void StartGame()
    {
        SetGameState(GameState.inGame);
    }

    public void GameOver()
    {
        SetGameState(GameState.gameOver);
    }

    public void BackToMenu()
    {
        SetGameState(GameState.menu);
    }

    private void SetGameState(GameState newGameState)
    {
        if (newGameState == GameState.menu)
        {
            //TODO: Colocar la logica del menú
            Time.timeScale = 0f;
        }
        else if (newGameState == GameState.inGame)
        {

            //TODO: preparar escena para jugar
            Time.timeScale = 1f;
            // llamada haciendo uso del singleton
            PlayerController.sharedInstance.StartGame();
            //Llamado con el gameobjet
            // controller.StartGame();
        }
        else if (newGameState == GameState.gameOver)
        {

            //TODO: preparar escena de muerte
        }

        this.currentGameState = newGameState;
    }

}
