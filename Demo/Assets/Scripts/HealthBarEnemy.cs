using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarEnemy : MonoBehaviour
{
    public EnemyHealth EH;
    public int maxXSize;
    private int savehealth;
    private Vector3 originalPosi;
    private int set;
    // Start is called before the first frame update
    // Update is called once per frame
    void Awake() {savehealth = EH.health;  originalPosi.x = transform.position.x + 0.3f;  originalPosi.y = transform.position.y;  originalPosi.z = transform.position.z;}
    void FixedUpdate()
    {
        if(savehealth != EH.health)
        {
            set = 50;
            if (EH.health > 0)
            {
                transform.localScale = new Vector3((EH.health * 1.0f) / (EH.maxHealth * 1.0f) * maxXSize, transform.localScale.y, transform.localScale.z);
            }
            else
            {
                transform.localScale = new Vector3(0, transform.localScale.y, transform.localScale.z);
            }
            
        }
        else
        {
            transform.position = originalPosi;
        }
        if(set > 0)
        {
            this.Shake(set);
            set--;
        }
        savehealth = EH.health;
    }
    private void Shake(int selly)
    {
        transform.position = new Vector3(originalPosi.x + Random.Range(-0.02f, 0.02f) * selly, originalPosi.y + Random.Range(-0.02f, 0.02f) * selly, originalPosi.z);
    }
}
