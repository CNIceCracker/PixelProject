﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour {

	public bool isGround = false;
	public bool canShoot = false;
	public bool canPick = false;
	public bool isDead = false;
	public Inventory inventory;

	public static PlayerController instance = null;
	public GameObject player = null;
	public Transform playerWeaponPoint = null;

	private Animator anim = null;
	//private float horizontal;

	private Rigidbody2D rg;
	
	void Awake () {
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy (gameObject);
		
		DontDestroyOnLoad (gameObject);

		if(player != null || (player = GameObject.FindGameObjectWithTag("Player")) != null){
			player.GetComponent<Hurtable>().RecoverHealth();
			Transform[] allChildren = player.GetComponentsInChildren<Transform>();
			foreach(Transform child in allChildren){
				if(child.tag == "WeaponPoint"){
					playerWeaponPoint = child;
				}
			}
			rg = player.GetComponent<Rigidbody2D>();
		}

		anim = player.GetComponent<Animator>();
	}

	void Update(){
		List<Command> commands = GetInput();
		if(commands.Count > 0){
			foreach(Command command in commands){
				command.Execute(player);
			}
		}
		if(Input.GetKeyDown(KeyCode.LeftShift)){
			player.GetComponent<CharacterMove>().moveEfficiency *= 2f;
		}
		if(Input.GetKeyUp(KeyCode.LeftShift)){
			player.GetComponent<CharacterMove>().moveEfficiency /= 2f;
		}
	}

	void FixedUpdate () {
		AnimatorSet();
		rg.WakeUp();
	}

	List<Command> GetInput(){
		List<Command> myCommand = new List<Command>();
		if(Input.GetKeyDown(KeyCode.K)){
			myCommand.Add(new JumpCommand());
		}
		if(Input.GetKey(KeyCode.J)){
			Vector3 target = new Vector3(player.transform.position.x,player.transform.position.y,0);
			if(player.transform.localScale.x > 0){
				target.x += 100f;
			}else{
				target.x -= 100f;
			}

			object[] message = new object[2];
			message[0] = target;
			message[1] = true;

			myCommand.Add(new AttackCommand(message));
		}
		if(Input.GetKeyDown(KeyCode.F)){
			myCommand.Add(new SwitchNextWeaponCommand());
		}
		if(Input.GetKey(KeyCode.A)){
			myCommand.Add(new MoveToLeftCommand());
		}
		if(Input.GetKey(KeyCode.D)){
			myCommand.Add(new MoveToRightCommand());
		}

		return myCommand;
	}

	private void AnimatorSet(){

		if(playerWeaponPoint.childCount != 0){
			anim.SetBool("HaveWeapon",true);
		}else{
			anim.SetBool("HaveWeapon",false);
		}

		if(Input.GetKey(KeyCode.A)){
			//horizontal = -1;
			player.transform.localScale = new Vector3(-1,1,1);
			anim.SetBool("IsMove",true);
		}else if(Input.GetKey(KeyCode.D)){
			//horizontal = 1;
			player.transform.localScale = new Vector3(1,1,1);
			anim.SetBool("IsMove",true);
		}else{
			//horizontal = 0;
			anim.SetBool("IsMove",false);
		}

		anim.speed = player.GetComponent<CharacterMove>().moveEfficiency;

	}


	/*
	public void pickUpItem(string itemName, string type){
		switch(type){
		case "Weapon":
			weapons.Add(itemName);
			switchWeapon(1);
			break;
		case "Buff":
			switch(itemName){
			case "SpeedRunner":
				instance.playerSpeed *= 1.5f;
				break;
			}
			break;
		}
	}*/
	/*
	public void switchWeapon(int way){
		UnloadWeapon(weapons[weaponIndex]);

		weaponIndex += way;
		if(weaponIndex >= weapons.Count) weaponIndex = 0;
		else if(weaponIndex < 0) weaponIndex = weapons.Count - 1;

		LoadWeapon(weapons[weaponIndex]);
	}

	private void LoadWeapon(string weaponName){
		switch(weaponName){
		case "MiniGun":
			GameObject miniGun = Instantiate(Resources.Load("Item/GameObject/MiniGun")) as GameObject;
			miniGun.transform.SetParent(PlayerController.instance.playerFirePoint);
			miniGun.transform.localPosition = new Vector3(-0.6f,0.3f,0f);
			miniGun.transform.localScale = new Vector3(1.2f,1.5f,1f);
			instance.playerAttack -= 5;
			instance.playerAttackRate += 3;
			currentWeapon = miniGun;
			break;
		case "None":
			currentWeapon = null;
			break;
		}
	}

	private void UnloadWeapon(string weaponName){
		switch(weaponName){
		case "MiniGun":
			Destroy(currentWeapon);
			instance.playerAttack += 5;
			instance.playerAttackRate -= 3;
			currentWeapon = null;
			break;
		case "None":
			break;
		}
	}*/

}
