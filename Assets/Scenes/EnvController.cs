using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvController : MonoBehaviour
{
//  
    public GameObject treePrefab;
    public int treeObjCount = 0;
    public float treeMaxObjects = 10;

//  
    public GameObject rockPrefab;
    public int rockObjCount = 0;
    public float rockMaxObjects = 10;

// s
    public GameObject mountainPrefab;
    public int mountainObjCount = 0;
    public float mountainMaxObjects = 20;

//  
    public GameObject goldPrefab;
    public int goldObjCount = 0;
    public float goldMaxObjects = 10;

//  Rainbow
    public GameObject rainbowPrefab;
    public int rainbowObjCount = 0;
    public float rainbowMaxObjects = 10;

//  Other
    public GameObject holder;
    public GameObject planetObj;

    void Awake()
    {
        if (planetObj)
        {
            Debug.Log(planetObj.transform.localScale.x);
            GenerateObject(treePrefab, treeObjCount, treeMaxObjects, 72);
            GenerateObject(rockPrefab, rockObjCount, rockMaxObjects, 72);
            GenerateMountains();
            GenerateObject(goldPrefab, goldObjCount, goldMaxObjects, 72);
            GenerateObject(rainbowPrefab, rainbowObjCount, rainbowMaxObjects, 72);
        }
        else
        {
            Debug.Log("You are a idiot future alex");
        }
        
    }

    public void GenerateObject(GameObject Prefab, int ObjCount, float MaxObjects, float planetSize)
    {
        Transform holder = new GameObject("Environment").transform;
        holder.parent = transform;

        while (ObjCount < MaxObjects)
        {
            Vector3 randomPoint = Random.onUnitSphere * planetSize;
            if (randomPoint.y <= 65){
                Transform obj = Instantiate(Prefab, randomPoint, Quaternion.identity).transform;

                obj.name = Prefab.name + ObjCount;
                obj.parent = holder;

                Vector3 gravityUp = (obj.position - transform.position).normalized;
                Vector3 localUp = obj.transform.up;

                obj.rotation = Quaternion.FromToRotation(localUp, gravityUp) * obj.rotation;

                ObjCount++;
            }
        }
    }

    public void GenerateMountains()
    {
        Transform holder = new GameObject("Environment").transform;
        holder.parent = transform;

        while (mountainObjCount < mountainMaxObjects)
        {
            Vector3 randomPoint = Random.onUnitSphere * (68.69f);
            float randomNumber = Random.Range(5.0f, 15.0f);

            if (randomPoint.y <= 65){
                Transform obj = Instantiate(mountainPrefab, randomPoint, Quaternion.identity).transform;
                obj.transform.localScale = new Vector3(randomNumber, randomNumber, randomNumber);

                obj.name = "Mountain " + mountainObjCount;
                obj.parent = holder;

                Vector3 gravityUp = (obj.position - transform.position).normalized;
                Vector3 localUp = obj.transform.up;

                obj.rotation = Quaternion.FromToRotation(localUp, gravityUp) * obj.rotation;

                mountainObjCount++;
            }
        }
    }
    
}
