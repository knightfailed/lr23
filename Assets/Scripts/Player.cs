using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Vector2 xValue;
    public bool changeDirectionBool, leftFacing, changeIt, easing;
    Animator animator;
    Vector3 desiredPosition;


    // Start is called before the first frame update
    void Start()
    {
        DesiredPosition();
        changeDirection();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (changeIt)
        {
            if (easing)
            {
                transform.position = Vector3.Lerp(transform.position, desiredPosition, .1f);
            }
            else
            {
                transform.position = desiredPosition;
            }

            transform.position = Vector3.Lerp(transform.position, desiredPosition, .1f);

            if (Mathf.Abs(desiredPosition.x - transform.position.x) <= 0.1f)
            {
                Debug.Log("Changing gavity");
                changeIt = false;
            }
        }
        if (Input.GetMouseButtonDown(0))
        {
            
        }
    }
    public void CallThisMethod()
    {
        DesiredPosition();
        changeDirection();
    }

    public void DesiredPosition()
    {
        desiredPosition = new Vector2(changeDirectionBool ? xValue.x : xValue.y, transform.position.y);    
    }

    void changeDirection()
    {
        changeDirectionBool = !changeDirectionBool;

        if (changeDirectionBool != leftFacing)
        {
            changeIt = true;

            leftFacing = changeDirectionBool;
        }

        Debug.Log(transform.position.x);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Spike")
        {
            Debug.Log("dead Player");
        }
    }
}
