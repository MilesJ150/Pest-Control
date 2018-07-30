using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHitByEnemy : MonoBehaviour {
	private Vector3 spawnPos;
	private bool isHit;
	// Use this for initialization
	void Start () {
		isHit = false;
		spawnPos = this.transform.position;
	}

	public bool GetHitInfo() {
		return isHit;
	}

	public void SetHitInfo(bool hit) {
		isHit = hit;
	}
	// Update is called once per frame
	void Update () {
		if (isHit) {
			this.transform.position = spawnPos;
			SetHitInfo (false);
		}
	}
}
