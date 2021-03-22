using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class a : MonoBehaviour
{
	[SerializeField]
	private float speed = 5.0f;

	private GameObject player;
	private Animator animator;
	private void Awake()
    {
		player = GameObject.FindWithTag("Player");
		animator = this.GetComponent<Animator>();
	}
    void Update()
    {
		
		LookPlayer();

	}
	void LookPlayer()
	{

		if (player != null)
		{
			Vector3 targetPosition = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);
			transform.LookAt(targetPosition);
			//animator.SetTrigger("_turn");
		}
	}

}
