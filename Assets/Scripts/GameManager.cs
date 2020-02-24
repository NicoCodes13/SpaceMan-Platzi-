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
//*El manager debe saber en que estado esta el juego (usar IENUMERATE)
public class GameManager : MonoBehaviour
{
    //* Inicializacion de una variable tipo GameStats ( enumerable)
    public GameState currentGameState = GameState.menu;

    //* inicializacion del una variable para el Singleton
    public static GameManager sharedInstance;


    void Awake()
    {
        if (sharedInstance == null)
        {
            sharedInstance = this;
        }
    }


    public void StartGame()
    {

    }

    public void GameOver()
    {

    }

    public void BackToMenu()
    {

    }

    private void SetGameState(GameState newGameState)
    {
        if (newGameState == GameState.menu)
        {
            //TODO: Colocar la logica del menú
        }
        else if (newGameState == GameState.inGame)
        {

            //TODO: preparar escena para jugar
        }
        else if (newGameState == GameState.gameOver)
        {

            //TODO: preparar escena de muerte
        }

        this.currentGameState = newGameState;
    }

}
