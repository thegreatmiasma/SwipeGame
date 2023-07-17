using System.Collections;
using UnityEngine;
public class Mover : MonoBehaviour
{
	GameObject selectedObjectRow;
	TowerCreator towerCreator;
	MoveTowerVertical moveTowardVertical;



    private void Start()
    {
		moveTowardVertical = GetComponent<MoveTowerVertical>();
		InputReader.instance.verticalSwipe += context => { Move(context); };
	}

	public void SetTowerCreator(TowerCreator _towerCreator)
    {
		towerCreator = _towerCreator;
    }


	private void Move(float yDirection)
	{
		selectedObjectRow = Tower.currentLayerGO;
		
		if(yDirection != 0)
        {
			
            if (yDirection > 0)
            {
			  if( Tower.SetCurrentLayer(false)==true)
				moveTowardVertical.MoveTower(false);
			}
            else {

				if (Tower.SetCurrentLayer(true) == true)
					moveTowardVertical.MoveTower(true);
			}
			selectedObjectRow = Tower.currentLayerGO;
			


		}
		
	}
}
