using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Position : MonoBehaviour
{
    
    public Vector3 pos;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(gameObject.tag);
        pos = transform.position;
        Debug.Log(" pos is " + pos);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
