﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class bullet : NetworkTransform
{
	[SyncVar]
	public int playerID;
	[SyncVar]
	public bool bBoss;
	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

	}

	private void OnTriggerEnter(Collider other)
	{
		Debug.Log("OnCollisionEnter");
		GameObject hit = other.gameObject;
		Debug.Log("collision " + other.gameObject.name);
		Health hp = hit.GetComponent<Health>();
		if (hp != null)
		{
			if (bBoss == true)
			{
				hp.TakeDamage(20);
			}
			else
			{
				if (GameSetting.bFriendlyDamage)
				{
					hp.TakeDamage(10);
				}
				else
				{
					if (hit.GetComponent<PlayerController>().bBoss == true)
						hp.TakeDamage(10);
				}
			}
		}
		else
		{

		}

		Destroy(gameObject);
	}
}
