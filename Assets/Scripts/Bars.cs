using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bars : MonoBehaviour
{
    public Transform healthBar;
    public Transform blockBarBar;

    public void SetSizeHealth(int currentHealth, int maxHealth){
        healthBar.localScale = new Vector3(0.8624482f * currentHealth / 100, 0.2942783f, 0.34679f);
    }

    public void SetSizeBlock(float blockBar){
        
        blockBarBar.localScale = new Vector3(0.8624482f * blockBar / 100, 0.5516679f, 0.34679f);

    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
