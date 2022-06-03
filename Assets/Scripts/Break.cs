
    using System.Collections;  
    using System.Collections.Generic;
    using System;
    using System.Linq;  
    using UnityEngine; 
    using UnityEngine.UI;
    using Random=UnityEngine.Random;
    using UnityEngine.SceneManagement;  
      
    public class Break: MonoBehaviour {  
      
      public bool isBroken;
      public Camera maincamera;
      public GameObject scripts;
      public GameObject ForgeGui;
      public string[] slots;
      public int treeCount;
      public int rockCount;
      public int goldCount;
      public Text treeText;
      public Text rockText;
      public Text goldText;
      public int chance;
      public bool achivement1;
      public bool firstrun;
      public bool advancement4;
      
      
      // Start is called before the first frame update    
      void Start() {
          chance = 4;
          firstrun = true;
      }  
      
      // Update is called once per frame    
        void Update(){
        if (Input.GetMouseButtonDown(0)){ // if left button pressed...
            Ray ray = maincamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit)){
                if(hit.transform.gameObject.tag != "NoDestroy")
                {
                    string name = hit.transform.gameObject.name;
                    //name.CopyTo(scripts.GetComponent<Inventory>().slots, scount);
                    if (name.Contains("Tree")) {
                        scripts.GetComponent<Inventory>().slots.Add("Tree");
                        treeCount += 1;
                    }
                    else if (name.Contains("Rock")) {
                        scripts.GetComponent<Inventory>().slots.Add("Rock");
                        rockCount += 1;
                    }
                    else if (name.Contains("Gold Ore") && scripts.GetComponent<UsableItem>().EquippedItem == ForgeGui.GetComponent<GuiForge>().pick) {
                        int num = Random.Range(0, chance);
                        if (num == 0){
                            achivement1 = true;
                        }
                        goldCount += num;
                    }
                    Debug.Log(treeCount + " || " + rockCount);



                    scripts.GetComponent<Inventory>();
                    Debug.Log(hit.transform.gameObject.tag);
                    Debug.Log(hit.transform.gameObject.name);
                    if (scripts.GetComponent<UsableItem>().EquippedItem == ForgeGui.GetComponent<GuiForge>().pick){
                        Destroy(hit.transform.gameObject);
                    }
                    Destroy(hit.transform.gameObject);
                }
            }
        }
        treeText.text = treeCount.ToString();
        rockText.text = rockCount.ToString();
        goldText.text = goldCount.ToString();
        if (goldCount >= 60 && firstrun == true){
            advancement4 = true;
            firstrun = false;
        }
    }
}   
