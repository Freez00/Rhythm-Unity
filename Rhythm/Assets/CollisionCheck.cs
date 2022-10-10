using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionCheck : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject platform;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.GetComponent<Collider2D>().tag == "Passthrough" && collider.transform.position.y - collider.transform.localScale.y/2 > transform.position.y)
        {
            Debug.Log("passing through");
            platform.layer = LayerMask.NameToLayer("Default");
        }
    }
	private void OnTriggerExit2D(Collider2D collider)
	{
        if (collider.GetComponent<Collider2D>().tag == "Passthrough")
        {
            Debug.Log("leaving");
            platform.layer = LayerMask.NameToLayer("Ground Layer");
        }
    }
}
