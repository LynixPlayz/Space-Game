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
      private bool isBrokenCopy2;
      private int isBrokenCopy;
      private int achivement1Copy;
      private bool achivement1Copy2;
      private int firstrunCopy;
      private bool firstrunCopy2;
      private int advancement4Copy;
      private bool advancement4Copy2;
      private int swordIsEquipped;
      private int pickIsEquipped;

      
      // Start is called before the first frame update    
      void Start() {
        chance = 4;
        firstrun = true;
        Cursor.lockState = CursorLockMode.Locked;
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
                    if (scripts.GetComponent<UsableItem>().EquippedItem == ForgeGui.GetComponent<GuiForge>().pick || scripts.GetComponent<UsableItem>().EquippedItem == ForgeGui.GetComponent<GuiForge>().sword && name.Contains("Gold Ore")){
                        Destroy(hit.transform.gameObject);
                    } else if (!name.Contains("Gold Ore")){
                        Destroy(hit.transform.gameObject);
                    }
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

    void Convert(){
        if (isBroken == true)
        {
           isBrokenCopy = 1;
        }
        else 
        {
            isBrokenCopy = 0;
        }
        if (achivement1 == true){
            achivement1Copy = 1;
        }
        else 
        {
            achivement1Copy = 0;
        }
        if (firstrun == true){
            firstrunCopy = 1;
        }
        else 
        {
            firstrunCopy = 0;
        }
        if (advancement4 == true){
            advancement4Copy = 1;
        }
        else 
        {
            advancement4Copy = 0;
        }
        if (scripts.GetComponent<UsableItem>().obtainedItems.Contains("Sword")){
            swordIsEquipped = 1;
        }
        else
        {
            swordIsEquipped = 0;
        }
        if (scripts.GetComponent<UsableItem>().obtainedItems.Contains("Pick")){
            pickIsEquipped = 1;
        }
        else
        {
            pickIsEquipped = 0;
        }
    }
    

    public void Save() {
        Convert();
        PlayerPrefs.SetInt("isBroken", isBrokenCopy);
        PlayerPrefs.SetInt("treeCount", treeCount);
        PlayerPrefs.SetInt("rockCount", rockCount);
        PlayerPrefs.SetInt("goldCount", goldCount);
        PlayerPrefs.SetInt("achivement1", achivement1Copy);
        PlayerPrefs.SetInt("firstrun", firstrunCopy);
        PlayerPrefs.SetInt("advancement4", advancement4Copy);
        PlayerPrefs.SetFloat("PlayerX", gameObject.transform.parent.gameObject.transform.position.x);
        PlayerPrefs.SetFloat("PlayerY", gameObject.transform.parent.gameObject.transform.position.y);
        PlayerPrefs.SetFloat("PlayerZ", gameObject.transform.parent.gameObject.transform.position.z);
        PlayerPrefs.SetInt("Pick", pickIsEquipped);
        PlayerPrefs.SetInt("Sword", swordIsEquipped);
        
    }

    void Deconvert() {
        if (PlayerPrefs.GetInt("isBroken", isBrokenCopy) == 1){
            isBroken = true;
        }
        else {
           isBroken = false;
        }
        if (PlayerPrefs.GetInt("achivement1", achivement1Copy) == 1)
        {
            achivement1 = true;
        } else {
            achivement1 = false;
        }
        if (PlayerPrefs.GetInt("firstrun", firstrunCopy) == 1)
        {
            firstrun = true;
        } else {
            firstrun = false;
        }
        if (PlayerPrefs.GetInt("advancement4", advancement4Copy) == 1)
        {
            advancement4 = true;
        } else {
            advancement4 = false;
        }
        if (PlayerPrefs.GetInt("Pick") == 1){
            scripts.GetComponent<UsableItem>().IsEquipped = true;
            scripts.GetComponent<UsableItem>().EquippedItem = ForgeGui.GetComponent<GuiForge>().pick;
        }
        if (PlayerPrefs.GetInt("Sword") == 1){
            scripts.GetComponent<UsableItem>().IsEquipped = true;
            scripts.GetComponent<UsableItem>().EquippedItem = ForgeGui.GetComponent<GuiForge>().sword;
        }
    }

    public void Load() {
        Deconvert();
        treeCount = PlayerPrefs.GetInt("treeCount");
        rockCount = PlayerPrefs.GetInt("rockCount");
        goldCount = PlayerPrefs.GetInt("goldCount");
        Vector3 thing = gameObject.transform.parent.gameObject.transform.position = new Vector3(PlayerPrefs.GetFloat("PlayerX"), PlayerPrefs.GetFloat("PlayerY"), PlayerPrefs.GetFloat("PlayerZ"));
        Debug.Log(thing.ToString());

    }
}   
