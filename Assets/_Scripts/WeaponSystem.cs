using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSystem : MonoBehaviour
{
    public float[] readyTime;
    public float[] cdTime;
    public GameObject[] projectiles;
    public Quaternion rotation;
    private void Start()
    {
        rotation = new Quaternion(0, 0, 0,0);
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

    void FireProjectile(GameObject proj, float cdTime, int projID)
    {
        if (CheckCooldown(projID)){
            readyTime[projID] = Time.time + cdTime;
            Instantiate(proj, transform.position, rotation);
        }
    }

    bool CheckCooldown(int projID)
    {
        return (readyTime[projID] <= Time.time);
    }
}
