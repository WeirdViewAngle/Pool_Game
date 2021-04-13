using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BallBehaviour : IntEventInvoker
{
    //Variables
    public int _ballNumberInt;
    public float DefaultForce;

    public int BallNumber
    {
        get { return _ballNumberInt; }
    }

    //Rigidbody
    Rigidbody rigidbody;
    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();

        EventManager.AddListener(EventsNames.removeBallEvent, RemoveBall);

        if(gameObject.tag == "WhiteBall")
        {
            rigidbody.AddForce((GameManager.Instance.ballsOnTheDesk[1].gameObject.transform.position * DefaultForce) * Time.deltaTime, ForceMode.Impulse); 
        }
    }

    void OnCollisionEnter(Collision coll)
    {
        //rigidbody.AddForce(coll.relativeVelocity);
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