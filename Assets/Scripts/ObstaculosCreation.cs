using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaculosCreation : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] tipoObstaculos;
    private Vector3 nextSpawn = new Vector3(-4.30000019f,0.5f,8.57999992f);

    private int randomT;
    private int randomTipo;
    private int randomPath;

    private float[] posX = new float[3];

    public GameManager GM;

    private bool allowed = true;
    private bool BossAparece = false;
    

    void Start()
    {
        posX[0]= 8.58f;
        posX[1] = 0f;
        posX[2] = -8.58f;



        
        StartCoroutine(SpawnObstaculos());
    }

    IEnumerator SpawnObstaculos(){
        

        if(BossAparece == false){
            randomT = Random.Range(0,10);

            if(randomT == 0){
                BossAparece = true;
                StartCoroutine(BossComportamiento());
            }
        }
        
        randomTipo = Random.Range(0,3);

        randomPath = Random.Range(15,25);
        nextSpawn.z += randomPath;
        randomPath = Random.Range(0,3);
        nextSpawn.x = posX[randomTipo];

        Instantiate(tipoObstaculos[randomTipo], nextSpawn, tipoObstaculos[randomTipo].transform.rotation);

        yield return new WaitForSeconds(1.5f);
        if(GM.parar == false){
            StartCoroutine(SpawnObstaculos());
        }
    }

    IEnumerator BossComportamiento(){
        Instantiate(tipoObstaculos[3], nextSpawn, tipoObstaculos[3].transform.rotation);
        allowed = false;
        GM.allowed = false;

        float transicion = (0.1f - RenderSettings.fogDensity) / 6;

        float r = 0.78f;
        float g = 0.59f;
        float b = 0.32f;

        for(int i = 0; i < 6; i++) {
            r -= 0.0955f;
            g -= 0.081666f;
            b -= 0.05f;
            RenderSettings.fogDensity += transicion;
            RenderSettings.fogColor = new Color(r,g,b);
            yield return new WaitForSeconds(0.1f);
            StopCoroutine(GM.FogDensity());
            StartCoroutine(GM.FogStrength());
        }

    }

}


