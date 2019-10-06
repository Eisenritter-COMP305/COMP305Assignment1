/*******************************************/
/*       Created By: George Zhou           */
/*       Student ID: 300613283             */
/*******************************************/
// This script is meant to be attached to the player projectiles
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Util;

public class PlayerProjectileController : MonoBehaviour
{
    private Rigidbody rb;
    //[SerializeField]
    public GameController gameController;


[SerializeField]
    public Speed velo;

    [SerializeField]
    public Boundary boundary;

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
        Destroy(gameObject, 2f);
        CheckBounds();
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + new Vector3 (transform.right.x , transform.right.y) * Time.fixedDeltaTime * this.velo.maxSpeed);
    }

    /// <summary>
    /// Depends on what it collides with, activate certain function
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Background"))
        {
            Destroy(gameObject);
        }
        if (collision.collider.CompareTag("Enemy"))
        {

            Destroy(collision.gameObject);
            gameController.audioSources[(int)SoundClip.EXPLOSION].Play();
            gameController.AddScore();
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// If the projectile goes out of the boundary, destroy the object
    /// </summary>
    void CheckBounds()
    {
        if (transform.position.x >= this.boundary.RightBounds)
        {
            Destroy(gameObject);

        }
    }
}
