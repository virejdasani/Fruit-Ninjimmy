using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Katana : MonoBehaviour {

	public GameObject rip;
	public GameObject ripBG;
	public GameObject respawn;

	public GameObject bladeTrailPrefab;
    public float minCuttingVelocity = .001f;

	bool isCutting = false;

	Vector2 previousPosition;

	GameObject currentBladeTrail;

	Rigidbody2D rb;
	Camera cam;
	CircleCollider2D circleCollider;

	void Start ()
	{
		cam = Camera.main;
		rb = GetComponent<Rigidbody2D>();
		circleCollider = GetComponent<CircleCollider2D>();
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0))
		{
			StartCutting();
		}
		else if (Input.GetMouseButtonUp(0))
		{
			StopCutting();
		}

		if (isCutting)
		{
			UpdateCut();
		}

	}

	void UpdateCut ()
	{
		Vector2 newPosition = cam.ScreenToWorldPoint(Input.mousePosition);
        rb.position = newPosition;

		float velocity = (newPosition - previousPosition).magnitude * Time.deltaTime;

		if (velocity > minCuttingVelocity)
		{
			circleCollider.enabled = true;
		}

		else
		{
			circleCollider.enabled = false;
		}

		previousPosition = newPosition;
	}

	void StartCutting ()
	{
		isCutting = true;
		currentBladeTrail = Instantiate(bladeTrailPrefab, transform);
		previousPosition = cam.ScreenToWorldPoint(Input.mousePosition);
		circleCollider.enabled = false;
	}

	void StopCutting ()
	{
		isCutting = false;
		currentBladeTrail.transform.SetParent(null);
		Destroy(currentBladeTrail, 2f);
		circleCollider.enabled = false;
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Milkman")
		{
			rip.gameObject.SetActive(true);
			ripBG.gameObject.SetActive(true);
			respawn.gameObject.SetActive(true);
		}
	}


}
