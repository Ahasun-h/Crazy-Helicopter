using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instante;

    public GameObject gmaePlayRelated;
    public GameStates gameStates;
    public float moveSpeed = 8f;

    public enum GameStates
    {
        none,
        mainMenu,
        countdown,
        gmaePlaying,
        paused,
        playerDied,
        gmaeOver
    }

    private void Awake()
    {
        instante = this;
    }

    public void MoveGmaePlayObjects()
    {
        if (gameStates == GameStates.gmaePlaying)
        {
           
        }
    }

    
}
