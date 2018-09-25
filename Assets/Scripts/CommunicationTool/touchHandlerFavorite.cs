using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;


/**
 * handles interaction with favorite buttons
 */
public class touchHandlerFavorite : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
	private bool pointerDown;
	private float pointerDownTimer;
	public float requiredHoldTime; /**< time required to hold down favorite button to set new favorite */

	[SerializeField]
	private UnityEvent onLongClick;

	[SerializeField]
	private UnityEvent onClick;

	/**
	 * sets clicked toggle to true
	 */
    public void OnPointerDown(PointerEventData eventData)
    {
        pointerDown = true;
    }

	/**
	 * checks if button is held down, if not invokes short click method
	 */
    public void OnPointerUp(PointerEventData eventData)
    {
		if (pointerDownTimer <= requiredHoldTime)
		{
			onClick.Invoke();
		}
		Reset();
    }

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
