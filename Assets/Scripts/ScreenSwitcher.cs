using UnityEngine;
using System.Collections;

public class ScreenSwitcher : MonoBehaviour {
	public GameObject[] screens;
	int screenIndex = 0;
	GameObject currentScreen;

	void Start()
	{
		currentScreen = screens[screenIndex];
		currentScreen.SetActive(true);
	}

	public void NextScreen()
	{
		currentScreen.SetActive(false);
		screenIndex++;
		if(screenIndex > screens.Length - 1)
			screenIndex = 0;
		currentScreen = screens[screenIndex];
		currentScreen.SetActive(true);
	}

	public void PreviousScreen()
	{
		currentScreen.SetActive(false);
		screenIndex--;
		if(screenIndex < 0)
			screenIndex = screens.Length - 1;
		currentScreen = screens[screenIndex];
		currentScreen.SetActive(true);
	}
}
