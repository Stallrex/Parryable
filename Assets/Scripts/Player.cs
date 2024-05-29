using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Player : MonoBehaviour
{

    public bool isBlocking;
    public float blockingTime;
    public float parryWindow = 1f;

    public GroundCheck groundCheck;
    public UnityEvent<float> onBlock;
    public UnityEvent<float> onBlockUpdate;

    private int blockPunish = 20;
    public static Player instance;


    AudioSource ad;

    public AudioClip parry;
    public AudioClip block;

    Rigidbody rb;

    private float blockBar;
    private float blockBarMax = 100;

    public float fallTime;

    public GameObject BlockScreen;
    public GameObject ParryScreen;
    private void Awake(){

        if(instance == null){
            instance = this;
        }
        else{
            Destroy(this);
        }

        blockBar = blockBarMax;
    }

    void Reset()
    {
        // Try to get groundCheck.
        groundCheck = GetComponentInChildren<GroundCheck>();
    }

    void Start()
    {
        ad = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
        Time.timeScale = 1;
    }

    void Update()
    {
        onBlockUpdate.Invoke(blockBar);
        Blocking();
        Falldamage();
    }

    void Blocking(){

        if(Input.GetKey(KeyCode.F) && blockBar > blockPunish){
            isBlocking = true;
            blockingTime += Time.deltaTime;
        }
        else{
            isBlocking = false;
            blockingTime = 0f;
            if(blockBar < blockBarMax) blockBar += 10 * Time.deltaTime;
        }
    }

    void Falldamage(){
        if(!groundCheck.isGrounded){
            fallTime += Time.deltaTime;
        }
        else{
            if(fallTime > 1){
                gameObject.GetComponent<Health>().TakeDamage(20, this.gameObject);
            }
            fallTime = 0; 
        }
    }

    public void Blocked(){
        blockBar -= blockPunish;
        ad.PlayOneShot(block);
        onBlock.Invoke(blockBar);
        Time.timeScale = 0;
        BlockScreen.SetActive(true);
        Invoke("ActivateAgain", 0.4f);
        Time.timeScale = 1;
        rb.AddForce(new Vector3(0, 15, 0), ForceMode.VelocityChange);
    }

    public void Parry(){
        if(blockBar <= 90)blockBar += 10;
        ad.PlayOneShot(parry);
        onBlock.Invoke(blockBar);
        Time.timeScale = 0;
        ParryScreen.SetActive(true);
        Invoke("ActivateAgain", 0.4f);
        Time.timeScale = 1;
        rb.AddForce(new Vector3(0, 30, 0), ForceMode.VelocityChange);
    }

    public void ParryDamageSource(GameObject damageSource){
        if(damageSource == this.gameObject){
            
        }

        if(damageSource.CompareTag("basicBullet")){
            
        }
    }

    public void ActivateAgain(){
        BlockScreen.SetActive(false);
        ParryScreen.SetActive(false);
    }
}
