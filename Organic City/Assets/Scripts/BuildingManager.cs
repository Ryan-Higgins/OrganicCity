using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingManager : MonoBehaviour
{
	public int buildingCount;
	
	private BuildingCount myBuildingCount;

	// Use this for initialization
	void Start ()
	{
		myBuildingCount = GetComponent<BuildingCount>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		buildingCount = myBuildingCount.otherBuildings.Count;
		if (buildingCount == 3)
		{
			
		} else if (buildingCount > 3)
		{
			transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y + 2, transform.localScale.z);
		}
	}
}
