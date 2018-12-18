using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class BuildingManager : MonoBehaviour
{
	public int buildingCount;
	public GameObject roadPrefab;
	public GameObject roadParent;
	public GameObject buildingPrefab;
	public GameObject buildingParent;

	private BuildingCount myBuildingCount;

	// Use this for initialization
	void Start ()
	{
		myBuildingCount = GetComponent<BuildingCount>();
		roadParent = GameObject.Find("Road Parent");
		buildingParent = GameObject.Find("Building Parent");
	}
	
	// Update is called once per frame
	void Update ()
	{
		buildingCount = myBuildingCount.otherBuildings.Count;
		if (buildingCount == 3)
		{
			int dir = Random.Range(0, 8);
			bool hasSpawned = false;
			if (dir == 0 && !myBuildingCount.hasAddedTop)
			{
				GameObject buildingClone = Instantiate(buildingPrefab,new Vector3(gameObject.transform.position.x
					, 5, gameObject.transform.position.z + gameObject.transform.localScale.z)
					, gameObject.transform.rotation);
				buildingClone.transform.parent = buildingParent.transform;
				hasSpawned = true;
			} else if (dir == 1 && !myBuildingCount.hasAddedTopRight)
			{
				GameObject buildingClone = Instantiate(buildingPrefab,new Vector3(gameObject.transform.position.x + gameObject.transform.localScale.x
					, 5, gameObject.transform.position.z + gameObject.transform.localScale.z)
					, gameObject.transform.rotation);
				buildingClone.transform.parent = buildingParent.transform;
				hasSpawned = true;
			} else if (dir == 2 && !myBuildingCount.hasAddedRight)
			{
				GameObject buildingClone = Instantiate(buildingPrefab,new Vector3(gameObject.transform.position.x + gameObject.transform.localScale.x
					, 5, gameObject.transform.position.z)
					, gameObject.transform.rotation);
				buildingClone.transform.parent = buildingParent.transform;
				hasSpawned = true;
			} else if (dir == 3 && !myBuildingCount.hasAddedBotRight)
			{
				GameObject buildingClone = Instantiate(buildingPrefab,new Vector3(gameObject.transform.position.x + gameObject.transform.localScale.x
					, 5, gameObject.transform.position.z - gameObject.transform.localScale.z)
					, gameObject.transform.rotation);
				buildingClone.transform.parent = buildingParent.transform;
				hasSpawned = true;
			} else if (dir == 4 && !myBuildingCount.hasAddedBot)
			{
				GameObject buildingClone = Instantiate(buildingPrefab,new Vector3(gameObject.transform.position.x
					, 5, gameObject.transform.position.z - gameObject.transform.localScale.z)
					, gameObject.transform.rotation);
				buildingClone.transform.parent = buildingParent.transform;
				hasSpawned = true;
			} else if (dir == 5 && !myBuildingCount.hasAddedBotLeft)
			{
				GameObject buildingClone = Instantiate(buildingPrefab,new Vector3(gameObject.transform.position.x - gameObject.transform.localScale.x
					, 5, gameObject.transform.position.z - gameObject.transform.localScale.z)
					, gameObject.transform.rotation);
				buildingClone.transform.parent = buildingParent.transform;
				hasSpawned = true;
			} else if (dir == 6 && !myBuildingCount.hasAddedLeft)
			{
				GameObject buildingClone = Instantiate(buildingPrefab,new Vector3(gameObject.transform.position.x - gameObject.transform.localScale.x
					, 5, gameObject.transform.position.z)
					, gameObject.transform.rotation);
				buildingClone.transform.parent = buildingParent.transform;
				hasSpawned = true;
			} else if (dir == 7 && !myBuildingCount.hasAddedTopLeft)
			{
				GameObject buildingClone = Instantiate(buildingPrefab,new Vector3(gameObject.transform.position.x - gameObject.transform.localScale.x
					, 5, gameObject.transform.position.z + gameObject.transform.localScale.z)
					, gameObject.transform.rotation);
				buildingClone.transform.parent = buildingParent.transform;
				hasSpawned = true;
			}
		} else if (buildingCount > 4)
		{
			Destroy(gameObject);
			GameObject roadClone = Instantiate(roadPrefab,new Vector3(gameObject.transform.position.x
				, 0, gameObject.transform.position.z)
				, gameObject.transform.rotation);
			roadClone.transform.parent = roadParent.transform;
			
		} else if (buildingCount < 1)
		{
			Destroy(gameObject);
			GameObject roadClone = Instantiate(roadPrefab,new Vector3(gameObject.transform.position.x
				, 0, gameObject.transform.position.z)
				, gameObject.transform.rotation);
			roadClone.transform.parent = roadParent.transform;
			
		}
		else if (buildingCount == 2 && transform.localScale.y < 50 || buildingCount == 3 && transform.localScale.y < 50)
		{
			gameObject.transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y + ((float) Random.Range(0,3)), transform.localScale.z);
		}
	}
}
