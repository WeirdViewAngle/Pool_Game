using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteBallControls : IntEventInvoker
{
    public float ballForceDefault;
    public Rigidbody RB;
    string currentPlayedBallTag = "FilledBall";

    private void Start()
    {
        dictOfInvokers.Add(EventsNames.wrongBallTouchEvent, new WrongBallTouchEvent());
        EventManager.AddInvoker(EventsNames.wrongBallTouchEvent, this);

        EventManager.AddListener(EventsNames.nextTurnEvent, BallTouchSwitch);
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit rayInfo;

            if(Physics.Raycast(ray, out rayInfo))
            {
                if(rayInfo.collider.tag == "Table")
                {
                    Vector3 direction = (rayInfo.point - gameObject.transform.position).normalized;
                    RB.AddForce(direction * Time.deltaTime * ballForceDefault, ForceMode.Impulse);
                }
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag != currentPlayedBallTag)
        {
            dictOfInvokers[EventsNames.wrongBallTouchEvent].Invoke(0);
        }
    }

    void BallTouchSwitch(int num)
    {
        switch (num)
        {
            case 0:
                currentPlayedBallTag = "FilledBall";
                break;

            case 1:
                currentPlayedBallTag = "StripedBall";
                break;
        }
    }
}
