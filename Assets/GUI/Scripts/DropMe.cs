using System.Reflection;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DropMe : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
	public SpaceGarbage.ShipTypes shipType;
	public Button activateButton;

	public string modelKeyOnDrop;

	public Image containerImage;
	public Image receivingImage;
	private Color normalColor;
	public Color highlightColor = Color.yellow;

	public GameObject callBackObj;
	public string callBackFun;
	public int callBackArg;
	
	public void OnEnable ()
	{
		if (containerImage != null)
			normalColor = containerImage.color;
	}
	
	public void OnDrop(PointerEventData data)
	{
		if(containerImage != null)
			containerImage.color = normalColor;
		
		if (receivingImage == null)
			return;

		Sprite dropSprite = GetDropSprite (data);
		if (dropSprite != null)
			receivingImage.overrideSprite = dropSprite;

		if(modelKeyOnDrop != null) {
			int compValue;
			GameObject ob;
			ob = GameObject.Find("icon");
			if(ob != null) {
				compValue = (int) ob.GetComponent<CompIconDrag>().componentValue;
				Model.SetData(modelKeyOnDrop, compValue);
				GameObject.Find("ShipBuilder").GetComponent<ShipBuilder>().UpdateShipInfo((int) shipType);
				activateButton.interactable = true;
			}
		}
	}

	public void OnPointerEnter(PointerEventData data)
	{
		if (containerImage == null)
			return;
		
		Sprite dropSprite = GetDropSprite (data);
		if (dropSprite != null)
			containerImage.color = highlightColor;
	}

	public void OnPointerExit(PointerEventData data)
	{
		if (containerImage == null)
			return;
		
		containerImage.color = normalColor;
	}
	
	private Sprite GetDropSprite(PointerEventData data)
	{
		var originalObj = data.pointerDrag;
		if (originalObj == null)
			return null;

		var srcImage = originalObj.GetComponent<Image>();
		return srcImage.sprite;
	}
}
