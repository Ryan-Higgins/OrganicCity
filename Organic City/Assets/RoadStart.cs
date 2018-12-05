using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadStart : MonoBehaviour
{

	public GameObject roadPrefab;

	// Use this for initialization
	void Start ()
	{
		GameObject roadPrefabClone = roadPrefab;
		if (RoadBuilder.roadCount == 0)
		{
			int rotationDirection = Random.Range(0, 3);
			if (rotationDirection == 0)
			{
				gameObject.transform.Rotate(0,0,0);
			} else if (rotationDirection == 1)
			{
				gameObject.transform.Rotate(0,90,0);
			} else if (rotationDirection == 2)
			{
				gameObject.transform.Rotate(0,-90,0);
			} else if (rotationDirection == 3)
			{
				gameObject.transform.Rotate(0,180,0);
			}
		
			Instantiate(roadPrefabClone, new Vector3(Random.Range(-50, 50), 0.1f, Random.Range(-50, 50)),
				gameObject.transform.rotation);
			
			RoadBuilder.roadCount++;
			
		} 
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
