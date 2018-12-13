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
					Instantiate(buildingPrefab,new Vector3(gameObject.transform.position.x + j * cellWidth
						, 5, gameObject.transform.position.z - i * cellWidth)
						, gameObject.transform.rotation);
				}
				else
				{
					Instantiate(roadPrefab,new Vector3(gameObject.transform.position.x + j * cellWidth
						, 0, gameObject.transform.position.z - i * cellWidth)
						, gameObject.transform.rotation);
				}
			}
		}
		
		
	}
	
	// Update is called once per frame
	void Update () {

		for (int i = 0; i < rowCount; i++)
		{
			for (int j = 0; j < colCount; j++)
			{
				int count = CountAround(i, j);
				
				if (cityGrid[i,j])
				{
					if (count == 2 || count == 3)
					{
						
					}
					else
					{
						GameObject check = new GameObject();
						check.name = "Check";
						check.transform.position = new Vector3(gameObject.transform.position.x + j * cellWidth
							, 5, gameObject.transform.position.z - i * cellWidth);
						check.AddComponent<BoxCollider>();
						check.GetComponent<BoxCollider>().isTrigger = true;
					}
				}
				else
				{
					if (count == 3)
					{
						
					}
					else
					{
						
					}
				}
				print(count);
			}
		}
		
	}
	
	int CountAround(int row, int col)
	{
		int count = 0;
  
		if (row > 0 && col > 0 && cityGrid[row-1,col-1])
		{
			count ++;
		}
		if (row > 0 && cityGrid[row-1,col])
		{
			count ++;
		}
		if (row > 0 && col < colCount - 1 && cityGrid[row-1,col + 1])
		{
			count ++;
		}
  
		if (col > 0 && cityGrid[row,col - 1])
		{
			count ++;
		}
		if (col < colCount - 1 && cityGrid[row,col + 1])
		{
			count ++;    
		}
		if (col > 0 && row < rowCount - 1 && cityGrid[row + 1,col -1])
		{
			count ++;
		}
		if (row < rowCount - 1 && cityGrid[row + 1,col])
		{
			count ++;
		}
		if (col < colCount - 1 && row < rowCount - 1 && cityGrid[row + 1,col + 1])
		{
			count ++;
		}
  
		return count;
	}
}
