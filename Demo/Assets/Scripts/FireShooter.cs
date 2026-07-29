using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireShooter : MonoBehaviour
{
    public GameObject projectile;
    public Vector3 spawnPosition;
    public bool followSelfPosition;
    public void trigger(){
        if(followSelfPosition){Instantiate(projectile, transform.position, Quaternion.identity);}
        else{Instantiate(projectile, spawnPosition, Quaternion.identity);}
        
    }
}
