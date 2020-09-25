using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class WinLine : MonoBehaviour
{

    private Collider2D coll;
    
    void Start()
    {
        coll = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
