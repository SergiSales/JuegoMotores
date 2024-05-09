using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScriptIntro : MonoBehaviour
{
    private bool pressed = false;

    private void Start() {
        StartCoroutine(Auto());
    }
    private void Update() {
        if(Input.GetKeyDown(KeyCode.Space)){
            StartCoroutine(Skip());
        }
    }

    IEnumerator Skip(){
        if(!pressed){
            //Implementar que salga en pantalla que vuelva a clicar para skipear
            pressed = true;
            Debug.Log("1");
            yield return new WaitForSeconds(2f);
            pressed = false;
            Debug.Log("0");
        }
        else{
            Debug.Log("2");
            yield return new WaitForSeconds(0.2f);
            SceneManager.LoadScene("Game");
        }
    }

    IEnumerator Auto(){
        yield return new WaitForSeconds(20f);
        SceneManager.LoadScene("Game");
    }
}
