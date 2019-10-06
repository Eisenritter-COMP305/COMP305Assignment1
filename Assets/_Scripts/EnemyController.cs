/*******************************************/
/*       Created By: George Zhou           */
/*       Student ID: 300613283             */
/*******************************************/

//This script is meant to be attached to enemy prefab and sets their move/attack patterns

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

    /// <summary>
    /// This moves the enemy in a Sine graph pattern, the starting angle is its initial angle on the sine graph, the magnitude is the multiplier for the graph (Min/Max)
    /// </summary>
    public void SinMove()
    {
        Vector3 movePath = new Vector3(curPosition.x , curPosition.y+Mathf.Sin(StartingAngle) *arcMagnitude, curPosition.z);
        transform.position = movePath;
        StartingAngle += arcFrequency;
        curPosition.x -= HorSpeedRange.minSpeed;
    }

    /// <summary>
    /// This move pattern is linear and sets where the enemy start
    /// </summary>
    public void RandMove()
    {
        SetRandomSpeed();
        Vector3 movePath = new Vector2(curPosition.x, curPosition.y);
        //Debug.Log(movePath);
        transform.position = movePath;
        curPosition.x -= horSpeed;
        curPosition.y -= verSpeed;
    }

    /// <summary>
    /// This function determine the velocity of the enemy
    /// </summary>
    public void SetRandomSpeed()
    {
        verSpeed = Random.Range(VerSpeedRange.minSpeed, VerSpeedRange.maxSpeed);
        horSpeed = Random.Range(HorSpeedRange.minSpeed, HorSpeedRange.maxSpeed);
        //Debug.Log($"The horizontal speed is {horSpeed}, The vertical speed is {verSpeed}");
    }

}
