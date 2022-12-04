using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    public float moveSpeed;
    public Vector2 minMaxYValue;
    Vector2 pos;
    void Start()
    {
        
    }

    
    void Update()
    {
        //Vector3.Up = new Vector3(0,1,0)
        transform.position += Vector3.up * moveSpeed * Time.deltaTime;

        if (transform.position.y > minMaxYValue.x)
        {
            pos = transform.position;
            pos.x = transform.position.x;
            pos.y = minMaxYValue.y;
            transform.position = pos;
            ShowOrHide();
        }
            

        
    }

    void ShowOrHide()
    {
        if (Random.value > 0.5f)
        {
           Debug.Log("Disabling");
           transform.GetChild(0).gameObject.SetActive(false);
           return;
        }

        transform.GetChild(0).gameObject.SetActive(true);
    }
}
