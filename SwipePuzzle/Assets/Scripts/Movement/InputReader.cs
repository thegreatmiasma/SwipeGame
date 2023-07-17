
using System;
using System.Xml.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputReader : MonoBehaviour
{

	public static InputReader instance;
	public delegate void Swipe(float direction);
	public event Swipe horizontalSwipe;

	public event Swipe verticalSwipe;
	[SerializeField] private InputAction pressVertical, keyboardVertical;
	[SerializeField] private InputAction position;
	[SerializeField] private InputAction press;
	[SerializeField] private InputAction  pressHorizontal, keyboardHorizontal;
	[SerializeField] InputAction SpaceEnter;
	public static event Action<float> swipeMovement;
    public static event Action enterPressAction;
    [SerializeField] private float swipeResistance = 100;
	private Vector2 initialPos;
	private Vector2 currentPos => position.ReadValue<Vector2>();

	float keyboardHorizontalV2 => keyboardHorizontal.ReadValue<float>();
	float keyboardVerticalV2 => keyboardVertical.ReadValue<float>();

	bool isSwiping;
	private void Awake()
	{
		SpaceEnter.Enable();
		position.Enable();
		press.Enable();
		keyboardHorizontal.Enable();
		keyboardVertical.Enable();
		pressHorizontal.Enable();
		press.started += context => PrintPress();
		//press.canceled += context => PressDone();
		press.performed += _ => { initialPos = currentPos; };
		press.canceled += _ => DetectSwipe();
		instance = this;
		SpaceEnter.performed += _ => enterPressAction.Invoke();
	}

	void switchToOpen()
    {
		isMovingUp = false;
    }

	void EnterPressed()
	{
		
	}
	void PrintPress()
    {
        initialPos = position.ReadValue<Vector2>();
		isSwiping = true;

	}
	void PressDone()
	{
		bool isRight = currentPos.x < initialPos.x;
		isSwiping = false;
    }
	void switchIsRotating()
    {
		isRotating = false;
    }

	bool isMovingUp;

	bool isRotating;
	private void DetectSwipe()
	{
		PressDone();	
		Vector2 delta = currentPos - initialPos;
		Vector2 direction = Vector2.zero;

		if (Mathf.Abs(delta.x) > swipeResistance)
		{
			direction.x = Mathf.Clamp(delta.x, -1, 1);
		}
		if (Mathf.Abs(delta.y) > swipeResistance)
		{
			direction.y = Mathf.Clamp(delta.y, -1, 1);
		}
	}
	float xPost=0;
	float xPre=0;
    private void Update()
    {
		//Debug.Log(pressHorizontal.ReadValue<float>());
        if (pressHorizontal.ReadValue<float>()>0){
			swipeMovement.Invoke(1);
		}
        if (pressHorizontal.ReadValue<float>() < 0){
			swipeMovement.Invoke(-1);
        }
        if (isSwiping)
		{
			xPre = currentPos.x - xPost;
			swipeMovement.Invoke(xPre);
			xPost = currentPos.x;
		}
		if (keyboardVerticalV2 != 0 & isMovingUp == false)
		{
			isMovingUp = true;
			verticalSwipe(keyboardVerticalV2);
			Invoke("switchToOpen", .5f);

		}
		if (keyboardHorizontalV2 != 0 & isRotating == false)
		{
			isRotating = true;
			Tower.currentLayerGO.GetComponent<TowerLayer>().RotateLayer(keyboardHorizontalV2);
			//horizontalSwipe(keyboardHorizontalV2);
			Invoke("switchIsRotating", .5f);

		}
	}

}


