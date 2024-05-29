using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{

    private int currentHealth;
    public int maxHealth;

     public UnityEvent<float, float> onDamage;
    public UnityEvent onDeath;


    private Player player;



    // Start is called before the first frame update

    void Awake(){
        currentHealth = maxHealth;
    }

    void Start()
    {
        if(gameObject.GetComponent<Player>()){
            player = gameObject.GetComponent<Player>();
        }
        //target.GetComponent<Health>().TakeDamage(damage);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damage, GameObject damageSource){

        if(gameObject.GetComponent<Player>()){
            if(player.isBlocking && player.blockingTime < player.parryWindow){
                damage = 0;
                Player.instance.ParryDamageSource(damageSource);
                Player.instance.Parry();
            }
            else if(player.isBlocking && player.blockingTime > player.parryWindow){
                damage = 0;
                Player.instance.Blocked();
            }
        }
        currentHealth -= damage;
        onDamage.Invoke(currentHealth, maxHealth);
        if(currentHealth <= 0){
            onDeath.Invoke();
            Destroy(gameObject);
        }
    }
}
