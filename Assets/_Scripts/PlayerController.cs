using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Util;

public class PlayerController : MonoBehaviour
{
    public Speed speed;
    //Target destination
    private Transform target;
    public Boundary boundary;

    Vector3 dest = Vector3.zero;
    
    // Update is called once per frame
    void Update()
    {
        Move();
        CheckBounds();
    }

    public void Move()
    {
        float x = Input.GetAxis("Horizontal")*SpeedChange();
        float y = Input.GetAxis("Vertical")* SpeedChange();
        Vector3 movePath = new Vector3(x, y, 0);
        dest += movePath;
        transform.position += movePath;
    }

    public void CheckBounds()
    {
        if (transform.position.y > boundary.TopBounds)
        {
            transform.position = new Vector2(transform.position.x, boundary.TopBounds);
        }
        if (transform.position.y < boundary.BottomBounds)
        {
            transform.position = new Vector2(transform.position.x, boundary.BottomBounds);
        }
        if (transform.position.x > boundary.RightBounds)
        {
            transform.position = new Vector2( boundary.RightBounds, transform.position.y);
        }
        if (transform.position.x < boundary.LeftBounds)
        {
            transform.position = new Vector2( boundary.LeftBounds, transform.position.y);
        }
    }

    //Checks if player is under damage threshold
    public bool CheckHealth()
    {
        return true;
    }

    //changes speed if player falls under a certain threshold
    public float SpeedChange()
    {
        return CheckHealth() ? speed.maxSpeed : speed.maxSpeed;
    }
}
