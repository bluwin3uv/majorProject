using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Mainmenu : MonoBehaviour
{
    public bool showOp, mute, showAudOp;
    public float audioSlider, amSlider, dirSlider, unmuteVolume;
    public AudioSource audi;
    public Light dirLight;
    public Light amLight;



    // Use this for initialization
    void Start()
    {
        audioSlider = 1;
        dirSlider = 1;
        amSlider = 1;

        audi = GameObject.Find("Audio Source").GetComponent<AudioSource>();
        dirLight = GameObject.Find("Directional Light").GetComponent<Light>();
        if (PlayerPrefs.HasKey("Volume"))
        {
            RenderSettings.ambientIntensity = PlayerPrefs.GetFloat("AmbientLight");
            dirLight.intensity = PlayerPrefs.GetFloat("DirectionalLight");
            audi.volume = PlayerPrefs.GetFloat("Volume");
        }

        audioSlider = audi.volume;
        dirSlider = dirLight.intensity;
        amSlider = RenderSettings.ambientIntensity;
        if (PlayerPrefs.GetInt("mute") == 0)
        {
            mute = true;
            unmuteVolume = PlayerPrefs.GetFloat("Volume");
            audioSlider = 0;
            audi.volume = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (audi.volume != audioSlider)
        {
            audi.volume = audioSlider;
        }

        if (dirLight.intensity != dirSlider)
        {
            dirLight.intensity = dirSlider;
        }


        if (RenderSettings.ambientIntensity != amSlider)
        {
            RenderSettings.ambientIntensity = amSlider;
        }
    }

    void OnGUI()
    {
        float scrW = Screen.width / 16;
        float scrH = Screen.height / 9;

        GUI.Box(new Rect(0, 0, Screen.width, Screen.height), "");
        if (!showOp)
        {
           // GUI.Box(new Rect(16 * scrW, 9 * scrH, 12 * scrW, 4 * scrH), "Title");

            if (GUI.Button(new Rect(6 * scrW, 6 * scrH, 4 * scrW, 2 * scrH), "Play"))
            {
                SceneManager.LoadScene("Level_001");
            }

            if (GUI.Button(new Rect(1 * scrW, 6 * scrH, 4 * scrW, 2 * scrH), "Options"))
            {
                showOp = true;
            }

            if (GUI.Button(new Rect(11 * scrW, 6 * scrH, 4 * scrW, 2 * scrH), "Exit"))
            {
                Application.Quit();
            }
        }
        else
        {
            GUI.Label(new Rect(6 * scrW, 2.25f * scrH, 4 * scrW, 4f * scrH), "Volume");
            GUI.Label(new Rect(6 * scrW, 2.75f * scrH, 4 * scrW, 4f * scrH), "Brightness");
            GUI.Label(new Rect(6 * scrW, 3.25f * scrH, 4 * scrW, 4f * scrH), "Time of Day");
            if (!mute)
            {
                audioSlider = GUI.HorizontalSlider(new Rect(6 * scrW, 2.5f * scrH, 4 * scrW, 0.25f * scrH), audioSlider, 0f, 1f);
            }
            else
            {
                GUI.HorizontalSlider(new Rect(6 * scrW, 2.5f * scrH, 4 * scrW, 0.25f * scrH), audioSlider, 0f, 1f);
            }
            amSlider = GUI.HorizontalSlider(new Rect(6 * scrW, 3f * scrH, 4 * scrW, 0.25f * scrH), amSlider, 0f, 1f);
            dirSlider = GUI.HorizontalSlider(new Rect(6 * scrW, 3.5f * scrH, 4 * scrW, 0.25f * scrH), dirSlider, 0f, 1f);
            if (GUI.Button(new Rect(6 * scrW, 0.55f * scrH, 4 * scrW, 0.75f * scrH), "Graphics"))
            {

            }

            if (GUI.Button(new Rect(0 * scrW, 0 * scrH, 0.55f * scrW, 0.55f * scrH), "Back"))
            {
                showOp = false;
                SaveOptions();
            }
            {
                if (Input.GetKey(KeyCode.Escape))
                {
                    showOp = false;
                }
            }

            if (GUI.Button(new Rect(6 * scrW, 1.5f * scrH, 4 * scrW, 0.75f * scrH), "Audio"))
            {

            }

            if (GUI.Button(new Rect(10 * scrW, 1.5f * scrH, 0.55f * scrW, 0.75f * scrH), "Mute"))
            {
                Mute();
            }

        }

    }

    void SaveOptions()
    {
        PlayerPrefs.SetFloat("Volume", audioSlider);
        PlayerPrefs.SetFloat("AmbientLight", amSlider);
        PlayerPrefs.SetFloat("DirectionalLight", dirSlider);
        if (mute)
        {
            PlayerPrefs.SetInt("mute", 0);
        }
        else
        {
            PlayerPrefs.SetInt("mute", 1);
        }
    }

    public bool Mute()
    {

        if (mute)
        {

            // audi.volume = unmuteVolume;
            audioSlider = unmuteVolume;
            mute = false;
            return false;
        }
        else
        {
            unmuteVolume = audioSlider;
            audioSlider = 0;
            mute = true;
            return true;
        }
    }

}
