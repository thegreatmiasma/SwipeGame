
using UnityEngine;
using UnityEngine.EventSystems;
public class MoveSwipe : MonoBehaviour, IPointerClickHandler
{

    public void OnPointerClick(PointerEventData eventData)
    {
      Debug.Log("determining swiper direction");
    }

}
