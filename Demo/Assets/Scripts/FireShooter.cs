using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireShooter : MonoBehaviour
{
    public Vector3 spawnPosition;
    public bool followSelfPosition;
    public List<Transform> projectileList = new List<Transform>();
    private int i = 0;
    private void Awake(){i = 0;}
    public void trigger(){
        if(projectileList.Count > 0){
                
            i++;
            if(i == projectileList.Count){
                i = 0;
            }
            resetProjec(projectileList[i]);
            if(followSelfPosition){projectileList[i].position = transform.position;}
            else{projectileList[i].position = spawnPosition;}    
        }
        
    }
    
    public void resetProjec(Transform projec){
        projec.GetComponent<DamageArea>().resetDelay();
        projec.GetComponent<ProjectileScri>().resetDelay();
    }
}
