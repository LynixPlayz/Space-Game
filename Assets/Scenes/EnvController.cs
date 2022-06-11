using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvController : MonoBehaviour
{
//  Tree
    public GameObject treePrefab;
    public int treeObjCount = 0;
    public float treeMaxObjects = 10;

//  Rock
    public GameObject rockPrefab;
    public int rockObjCount = 0;
    public float rockMaxObjects = 10;

// Mountains
    public GameObject mountainPrefab;
    public int mountainObjCount = 0;
    public float mountainMaxObjects = 20;

//  Gold
    public GameObject goldPrefab;
    public int goldObjCount = 0;
    public float goldMaxObjects = 10;

//  Other
    public GameObject holder;
    public float planetSize = 25f;
    
    

    void Awake()
    {
        GenerateTrees();
        GenerateRocks();
        GenerateMountains();
        GenerateGold();
    }

    public void GenerateTrees()
    {
        Transform holder = new GameObject("Environment").transform;
        holder.parent = transform;

        while (treeObjCount < treeMaxObjects)
        {
            Vector3 randomPoint = Random.onUnitSphere * planetSize;
            if (randomPoint.y <= 65){
                Transform obj = Instantiate(treePrefab, randomPoint, Quaternion.identity).transform;

                obj.name = "Tree " + treeObjCount;
                obj.parent = holder;

                Vector3 gravityUp = (obj.position - transform.position).normalized;
                Vector3 localUp = obj.transform.up;

                obj.rotation = Quaternion.FromToRotation(localUp, gravityUp) * obj.rotation;

                treeObjCount++;
            }
        }
    }
    public void GenerateRocks()
    {
        Transform holder = new GameObject("Environment").transform;
        holder.parent = transform;

        while (rockObjCount < rockMaxObjects)
        {
            Vector3 randomPoint = Random.onUnitSphere * planetSize;
            
            if (randomPoint.y <= 65){
                Transform obj = Instantiate(rockPrefab, randomPoint, Quaternion.identity).transform;

                obj.name = "Rock " + rockObjCount;
                obj.parent = holder;

                Vector3 gravityUp = (obj.position - transform.position).normalized;
                Vector3 localUp = obj.transform.up;

                obj.rotation = Quaternion.FromToRotation(localUp, gravityUp) * obj.rotation;

                rockObjCount++;
            }
        }
    }

    public void GenerateMountains()
    {
        Transform holder = new GameObject("Environment").transform;
        holder.parent = transform;

        while (mountainObjCount < mountainMaxObjects)
        {
            Vector3 randomPoint = Random.onUnitSphere * (planetSize - 3.5f);
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

    public void GenerateGold()
    {
        Transform holder = new GameObject("Environment").transform;
        holder.parent = transform;

        while (goldObjCount < goldMaxObjects)
        {
            Vector3 randomPoint = Random.onUnitSphere * planetSize;

            Transform obj = Instantiate(goldPrefab, randomPoint, Quaternion.identity).transform;

            obj.name = "Gold Ore " + goldObjCount;
            obj.parent = holder;

            Vector3 gravityUp = (obj.position - transform.position).normalized;
            Vector3 localUp = obj.transform.up;

            obj.rotation = Quaternion.FromToRotation(localUp, gravityUp) * obj.rotation;

            goldObjCount++;
        }
    }
}
