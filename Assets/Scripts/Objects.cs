using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Objects
{
    public class Objects : MonoBehaviour
    {
        public void blank()
        {
            return;
        }
    }


    public class ObjectTree : MonoBehaviour
    {
        //  Tree
        public GameObject treePrefab;
        public int treeObjCount = 0;
        public float treeMaxObjects = 10;
        public float planetSize = 71.5f;

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
    }
}
