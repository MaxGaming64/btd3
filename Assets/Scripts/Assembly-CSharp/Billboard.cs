using System;
using UnityEngine;

// Token: 0x020000B3 RID: 179
public class Billboard : MonoBehaviour
{
	// Token: 0x06000928 RID: 2344 RVA: 0x00020BE2 File Offset: 0x0001EFE2
	private void LateUpdate()
	{
		base.transform.LookAt(base.transform.position + Camera.main.transform.rotation * Vector3.forward);
	}
}
