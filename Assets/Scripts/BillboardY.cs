using UnityEngine;

public class BillboardY : MonoBehaviour
{
	void LateUpdate()
	{
		transform.LookAt(transform.position + Camera.main.transform.rotation * Vector3.forward);

		Vector3 eulerAngles = transform.eulerAngles;
		eulerAngles.x = 0f;
		transform.eulerAngles = eulerAngles;
	}
}
