using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BallBehaviour : IntEventInvoker
{
    //Variables
    public int _ballNumberInt;

    public int BallNumber
    {
        get { return _ballNumberInt; }
    }

    private void Start()
    {
        EventManager.AddListener(EventsNames.removeBallEvent, RemoveBall);
    }

    private void Update()
    {
        if(gameObject.transform.position.y < GameManager.Instance.Table.transform.position.y)
        {
            GameManager.Instance.ballsOnTheDesk.Remove(gameObject);
            if(gameObject.tag == "FilledBall")
            {
                //add points
            }
            else if(gameObject.tag == "StripedBall")
            {

            }
            else if(gameObject.tag == "WhiteBall")
            {

            }
            else
            {

            }


            Destroy(gameObject);
        }
    }


    void RemoveBall(int number)
    {
        if(number == 0)
        {
            //add method to move ball after move
        }
        else if(_ballNumberInt == number)
        {
            Destroy(gameObject);
        }
    }
}