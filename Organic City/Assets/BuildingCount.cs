using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using UnityEngine;

public class BuildingCount : MonoBehaviour
{

	public bool hasAdded;
	public List<GameObject> otherBuildings;
	
	// Use this for initialization
	void Start ()
	{
		hasAdded = false;
		otherBuildings = new List<GameObject>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerStay(Collider other)
	{
		if (!hasAdded)
		{
			if (other.gameObject.tag == "Building")
			{
				otherBuildings.Add(other.gameObject);
				hasAdded = true;
			}
		}
	}
}
