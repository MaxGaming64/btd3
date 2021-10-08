﻿using System;
using UnityEngine;

// Token: 0x020000B7 RID: 183
public class ClickableTest : MonoBehaviour
{
	// Token: 0x06000934 RID: 2356 RVA: 0x00021055 File Offset: 0x0001F455
	private void Start()
	{
	}

	// Token: 0x06000935 RID: 2357 RVA: 0x00021068 File Offset: 0x0001F468
	private void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			Ray ray = Camera.main.ScreenPointToRay(new Vector3((float)(Screen.width / 2), (float)(Screen.height / 2), 0f));
			RaycastHit raycastHit;
			if (Physics.Raycast(ray, out raycastHit) && raycastHit.transform.name == "MathNotebook")
			{
				base.gameObject.SetActive(false);
			}
		}
	}
}
