using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : IntEventInvoker
{
    #region  Initialization
    static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if(_instance == null)
            {
                Debug.LogError("GameManager is NULL");
            }

            return _instance;
        }
    }

    private void Awake()
    {
        //initalize managers
        _instance = this;
        EventManager.Initialize();
    }
    #endregion


    public GameObject Table;
    public List<GameObject> ballsOnTheDesk;
    enum players 
    {
        playerOne,
        playerTwo
    }
    int playerActive;
        


    void OnEnable()
    {
        //add gameStart Event
        dictOfInvokers.Add(EventsNames.gameStartedEvent, new GameStartedEvent());
        EventManager.AddInvoker(EventsNames.gameStartedEvent, this);

        //add gameOverEvent
        dictOfInvokers.Add(EventsNames.gameWinEvent, new GameWinEvent());
        EventManager.AddInvoker(EventsNames.gameWinEvent, this);

        //add nextTurn Event
        dictOfInvokers.Add(EventsNames.nextTurnEvent, new NextTurnEvent());
        EventManager.AddInvoker(EventsNames.nextTurnEvent, this);
        EventManager.AddListener(EventsNames.nextTurnEvent, SwitchPlayerActive);

        dictOfInvokers.Add(EventsNames.turnEndEvent, new TurnEndEvent());
        EventManager.AddInvoker(EventsNames.turnEndEvent, this);

        EventManager.AddListener(EventsNames.wrongBallTouchEvent, RulesBreakHandler);
    }

    void Start()
    {
        dictOfInvokers[EventsNames.gameStartedEvent].Invoke(1);
    }

    private void Update()
    {

    }

    void SwitchPlayerActive(int num)
    {
        switch (num)
        {
            case 1:
                playerActive = (int)players.playerOne;
                break;

            case 2:
                playerActive = (int)players.playerTwo;
                break;
        }
    }

    void RulesBreakHandler(int num)
    {
        //1 - Wrong Ball hit
        //2 - Black Ball hit
        //3 - Wrong Ball in the loose
        //4 - White Ball int the loose
        //5 - Black Ball int he loose
        if(num == 1)
        {

        }
        else if(num == 2)
        {

        }
        else if(num == 3)
        {

        }
        else if(num == 4)
        {
            
        }
        else
        {
            dictOfInvokers[EventsNames.gameWinEvent].Invoke(playerActive);
        }
    }
}
