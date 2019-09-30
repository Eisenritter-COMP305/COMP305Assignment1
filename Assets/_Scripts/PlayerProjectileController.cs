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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Background"))
        {
            Destroy(gameObject);
        }
        if (collision.collider.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            gameController.AddScore();
            Debug.Log(gameController.Score);
            Destroy(gameObject);
        }
    }
    void CheckBounds()
    {

        if (transform.position.x <= this.boundary.LeftBounds)
        {

        }
        if (transform.position.x >= this.boundary.RightBounds)
        {
            Destroy(gameObject);

        }
    }
}
