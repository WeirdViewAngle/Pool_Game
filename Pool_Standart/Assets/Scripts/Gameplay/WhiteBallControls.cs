using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteBallControls : MonoBehaviour
{
    public float ballForceDefault;
    public Rigidbody RB;


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
}
