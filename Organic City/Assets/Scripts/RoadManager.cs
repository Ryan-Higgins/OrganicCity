using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;

public class RoadManager : MonoBehaviour
{

	//segments that can be spawned as needed, ended up only using straight and corner
	public GameObject straightRoad;
	public GameObject cornerRoad;
	public GameObject threeRoad;
	public GameObject crossRoad;

	//collection of bools both checking if it has counted a direction and if its road or building
	private bool topDone;
	private bool rightDone;
	private bool botDone;
	private bool leftDone;
	private bool topChecked;
	private bool rightChecked;
	private bool botChecked;
	private bool leftChecked;

	//parent for neatness
	private GameObject roadParent;
	//used a list to better keep track of where the rays were hitting and in case I wanted to access the things they are hitting
	private List<GameObject> roads;

	public int count;


	void Start ()
	{
		
		roadParent = GameObject.Find("Road Parent");

		count = 0;
		topDone = false;
		rightDone = false;
		botDone = false;
		leftDone = false;
		topChecked = false;
		rightChecked = false;
		botChecked = false;
		leftChecked = false;
		
		roads = new List<GameObject>();
		
	}
	

	void Count ()
	{
			Debug.DrawRay(transform.position, Vector3.forward);
		RaycastHit hit;

		Ray up = new Ray(transform.position, Vector3.forward);
		Ray right = new Ray(transform.position, Vector3.right);
		Ray down = new Ray(transform.position, Vector3.back);
		Ray left = new Ray(transform.position, Vector3.left);

		//Sends raycasts out all around the roads to check if there are roads beside it
		if (Physics.Raycast(up, out hit) && !topDone)
		{
			if (hit.transform.gameObject.CompareTag("Road"))
			{
				//count++;
				roads.Add(hit.transform.gameObject);
				topDone = true;
				topChecked = true;
			}
			else if (hit.transform.gameObject.CompareTag("Building"))
			{
				topDone = true;
			}
		}
		else if (Physics.Raycast(right, out hit) && !rightDone)
		{
			if (hit.transform.gameObject.CompareTag("Road"))
			{
				//count++;
				roads.Add(hit.transform.gameObject);
				rightDone = true;
				rightChecked = true;
			}
			else if (hit.transform.gameObject.CompareTag("Building"))
			{
				rightDone = true;
			}
		}
		else if (Physics.Raycast(down, out hit) && !botDone)
		{
			if (hit.transform.gameObject.CompareTag("Road"))
			{
				//count++;
				roads.Add(hit.transform.gameObject);
				botDone = true;
				botChecked = true;
			}
			else if (hit.transform.gameObject.CompareTag("Building"))
			{
				botDone = true;
			}
		}
		else if (Physics.Raycast(left, out hit) && !leftDone)
		{
			if (hit.transform.gameObject.CompareTag("Road"))
			{
				//count++;
				roads.Add(hit.transform.gameObject);
				leftDone = true;
				leftChecked = true;
			}
			else if (hit.transform.gameObject.CompareTag("Building"))
			{
				leftDone = true;
			}
		}
			
		}

	void Build()
	{
		count = roads.Count;
		//had 3 and 4 road segments but didn't behave how i wanted it to, can disable this if want to see how it looks, I don't like it personally
		/*if (count == 4)
			{
				if (topChecked && rightChecked && botChecked && leftChecked && !gameObject.CompareTag("Clone"))
				{
					GameObject crossClone =
						Instantiate(crossRoad, gameObject.transform.position, gameObject.transform.rotation);
					crossClone.transform.SetParent(roadParent.transform);
					crossClone.tag = "Clone";
					hasSpawned = true;
					Destroy(gameObject);
				}
			}*/
			/*else if (count == 3)
			{
				if (topChecked && rightChecked && botChecked && !gameObject.CompareTag("Clone"))
				{
					GameObject threeClone =
						Instantiate(threeRoad, gameObject.transform.position, gameObject.transform.rotation);
					threeClone.transform.SetParent(roadParent.transform);
					threeClone.tag = "Clone";
					Destroy(gameObject);
				}
				else if (rightChecked && botChecked && leftChecked && !gameObject.CompareTag("Clone"))
				{
					GameObject threeClone =
						Instantiate(threeRoad, gameObject.transform.position, gameObject.transform.rotation);
					threeClone.transform.SetParent(roadParent.transform);
					threeClone.transform.Rotate(Vector3.up, 90);
					threeClone.tag = "Clone";
					Destroy(gameObject);
				}
				else if (botChecked && leftChecked && topChecked && !gameObject.CompareTag("Clone"))
				{
					GameObject threeClone =
						Instantiate(threeRoad, gameObject.transform.position, gameObject.transform.rotation);
					threeClone.transform.SetParent(roadParent.transform);
					threeClone.transform.Rotate(Vector3.up, 180);
					threeClone.tag = "Clone";
					Destroy(gameObject);
				}
				else if (leftChecked && topChecked && rightChecked && !gameObject.CompareTag("Clone"))
				{
					GameObject threeClone =
						Instantiate(threeRoad, gameObject.transform.position, gameObject.transform.rotation);
					threeClone.transform.SetParent(roadParent.transform);
					threeClone.transform.Rotate(Vector3.up, -90);
					threeClone.tag = "Clone";
					Destroy(gameObject);
				}
			}*/
			/*else*/ if (count == 2)
			{
				//checks where the other roads are and either turns, adds a corner or stretches to reach them and connect
				if (topChecked && botChecked && !gameObject.CompareTag("Clone"))
				{
					GameObject straightClone = Instantiate(straightRoad, gameObject.transform.position,
						gameObject.transform.rotation);
					straightClone.transform.SetParent(roadParent.transform);
					straightClone.tag = "Clone";
					Destroy(gameObject);
				}
				else if (leftChecked && rightChecked && !gameObject.CompareTag("Clone"))
				{
					GameObject straightClone = Instantiate(straightRoad, gameObject.transform.position,
						gameObject.transform.rotation);
					straightClone.transform.Rotate(Vector3.up, 90);
					straightClone.transform.SetParent(roadParent.transform);
					straightClone.transform.localScale = new Vector3(straightClone.transform.localScale.x,
						straightClone.transform.localScale.y, straightClone.transform.localScale.z + 1);
					straightClone.tag = "Clone";
					Destroy(gameObject);
				}
				else if (topChecked && rightChecked && !gameObject.CompareTag("Clone"))
				{
					GameObject cornerClone = Instantiate(cornerRoad, gameObject.transform.position,
						gameObject.transform.rotation);
					cornerClone.transform.SetParent(roadParent.transform);
					cornerClone.tag = "Clone";
					Destroy(gameObject);
				}
				else if (rightChecked && botChecked && !gameObject.CompareTag("Clone"))
				{
					GameObject cornerClone = Instantiate(cornerRoad, gameObject.transform.position,
						gameObject.transform.rotation);
					cornerClone.transform.SetParent(roadParent.transform);
					cornerClone.transform.Rotate(Vector3.up, 90);
					cornerClone.tag = "Clone";
					Destroy(gameObject);
				}
				else if (botChecked && leftChecked && !gameObject.CompareTag("Clone"))
				{
					GameObject cornerClone = Instantiate(cornerRoad, gameObject.transform.position,
						gameObject.transform.rotation);
					cornerClone.transform.SetParent(roadParent.transform);
					cornerClone.transform.Rotate(Vector3.up, 180);
					cornerClone.tag = "Clone";
					Destroy(gameObject);
				}
				else if (leftChecked && topChecked && !gameObject.CompareTag("Clone"))
				{
					GameObject cornerClone = Instantiate(cornerRoad, gameObject.transform.position,
						gameObject.transform.rotation);
					cornerClone.transform.SetParent(roadParent.transform);
					cornerClone.transform.Rotate(Vector3.up, -90);
					cornerClone.tag = "Clone";
					Destroy(gameObject);
				}
			}
	}

	void LateUpdate()
	{
		StartCoroutine("Delay");
	}

	void Update()
	{
		
	}

	void OnCollisionStay(Collision other)
	{
		//checks if building is spawned on top and deletes the road
		if (other.transform.gameObject.CompareTag("Building"))
		{
			Destroy(gameObject);
		}
	}

	IEnumerator Delay()
	{
		//delay waiting for the buildings to finish to avoid counting issues
		yield return new WaitForSeconds(1f);
		Count();
		yield return new WaitForSeconds(1f);
		Build();
	}
 }
