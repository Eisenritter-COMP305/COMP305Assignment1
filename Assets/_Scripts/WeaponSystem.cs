/*******************************************/
/*       Created By: George Zhou           */
/*       Student ID: 300613283             */
/*******************************************/
// This script control the weapon system

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Util;

public class WeaponSystem : MonoBehaviour
{
    public float[] readyTime;
    public float[] cdTime;
    public GameObject[] projectiles;
    public Quaternion rotation;
    public GameController gameController;

    private void Start()
    {
        rotation = new Quaternion(0, 0, 0,0);
        GameObject gameControllerObject = GameObject.Find("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Fire1")>0)
        {

            FireProjectile(projectiles[0],cdTime[0],0);
        }
        if (Input.GetAxis("Fire2") > 0)
        {
            FireProjectile(projectiles[1],cdTime[1],1);
        }
    }

    /// <summary>
    /// This function determines the cooldown and which projectile to fire
    /// </summary>
    /// <param name="proj"></param>
    /// <param name="cdTime"></param>
    /// <param name="projID"></param>
    void FireProjectile(GameObject proj, float cdTime, int projID)
    {
        if (CheckCooldown(projID)){
            readyTime[projID] = Time.time + cdTime;
            Instantiate(proj, transform.position, rotation);
            gameController.audioSources[(int)SoundClip.LASER].Play();
        }
    }

    /// <summary>
    /// This function get the cooldown time of the projectile, depending on the projectile ID
    /// </summary>
    /// <param name="projID"></param>
    /// <returns></returns>
    bool CheckCooldown(int projID)
    {
        return (readyTime[projID] <= Time.time);
    }
}
