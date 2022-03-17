using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Create_inventary : MonoBehaviour
{
    [SerializeField] private GameObject item;
    private List<GameObject> inventary;
    void Start()
    {
        inventary = new List<GameObject>();
        for(int x = 0; x < 4; x++)
        {
            for(int y = 0; y < 6; y++)
            {
                GameObject instance = Instantiate(item, gameObject.transform);
                instance.transform.position += new Vector3(49 * x, -49 * y);
                inventary.Add(instance);

                GameObject parent = gameObject.transform.parent.gameObject;
                instance.GetComponent<Stat_Armor>().set_ui(parent);
            }
        }
    }
}
