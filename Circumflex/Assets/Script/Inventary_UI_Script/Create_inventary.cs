using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Create_inventary : MonoBehaviour
{
    [SerializeField] private GameObject item;
    [SerializeField] private GameObject list_inventary;
    
    void Awake()
    {
        for(int x = 0; x < 4; x++)
        {
            for(int y = 0; y < 6; y++)
            {
                GameObject instance = Instantiate(item, gameObject.transform);
                instance.transform.position += new Vector3(35 * x, -35 * y);
                list_inventary.GetComponent<List_Inventary>().inventary.Add(instance);

                GameObject parent = gameObject.transform.parent.gameObject;
                instance.GetComponent<Stat_Armor>().set_ui(parent);
            }
        }
    }
}
