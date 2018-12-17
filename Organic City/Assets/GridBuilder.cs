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
	
	// Use this for initialization
	void Start ()
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
					
					GameObject buildingClone = Instantiate(buildingPrefab,new Vector3(gameObject.transform.position.x + j * cellWidth
						, 5, gameObject.transform.position.z - i * cellWidth)
						, gameObject.transform.rotation);
					buildingClone.transform.parent = buildingParent.transform;
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
	
	// Update is called once per frame
	void Update()
	{

	}
}
