using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionCheck : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject platform;
    public bool isOnPassThrough;
    public GameObject bump;
    public Collider2D bumpCollider;  

    void Start()
    {
        bumpCollider = bump.GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
		if (Input.GetButton("Down") && isOnPassThrough) 
		{
            //Debug.Log("Going down");
            platform.layer = LayerMask.NameToLayer("Default");
            isOnPassThrough = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.GetComponent<Collider2D>().tag == "Passthrough" && collider.transform.position.y + collider.transform.localScale.y/2 > transform.position.y - transform.localScale.y/2)
        {
            //Debug.Log("passing through");
            platform.layer = LayerMask.NameToLayer("Default");

        }
        if (collider.GetComponent<Collider2D>().tag == "Passthrough" && collider.transform.position.y < transform.position.y)
		{
            isOnPassThrough = true;
        }
        if (collider.GetComponent<Collider2D>().tag == "Passthrough")
		{
            bumpCollider.enabled = false;
		}
    }
    private void OnTriggerExit2D(Collider2D collider)
	{
        if (collider.GetComponent<Collider2D>().tag == "Passthrough")
        {
            //Debug.Log("leaving");
            platform.layer = LayerMask.NameToLayer("Ground Layer");
            isOnPassThrough = false;
        }
        bumpCollider.enabled = true;

    }
}
