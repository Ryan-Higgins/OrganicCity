using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingGenerator : MonoBehaviour
{
	public int buildingLimit;
	public GameObject buildingPrefab;

	private int buildingCount;

	// Use this for initialization
	void Start () {
		for (int i = 0; i < buildingLimit; i++)
		{
			GameObject buildingPrefabClone = buildingPrefab;
			Instantiate(buildingPrefabClone, new Vector3((int) Random.Range(-50, 50), 5, (int) Random.Range(50, -50)),
				buildingPrefabClone.transform.rotation);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
