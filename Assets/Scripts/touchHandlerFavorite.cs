using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;


public class touchHandlerFavorite : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
	private bool pointerDown;
	private float pointerDownTimer;
	public float requiredHoldTime;

	[SerializeField]
	private UnityEvent onLongClick;

	[SerializeField]
	private UnityEvent onClick;

    public void OnPointerDown(PointerEventData eventData)
    {
        pointerDown = true;
		Debug.Log("Pointer Down");
    }

    public void OnPointerUp(PointerEventData eventData)
    {
		if (pointerDownTimer <= requiredHoldTime)
		{
			Debug.Log("Click");
		}
		Reset();
    }

    // Update is called once per frame
    private void Update()
    {

		if (pointerDown)
		{
			pointerDownTimer += Time.deltaTime;
			if (pointerDownTimer >= requiredHoldTime)
			{
				if (onLongClick != null)
				{
					onLongClick.Invoke();
					Debug.Log("Long click");
					pointerDown = false;
				}
			}
		}
    }

	private void Reset() 
	{
		pointerDown = false;
		pointerDownTimer = 0;
	}
}
