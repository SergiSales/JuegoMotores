using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EscenarioBehaviour : MonoBehaviour
{
    public GameObject player;
    private bool eliminando = false;
    void Start()
    {
       player = GameObject.FindWithTag("Player");
    }


    // Update is called once per frame
    void Update()
    {
        if(player.transform.position.z > this.transform.position.z + 30 && eliminando == false){
            eliminando = true;
            StartCoroutine(EliminarEscenario());
        }
    }


    IEnumerator EliminarEscenario(){
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
        eliminando = false;
    }
}



