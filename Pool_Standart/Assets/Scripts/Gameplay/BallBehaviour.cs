using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BallBehaviour : IntEventInvoker
{
    //Variables
    public int _ballNumberInt;
    public Vector3 ballMaxJumpHight;

    public int BallNumber
    {
        get { return _ballNumberInt; }
    }


    private void Update()
    {
        if(transform.position.y < GameManager.Instance.Table.transform.position.y)
        {
            GameManager.Instance.ballsOnTheDesk.Remove(gameObject);
            if(tag == "FilledBall")
            {
                //add points
            }
            else if(tag == "StripedBall")
            {

            }
            else if(tag == "WhiteBall")
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