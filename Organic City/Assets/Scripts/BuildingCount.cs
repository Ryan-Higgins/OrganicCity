using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using UnityEngine;

public class BuildingCount : MonoBehaviour
{

	public bool hasAddedTop;
	public bool hasAddedTopRight;
	public bool hasAddedRight;
	public bool hasAddedBotRight;
	public bool hasAddedBot;
	public bool hasAddedBotLeft;
	public bool hasAddedLeft;
	public bool hasAddedTopLeft;
	
	public List<GameObject> otherBuildings;
	
	void Start ()
	{
		hasAddedTop = false;
		hasAddedTopRight = false;
		hasAddedRight = false;
		hasAddedBotRight = false;
		hasAddedBot = false;
		hasAddedBotLeft = false;
		hasAddedLeft = false;
		hasAddedTopLeft = false;
		
		otherBuildings = new List<GameObject>();
	}
	
	void FixedUpdate ()
	{
		//Same as road counter, sends rays out in each direction checking what is there, used for the updated "Board" for Game of Life
		RaycastHit hit;

		Vector3 topRight = new Vector3(1, 0, 1);
		Vector3 botRight = new Vector3(1, 0, -1);
		Vector3 botLeft = new Vector3(-1, 0, -1);
		Vector3 topLeft = new Vector3(-1, 0, 1);
		
		Ray up = new Ray(transform.position, Vector3.forward);
		Ray upRight = new Ray(transform.position, topRight);
		Ray right = new Ray(transform.position, Vector3.right);
		Ray downRight = new Ray(transform.position, botRight);
		Ray down = new Ray(transform.position, Vector3.back);
		Ray downLeft = new Ray(transform.position, botLeft);
		Ray left = new Ray(transform.position, Vector3.left);
		Ray upLeft = new Ray(transform.position, topLeft);
		
		//Debug.DrawRay(transform.position, topRight, Color.red);

		if (Physics.Raycast(up, out hit, transform.localScale.x) && !hasAddedTop)
		{
			if (hit.transform.CompareTag("Building"))
			{
				hasAddedTop = true;
				otherBuildings.Add(hit.transform.gameObject);
			}
		} else if (Physics.Raycast(upRight, out hit, (transform.localScale.x + transform.localScale.z)/2) && !hasAddedTopRight)
		{
			if (hit.transform.CompareTag("Building"))
			{
				hasAddedTopRight = true;
				otherBuildings.Add(hit.transform.gameObject);
			}
		} else if (Physics.Raycast(right, out hit, transform.localScale.x) && !hasAddedRight)
		{
			if (hit.transform.CompareTag("Building"))
			{
				hasAddedRight = true;
				otherBuildings.Add(hit.transform.gameObject);
			}
		} else if (Physics.Raycast(downRight, out hit, (transform.localScale.x + transform.localScale.z)/2) && !hasAddedBotRight)
		{
			if (hit.transform.CompareTag("Building"))
			{
				hasAddedBotRight = true;
				otherBuildings.Add(hit.transform.gameObject);
			}
		} else if (Physics.Raycast(down, out hit, transform.localScale.x) && !hasAddedBot)
		{
			if (hit.transform.CompareTag("Building"))
			{
				hasAddedBot = true;
				otherBuildings.Add(hit.transform.gameObject);
			}
		} else if (Physics.Raycast(downLeft, out hit, (transform.localScale.x + transform.localScale.z)/2) && !hasAddedBotLeft)
		{
			if (hit.transform.CompareTag("Building"))
			{
				hasAddedBotLeft = true;
				otherBuildings.Add(hit.transform.gameObject);
			}
		} else if (Physics.Raycast(left, out hit, transform.localScale.x) && !hasAddedLeft)
		{
			if (hit.transform.CompareTag("Building"))
			{
				hasAddedLeft = true;
				otherBuildings.Add(hit.transform.gameObject);
			}
		} else if (Physics.Raycast(upLeft, out hit, (transform.localScale.x + transform.localScale.z)/2) && !hasAddedTopLeft)
		{
			if (hit.transform.CompareTag("Building"))
			{
				hasAddedTopLeft = true;
				otherBuildings.Add(hit.transform.gameObject);
			}
		}

		//buildingCounter = otherBuildings.Count;
	}
}
