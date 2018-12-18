using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildBuildings : MonoBehaviour
{

	public GameObject buildingPrefab;
	private GameObject buildingParent;


	void Start () {
		buildingParent = GameObject.Find("Building Parent");
	}
	

	void Update () {
		//Allows player to place buildings using mouse click
		if (Input.GetMouseButtonDown(0))
		{
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out hit))
			{
				if (hit.transform.gameObject.CompareTag("Road") || hit.transform.gameObject.CompareTag("Clone"))
				{
					GameObject buildingClone = Instantiate(buildingPrefab,new Vector3(hit.transform.position.x 
							, 5, hit.transform.position.z)
						, buildingPrefab.transform.rotation);
					buildingClone.transform.parent = buildingParent.transform;
					buildingClone.GetComponentInChildren<MeshRenderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
				} 
			}
		}
	}
}
