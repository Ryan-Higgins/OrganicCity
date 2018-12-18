using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridBuilder : MonoBehaviour
{

	public int rowCount;
	public int colCount;
	public GameObject buildingPrefab;
	public GameObject roadPrefab;
	public GameObject buildingParent;
	public GameObject roadParent;
	
	private int cellWidth;
	private bool[,] cityGrid;
	
	//Standard Game of life builder, went with grid to cut down on calculations
	void Start ()
	{
		Build();
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.R))
		{
			Build();
		}
	}

	void Build()
	{
		cityGrid = new bool[rowCount,colCount];
		cellWidth = 10;

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
					//Spawns buildings or roads depending on true or false, random colour for buildings
					GameObject buildingClone = Instantiate(buildingPrefab,new Vector3(gameObject.transform.position.x + j * cellWidth
							, 5, gameObject.transform.position.z - i * cellWidth)
						, gameObject.transform.rotation);
					buildingClone.transform.parent = buildingParent.transform;
					buildingClone.GetComponentInChildren<MeshRenderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
				}
				else
				{
					GameObject roadClone = Instantiate(roadPrefab,new Vector3(gameObject.transform.position.x + j * cellWidth
							, 0, gameObject.transform.position.z - i * cellWidth)
						, gameObject.transform.rotation);
					roadClone.transform.parent = roadParent.transform;
				}
			}
		}
	}
}
