using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeetScr : MonoBehaviour
{
    private PlayerControl targetFile;
    // Start is called before the first frame update

    void Awake() {
        if(transform.parent != null){
            targetFile = transform.parent.GetComponent<PlayerControl>();
        }
    }

    private void OnTriggerStay2D(Collider2D other){
        if((other.tag == "Wall" || other.tag == "Floor")){
        targetFile.onGrounded = true;}
    }
    private void OnTriggerExit2D(Collider2D other){
        if((other.tag == "Wall" || other.tag == "Floor")){
        targetFile.onGrounded = false;}
    }
    
}
