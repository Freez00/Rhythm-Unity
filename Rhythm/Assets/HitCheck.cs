using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TarodevController;

public class HitCheck : MonoBehaviour
{
    public PlayerController controller;
    public DashController dashController;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	private void OnTriggerEnter2D(Collider2D collision)
	{
        if (collision.GetComponent<Collider2D>().tag == "Player")
		{
            controller.GiveJump();
            dashController.SetDash(true);
            Debug.Log("HIT");
            this.gameObject.SetActive(false);
        }
	}
}
