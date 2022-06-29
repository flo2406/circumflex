using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow_AI : MonoBehaviour
{
    [SerializeField] private Transform ennemi;

    // Update is called once per frame
    void Update()
    {
        if (ennemi == null)
            Destroy(gameObject);

        else
        {
            Vector3 pos = new Vector3(ennemi.position.x, ennemi.position.y + 4, ennemi.position.z);
            gameObject.transform.position = pos;
        }
    }
}
