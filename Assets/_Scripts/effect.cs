using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class effect : MonoBehaviour
{
	[SerializeField] private GameObject effectPrefab;

	public GameObject targetObj;
	public float targetDis;

	void TargetDistance()
	{
		GameObject[] targets = GameObject.FindGameObjectsWithTag("Enemy");
		foreach (GameObject target in targets)
		{
			float dist = Vector3.Distance(target.transform.position, transform.position);
			if (targetDis > dist)
			{
				targetObj = target;
				targetDis = dist;
			}
		}

	}

	public void Effect()
    {
        targetDis = float.MaxValue;
        TargetDistance();

        var effectInstance = Instantiate<GameObject>(effectPrefab, transform.position + transform.forward, Quaternion.identity);
        effectInstance.transform.LookAt(targetObj.transform);

    }
}
