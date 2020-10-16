using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScripts : MonoBehaviour
{

    private Animator _animator;
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "player") {
            _animator.SetBool("open", true);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
