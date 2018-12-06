using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridBuilder : MonoBehaviour
{

	public int rowCount;
	public int colCount;
	public GameObject buildingPrefab;
	public GameObject roadPrefab;
	
	private int cellWidth;
	
	// Use this for initialization
	void Start ()
	{
		cellWidth = 100 / rowCount;
		bool[,] cityGrid = new bool[rowCount,colCount];

		for (int i = 0; i < rowCount; i++)
		{
			for (int j = 0; j < colCount; j++)
			{
				if (Random.Range(0,2) == 1)
				{
					cityGrid[i, j] = true;
				}
				else
				{
					cityGrid[i, j] = false;
				}

				if (cityGrid[i, j])
				{
					Instantiate(buildingPrefab,new Vector3(gameObject.transform.position.x + j * cellWidth, 5, gameObject.transform.position.z - i * cellWidth), gameObject.transform.rotation);
				}
				else
				{
					Instantiate(roadPrefab,new Vector3(gameObject.transform.position.x + j * cellWidth, 0, gameObject.transform.position.z - i * cellWidth), gameObject.transform.rotation);
				}
			}
		}
		
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
