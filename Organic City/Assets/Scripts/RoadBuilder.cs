using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class RoadBuilder : MonoBehaviour
{
	public GameObject roadPrefab;
	//public GameObject roadStartPrefab;
	public static int roadCount;
	public int roadLimit;

	private Vector3 startPosition;
	private int shouldITurn;
	private Vector3 offset;
	
	// Use this for initialization
	void Start ()
	{
		GameObject roadPrefabClone = roadPrefab;
		print(roadCount);	
		if (roadCount <= roadLimit && roadCount > 0)
		{
			offset = transform.forward * 10;
			shouldITurn = Random.Range(0, 8);
			Instantiate(roadPrefabClone, gameObject.transform.position + offset, gameObject.transform.rotation);
			
			roadCount++;

			if (shouldITurn == 1)
			{
				//GameObject startPrefabClone = roadStartPrefab;
				//startPrefabClone.transform.Rotate(0, 90, 0);
				roadPrefabClone.transform.Rotate(0, 90, 0);
				Instantiate(roadPrefabClone, gameObject.transform.position + offset,
					roadPrefabClone.transform.rotation);
				roadPrefabClone.transform.Rotate(0, -90, 0);
				
				roadCount++;
			}

		}

		gameObject.name = "Road";
		gameObject.transform.SetParent(GameObject.Find("Road Control").GetComponent<Transform>());
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
