using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Util;

public class EnemyController : MonoBehaviour
{

    //This is a list of optional move patterns
    public enum MovePatterns
    {
        StaticMove,
        RandMove,
        SinMove,
        CosMove,
        TanMove,
    }
    [Header("Move Patterns")]
    public MovePatterns movePatterns;

    [Header("Position Status")]
    public Vector3 curPosition;
    public Boundary boundary;

    [Header("Curve Variables")]
    public float StartingAngle = 0;
    public float arcFrequency;
    public float arcMagnitude = 1;

    [Header("Speed Variables")]
    public Speed HorSpeedRange;
    public Speed VerSpeedRange;
    public float horSpeed;
    public float verSpeed;

    // Start is called before the first frame update
    void Start()
    {
        boundary = new Boundary(transform.position.y, transform.position.x, -transform.position.y, -transform.position.x);
        curPosition = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        switch (movePatterns)
        {
            case MovePatterns.SinMove:
                SinMove();
                break;
            case MovePatterns.RandMove:
                RandMove();
                break;
            default:
                break;
        }

        Destroy(gameObject, 7.5f);
    }

    public void SinMove()
    {
        Vector3 movePath = new Vector3(curPosition.x , curPosition.y+Mathf.Sin(StartingAngle) *arcMagnitude, curPosition.z);
        transform.position = movePath;
        StartingAngle += arcFrequency;
        curPosition.x -= HorSpeedRange.minSpeed;
    }

    public void RandMove()
    {
        SetRandomSpeed();
        Vector3 movePath = new Vector2(curPosition.x, curPosition.y);
        //Debug.Log(movePath);
        transform.position = movePath;
        curPosition.x -= horSpeed;
        curPosition.y -= verSpeed;
    }


    public void SetRandomSpeed()
    {
        verSpeed = Random.Range(VerSpeedRange.minSpeed, VerSpeedRange.maxSpeed);
        horSpeed = Random.Range(HorSpeedRange.minSpeed, HorSpeedRange.maxSpeed);
        //Debug.Log($"The horizontal speed is {horSpeed}, The vertical speed is {verSpeed}");
    }

}
