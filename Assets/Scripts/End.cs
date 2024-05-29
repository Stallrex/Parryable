using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class End : MonoBehaviour
{

    int sceneId = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate() {
        if(Input.GetKeyDown(KeyCode.R)){
            Restart();
        }    
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("EndPortal")){
            sceneId =  SceneManager.GetActiveScene().buildIndex;
            sceneId++;
            SceneManager.LoadScene(sceneId);
        }
    }

    public void Restart(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
