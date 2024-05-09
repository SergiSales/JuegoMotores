using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathCreation : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform EscenarioObj;
    private Vector3 nextTileSpawn;



    void Start()
    {
        nextTileSpawn.z = 180;
        StartCoroutine(spawnTile());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator spawnTile()
    {
        yield return new WaitForSeconds(1);
        Instantiate(EscenarioObj, nextTileSpawn, EscenarioObj.rotation);
        nextTileSpawn.z += 30;
        StartCoroutine(spawnTile());
    }
}
