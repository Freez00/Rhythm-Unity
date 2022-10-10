using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassThrough : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject platform;
    public float random;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	private void OnCollisionEnter2D(Collision2D collision)
	{
            Debug.Log("passing through");
            //platform.layer = LayerMask.NameToLayer("Default");
    }
}
