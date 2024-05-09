using System.Collections;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    private MovementPlayer MP;
    public GameObject[] escenario;
    public GameObject player;
    private Vector3 nextTileSpawn;
    private float nextSpawn;

    private int escIndice = 0;

    private int auxEsc = 0;

    private int random;
    private float randomF;

    private int cont;
    public bool allowed = true;

    public bool parar = false;

    
    void Start()
    {
        nextSpawn = 30f;
        nextTileSpawn.z = 0;


        RenderSettings.fogColor = new Color(0.78f,0.59f,0.32f);
        RenderSettings.fogDensity = 0.03f;


        EmpezarPartida();
        StartCoroutine(spawnTile());
        StartCoroutine(FogDensity());
    }


    // Update is called once per frame
    void Update()
    {
        if(player.transform.position.z > nextSpawn && parar == false){
            StartCoroutine(spawnTile());
            nextSpawn += 30;
        }

    }

    IEnumerator spawnTile()
    {

        Quaternion rot = escenario[escIndice].transform.rotation;
        GameObject t = escenario[escIndice].gameObject;


        escIndice = UnityEngine.Random.Range(0,5);

        while(escIndice == auxEsc){
            escIndice = UnityEngine.Random.Range(0,5);
        }

        auxEsc = escIndice;

        yield return new WaitForSeconds(2.8f);
        GameObject prov = Instantiate(t, nextTileSpawn, rot);
        prov.GetComponent<EscenarioBehaviour>().player = player;
        nextTileSpawn.z += 30;
    }

    void EmpezarPartida(){
        Quaternion rot = escenario[0].transform.rotation;
        GameObject t = escenario[0].gameObject;

        GameObject prov = Instantiate(t, nextTileSpawn, rot);
        prov.GetComponent<EscenarioBehaviour>().player = player;
        nextTileSpawn.z += 30;

        rot = escenario[1].transform.rotation;
        t = escenario[1].gameObject;
        prov = Instantiate(t, nextTileSpawn, rot);
        prov.GetComponent<EscenarioBehaviour>().player = player;
        nextTileSpawn.z += 30;

        rot = escenario[2].transform.rotation;
        t = escenario[2].gameObject;
        prov = Instantiate(t, nextTileSpawn, rot);
        prov.GetComponent<EscenarioBehaviour>().player = player;
        nextTileSpawn.z += 30;

        rot = escenario[3].transform.rotation;
        t = escenario[3].gameObject;
        prov = Instantiate(t, nextTileSpawn, rot);
        prov.GetComponent<EscenarioBehaviour>().player = player;
        nextTileSpawn.z += 30;

        rot = escenario[4].transform.rotation;
        t = escenario[4].gameObject;
        prov = Instantiate(t, nextTileSpawn, rot);
        prov.GetComponent<EscenarioBehaviour>().player = player;
        nextTileSpawn.z += 30;
    }

    public IEnumerator FogDensity(){
        Debug.Log("dens   ,  " + RenderSettings.fogColor);
        random = Random.Range(2,6);
        yield return new WaitForSeconds(random);


        if(RenderSettings.fogDensity <=  0.03f){
            randomF = Random.Range(RenderSettings.fogDensity, RenderSettings.fogDensity+0.02f);

            
        } 
        else{
            randomF = Random.Range(RenderSettings.fogDensity, RenderSettings.fogDensity-0.02f);

        } 

        float transicion = (randomF - RenderSettings.fogDensity) / 6;

        for(int i = 0; i < 6; i++) {
            RenderSettings.fogDensity += transicion;
            yield return new WaitForSeconds(0.1f);
        }
        
        if(allowed == true && parar == false){
            StartCoroutine(FogDensity());
        }
        
    }

    public IEnumerator FogStrength(){
        if(parar == false){
            cont++;

        Debug.Log("STR  ,  " + RenderSettings.fogColor);
        yield return new WaitForSeconds(1);
        if(cont == 2){
            float transicion = (0.03f - RenderSettings.fogDensity) / 6;

            float r = 0.207f;
            float g = 0.1f;
            float b = 0.02f;

            for(int i = 0; i < 6; i++) {
                r += 0.0955f;
                g += 0.081666f;
                b += 0.05f;
                RenderSettings.fogDensity += transicion;
                RenderSettings.fogColor = new Color(r,g,b);
                yield return new WaitForSeconds(0.1f);
            }
        

            StopCoroutine(FogStrength());
            StartCoroutine(FogDensity());
            allowed = true;

        }
        else{
            random = Random.Range(2,6);
            yield return new WaitForSeconds(random);


            if(RenderSettings.fogDensity <=  0.1f){
                randomF = Random.Range(RenderSettings.fogDensity, RenderSettings.fogDensity+0.04f);
            }
            else{
                randomF = Random.Range(RenderSettings.fogDensity, RenderSettings.fogDensity-0.01f);
            }

            float transicion = (randomF - RenderSettings.fogDensity) / 6;

            for(int i = 0; i < 6; i++) {
                RenderSettings.fogDensity += transicion;
                yield return new WaitForSeconds(0.1f);
            }
        
            
        StartCoroutine(FogStrength());
        }
        }
        
    }
}



