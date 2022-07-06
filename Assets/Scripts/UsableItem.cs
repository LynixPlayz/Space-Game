using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsableItem : MonoBehaviour
{
    public bool IsEquipped;
    public GameObject EquippedItem;
    public GameObject Player;
    public GameObject ForgeGui;
    public GameObject script;
    public List<string> obtainedItems = new List<string>();
    private Quaternion first;

    void Start(){}

    void Update()
    {
        if (IsEquipped == true){
            if (obtainedItems.Contains("Pick")){
                first = Player.transform.rotation;
                Player.transform.rotation = Quaternion.identity;
                Transform obj = Instantiate(EquippedItem, Player.transform.position + new Vector3(-0.46f, 0.34f, 0.6f), Player.transform.rotation, Player.transform).transform;
                obj.Rotate(0.0f, Player.transform.rotation.y + 90.0f, 0.0f, Space.Self);
                Player.transform.rotation = first;
                IsEquipped = false;
                obtainedItems.Add("Pick");
            }
            else {
                first = Player.transform.rotation;
                Player.transform.rotation = Quaternion.identity;
                Instantiate(EquippedItem, Player.transform.position + new Vector3(-0.32f, 0.34f, -0.6f), Quaternion.Euler(0, 0, 0), Player.transform);
                Player.transform.rotation = first;
                IsEquipped = false;
                obtainedItems.Add("Sword");
            }
        }
        if (obtainedItems.Contains("Sword") && obtainedItems.Contains("Pick")){
            script.GetComponent<Animations>().advancement3 = true;
            obtainedItems.Clear();
        }
    }
}
