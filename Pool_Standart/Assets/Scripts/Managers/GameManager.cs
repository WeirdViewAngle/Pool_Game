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


    public int filledBallsCount, striptedBallsCount;
    public GameObject floor, Table;

    public List<GameObject> ballsOnTheDesk;


    void OnEnable()
    {
        //add gameStart Event
        dictOfInvokers.Add(EventsNames.gameStartedEvent, new GameStartedEvent());
        EventManager.AddInvoker(EventsNames.gameStartedEvent, this);

        //add gameOverEvent
        dictOfInvokers.Add(EventsNames.gameWinEvent, new GameWinEvent());
        EventManager.AddInvoker(EventsNames.gameWinEvent, this);

        //add removeBall invoker
        dictOfInvokers.Add(EventsNames.removeBallEvent, new RemoveBallEvent());
        EventManager.AddInvoker(EventsNames.removeBallEvent, this);

        //endTurn Event add
        dictOfInvokers.Add(EventsNames.turnEndEvent, new TurnEndEvent());
        EventManager.AddInvoker(EventsNames.turnEndEvent, this);
    }

    void Start()
    {
        dictOfInvokers[EventsNames.gameStartedEvent].Invoke(1);
    }

}
