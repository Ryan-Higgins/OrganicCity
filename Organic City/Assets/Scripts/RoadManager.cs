using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;

public class RoadManager : MonoBehaviour
{

	public GameObject straightRoad;
	public GameObject cornerRoad;
	public GameObject threeRoad;
	public GameObject crossRoad;

	private bool topDone;
	private bool rightDone;
	private bool botDone;
	private bool leftDone;

	private GameObject roadParent;

	public int count;

	// Use this for initialization
	void Start ()
	{
		count = 0;
		topDone = false;
		rightDone = false;
		botDone = false;
		leftDone = false;
		
		roadParent = GameObject.Find("Road Parent");
	}
	
	// Update is called once per frame
	void Update ()
	{
		Debug.DrawRay(transform.position, Vector3.forward);
		RaycastHit hit;
		
		Ray up = new Ray(transform.position, Vector3.forward);
		Ray right = new Ray(transform.position, Vector3.right);
		Ray down = new Ray(transform.position, Vector3.back);
		Ray left = new Ray(transform.position, Vector3.left);

		if (Physics.Raycast(up, out hit) && !topDone)
		{
			if (hit.transform.gameObject.CompareTag("Road"))
			{
				count++;
				topDone = true;
			} else if (hit.transform.gameObject.CompareTag("Building"))
			{
				topDone = true;
			}
		} else if (Physics.Raycast(right, out hit) && !rightDone)
		{
			if (hit.transform.gameObject.CompareTag("Road"))
			{
				count++;
				rightDone = true;
			} else if (hit.transform.gameObject.CompareTag("Building"))
			{
				rightDone = true;
			}
		} else if (Physics.Raycast(down, out hit) && !botDone)
		{
			if (hit.transform.gameObject.CompareTag("Road"))
			{
				count++;
				botDone = true;
			} else if (hit.transform.gameObject.CompareTag("Building"))
			{
				botDone = true;
			}
		} else if (Physics.Raycast(left, out hit) && !leftDone)
		{
			if (hit.transform.gameObject.CompareTag("Road"))
			{
				count++;
				leftDone = true;
			} else if (hit.transform.gameObject.CompareTag("Building"))
			{
				leftDone = true;
			}
		}

		if (count == 4)
		{
			GameObject crossClone = Instantiate(crossRoad, gameObject.transform.position, gameObject.transform.rotation);
			crossClone.transform.SetParent(roadParent.transform);
			Destroy(gameObject);
		} else if (count == 3)
		{
			
		}
		else if (count == 2)
		{
			if (topDone && botDone)
			{
				GameObject straightClone = Instantiate(straightRoad, gameObject.transform.position,
					gameObject.transform.rotation);
				straightClone.transform.SetParent(roadParent.transform);
				Destroy(gameObject);
			} else if (leftDone && rightDone)
			{
				GameObject straightClone = Instantiate(straightRoad, gameObject.transform.position,
					gameObject.transform.rotation);
				straightClone.transform.Rotate(Vector3.up, 90);
				straightClone.transform.SetParent(roadParent.transform);
				Destroy(gameObject);
			} else if (topDone && rightDone)
			{
				GameObject cornerClone = Instantiate(cornerRoad, gameObject.transform.position,
					gameObject.transform.rotation);
				cornerClone.transform.SetParent(roadParent.transform);
				Destroy(gameObject);
			} else if (rightDone && botDone)
			{
				GameObject cornerClone = Instantiate(cornerRoad, gameObject.transform.position,
					gameObject.transform.rotation);
				cornerClone.transform.SetParent(roadParent.transform);
				cornerClone.transform.Rotate(Vector3.up, 90);
				Destroy(gameObject);
			} else if (botDone && leftDone)
			{
				GameObject cornerClone = Instantiate(cornerRoad, gameObject.transform.position,
					gameObject.transform.rotation);
				cornerClone.transform.SetParent(roadParent.transform);
				cornerClone.transform.Rotate(Vector3.up, 180);
				Destroy(gameObject);
			} else if (leftDone && topDone)
			{
				GameObject cornerClone = Instantiate(cornerRoad, gameObject.transform.position,
					gameObject.transform.rotation);
				cornerClone.transform.SetParent(roadParent.transform);
				cornerClone.transform.Rotate(Vector3.up, -90);
				Destroy(gameObject);
			}
		}
	}

	void OnCollisionStay(Collision other)
	{
		if (other.transform.gameObject.CompareTag("Building"))
		{
			Destroy(gameObject);
		}
	}
}
