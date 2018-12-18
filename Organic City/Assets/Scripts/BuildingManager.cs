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

	//list so i can check what rays are hitting and also in case i want to access them
	private BuildingCount myBuildingCount;


	void Start ()
	{
		myBuildingCount = GetComponent<BuildingCount>();
		roadParent = GameObject.Find("Road Parent");
		buildingParent = GameObject.Find("Building Parent");
	}
	

	void Update ()
	{
		myBuildingCount = GetComponent<BuildingCount>();
		buildingCount = myBuildingCount.otherBuildings.Count;
		//Checks the building count and behaves according to Conway's game of life rules
		if (buildingCount == 3)
		{
			int dir = Random.Range(0, 8);
			//checks a direction around the building and if anything has been added there already, spawns a building if conditions are met
			if (dir == 0 && !myBuildingCount.hasAddedTop)
			{
				GameObject buildingClone = Instantiate(buildingPrefab,new Vector3(gameObject.transform.position.x
					, 5, gameObject.transform.position.z + gameObject.transform.localScale.z)
					, gameObject.transform.rotation);
				buildingClone.transform.parent = buildingParent.transform;
			} else if (dir == 1 && !myBuildingCount.hasAddedTopRight)
			{
				GameObject buildingClone = Instantiate(buildingPrefab,new Vector3(gameObject.transform.position.x + gameObject.transform.localScale.x
					, 5, gameObject.transform.position.z + gameObject.transform.localScale.z)
					, gameObject.transform.rotation);
				buildingClone.transform.parent = buildingParent.transform;
			} else if (dir == 2 && !myBuildingCount.hasAddedRight)
			{
				GameObject buildingClone = Instantiate(buildingPrefab,new Vector3(gameObject.transform.position.x + gameObject.transform.localScale.x
					, 5, gameObject.transform.position.z)
					, gameObject.transform.rotation);
				buildingClone.transform.parent = buildingParent.transform;
			} else if (dir == 3 && !myBuildingCount.hasAddedBotRight)
			{
				GameObject buildingClone = Instantiate(buildingPrefab,new Vector3(gameObject.transform.position.x + gameObject.transform.localScale.x
					, 5, gameObject.transform.position.z - gameObject.transform.localScale.z)
					, gameObject.transform.rotation);
				buildingClone.transform.parent = buildingParent.transform;
			} else if (dir == 4 && !myBuildingCount.hasAddedBot)
			{
				GameObject buildingClone = Instantiate(buildingPrefab,new Vector3(gameObject.transform.position.x
					, 5, gameObject.transform.position.z - gameObject.transform.localScale.z)
					, gameObject.transform.rotation);
				buildingClone.transform.parent = buildingParent.transform;
			} else if (dir == 5 && !myBuildingCount.hasAddedBotLeft)
			{
				GameObject buildingClone = Instantiate(buildingPrefab,new Vector3(gameObject.transform.position.x - gameObject.transform.localScale.x
					, 5, gameObject.transform.position.z - gameObject.transform.localScale.z)
					, gameObject.transform.rotation);
				buildingClone.transform.parent = buildingParent.transform;
			} else if (dir == 6 && !myBuildingCount.hasAddedLeft)
			{
				GameObject buildingClone = Instantiate(buildingPrefab,new Vector3(gameObject.transform.position.x - gameObject.transform.localScale.x
					, 5, gameObject.transform.position.z)
					, gameObject.transform.rotation);
				buildingClone.transform.parent = buildingParent.transform;
			} else if (dir == 7 && !myBuildingCount.hasAddedTopLeft)
			{
				GameObject buildingClone = Instantiate(buildingPrefab,new Vector3(gameObject.transform.position.x - gameObject.transform.localScale.x
					, 5, gameObject.transform.position.z + gameObject.transform.localScale.z)
					, gameObject.transform.rotation);
				buildingClone.transform.parent = buildingParent.transform;
			}
		} else if (buildingCount > 4)
		{
			//Deletes the building a spawns a road in its place
			Destroy(gameObject);
			GameObject roadClone = Instantiate(roadPrefab,new Vector3(gameObject.transform.position.x
				, 0, gameObject.transform.position.z)
				, gameObject.transform.rotation);
			roadClone.transform.parent = roadParent.transform;
			
		} else if (buildingCount < 1)
		{
			//Same as above
			Destroy(gameObject);
			GameObject roadClone = Instantiate(roadPrefab,new Vector3(gameObject.transform.position.x
				, 0, gameObject.transform.position.z)
				, gameObject.transform.rotation);
			roadClone.transform.parent = roadParent.transform;
			
		}
		else if (buildingCount == 2 && transform.localScale.y <  Random.Range(10f, 61f) || buildingCount == 3 && transform.localScale.y <  Random.Range(10f, 61f))
		{
			//Grows the building to a random limit by a random factor
			gameObject.transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y + Random.Range(0f, 2f), transform.localScale.z);
			gameObject.transform.position = new Vector3(transform.position.x, 5, transform.position.z);
		}
	}

	void OnCollisionStay(Collision other)
	{
		if (other.gameObject.CompareTag("Building"))
		{
			Destroy(other.gameObject);
		}
	}
}
