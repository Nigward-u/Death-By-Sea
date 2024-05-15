using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SettingsMenu : MonoBehaviour
{
    public TMPro.TMP_Dropdown resolutiondropdown;
    Resolution[] resolutions;
    // Start is called before the first frame update
    void Start()
    {
        resolutions= Screen.resolutions;
        resolutiondropdown.ClearOptions();
        List<string>options = new List<string>();
        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);
            if (resolutions[i].width == Screen.width &&  resolutions[i].height == Screen.height)
                {
                currentResolutionIndex = i;
                }
        }
        
        resolutiondropdown.AddOptions(options);
        resolutiondropdown.value = currentResolutionIndex;
        resolutiondropdown.RefreshShownValue();

    }

    // Update is called once per frame
    public void SetQualiy(int QualityIndex)
    {
        QualitySettings.SetQualityLevel(QualityIndex);
    }
    public void SeFullScreen(bool isfullscreen)
    {
        Screen.fullScreen = isfullscreen;
    }
    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution= resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height,Screen.fullScreen);

    }

    
}
