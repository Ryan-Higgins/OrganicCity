using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class RoadBuilder : MonoBehaviour
{
	public GameObject roadPrefab;
	//public GameObject plane;

	private Vector3 startPosition;
	private int shouldITurn;
	
	// Use this for initialization
	void Start () {
	
		
		startPosition = new Vector3(-50,0.1f,-50);
		Quaternion roadTurn = new Quaternion(roadPrefab.transform.rotation.x, roadPrefab.transform.rotation.y + 90, roadPrefab.transform.rotation.z, roadPrefab.transform.rotation.w);
		
		for(int i = 0; i <= 90; i +=10)
		{
			Vector3 offset = new Vector3(0,0,i);
			//print(i);
			GameObject roadPrefabClone = roadPrefab;
			Instantiate(roadPrefabClone, startPosition + offset, roadPrefabClone.transform.rotation);
			shouldITurn = Random.Range(0, 3);
			print(shouldITurn);
			if (shouldITurn == 1)
			{
				roadPrefabClone.transform.Rotate(0,90,0);
				offset = new Vector3(0,0,i + 10);
				Instantiate(roadPrefabClone, startPosition + offset, roadPrefabClone.transform.rotation);
				roadPrefabClone.transform.Rotate(0,-90,0);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
