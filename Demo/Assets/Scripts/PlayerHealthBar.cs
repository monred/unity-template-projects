using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthBar : MonoBehaviour
{
    public PlayerInformation PI;
    public float maxXSize;
    private int savehealth;
    // Start is called before the first frame update
    // Update is called once per frame
    void Awake() {savehealth = PI.health; }
    void Update()
    {
        if(savehealth != PI.health)
        {
            if (PI.health > 0)
            {
                transform.localScale = new Vector3((PI.health * 1.0f) / (PI.maxHealth * 1.0f) * maxXSize, transform.localScale.y, transform.localScale.z);
            }
            else
            {
                transform.localScale = new Vector3(0, transform.localScale.y, transform.localScale.z);
            }
            
        }
        savehealth = PI.health;
    }
}
