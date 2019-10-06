/*******************************************/
/*       Created By: George Zhou           */
/*       Student ID: 300613283             */
/*******************************************/

//This is the player controller script, meant to be attached to the player character

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Util;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    //[SerializeField]
    public GameController gameController;

    public Speed speed;
    //Target destination
    private Transform target;
    public Boundary boundary;

    Vector3 dest = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        GameObject gameControllerObject = GameObject.Find("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        rb = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update()
    {
        Move();
        CheckBounds();
    }

    /// <summary>
    /// Control the character depends on the input
    /// </summary>
    public void Move()
    {
        float x = Input.GetAxis("Horizontal")*SpeedChange();
        float y = Input.GetAxis("Vertical")* SpeedChange();
        Vector3 movePath = new Vector3(x, y, 0);
        dest += movePath;
        transform.position += movePath;
    }

    /// <summary>
    /// Check the boundary of the player movements
    /// </summary>
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

    //If the player collides with enemy object, they lose life
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            gameController.Lives --;
        }
    }
}
