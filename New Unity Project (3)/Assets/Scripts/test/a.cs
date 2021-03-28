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
		
		//LookPlayer();

	}

}
