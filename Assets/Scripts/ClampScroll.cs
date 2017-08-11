using UnityEngine;
using System.Collections;

public class ClampScroll : MonoBehaviour {

	public float padding = 50.0f;
	public float elementSize = 300.0f;
	public float viewSize = 300.0f;

	private RectTransform rt;
	private int amountElements;
	private float contentSize;

	private void Start (){
		rt = GetComponent<RectTransform> ();
		rt.localPosition = new Vector3 (200, rt.localPosition.y, rt.localPosition.z);
	}

	private void Update(){
		amountElements = rt.childCount;
		contentSize = ((amountElements * (elementSize + padding)) - viewSize) * rt.localScale.x;
		if (rt.localPosition.x > padding)
			rt.localPosition = new Vector3 (padding, rt.localPosition.y, rt.localPosition.z);
		else if(rt.localPosition.x < -contentSize)
			rt.localPosition = new Vector3 (-contentSize, rt.localPosition.y, rt.localPosition.z);
	}
}