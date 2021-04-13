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


    public int filledBallsCount;
    public int striptedBallsCount;
    public float ballForce;
    public GameObject floor;

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
        EventManager.AddListener(EventsNames.turnEndEvent, CheckForBallLose);
    }

    void Start()
    {
        dictOfInvokers[EventsNames.gameStartedEvent].Invoke(1);
    }

    void Update()
    {
        
    }
    void CheckForBallLose(int unused)
    {
        foreach(GameObject ball in ballsOnTheDesk)
        {
            if (ball.GetComponent<BallBehaviour>().BallNumber == 8)
            {
                dictOfInvokers[EventsNames.gameWinEvent].Invoke(0);
            }
            else if(ball.transform.position.y < floor.transform.position.y)
            {
                dictOfInvokers[EventsNames.removeBallEvent].Invoke(ball.GetComponent<BallBehaviour>().BallNumber);
                ballsOnTheDesk.Remove(ball);
            }
        }
    }

}
