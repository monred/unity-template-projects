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
        targetFile.onGrounded = (other.tag == "Wall" || other.tag == "Floor");
    }
    private void OnTriggerExit2D(Collider2D other){
        targetFile.onGrounded = !(other.tag == "Wall" || other.tag == "Floor");
    }
    
}
