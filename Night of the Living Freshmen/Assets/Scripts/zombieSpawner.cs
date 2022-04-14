using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombieSpawner : MonoBehaviour
{
    public GameObject prefab;
    public Transform parent;
    private int zedCount = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(zedCount < 10) {
            Instantiate(prefab, new Vector3(-20.0F, 0, 12.50F), Quaternion.identity, parent );
        }
        zedCount = parent.childCount;
    }
}
