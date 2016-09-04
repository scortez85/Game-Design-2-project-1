using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;

public class optionsData : MonoBehaviour {

    public float musicVolume, sfxVolume;
    public bool violenceEnabled;
    public bool fullscreenEnabled;
    public GameObject musicCntrl, sfxCntrl;
    
	void Start () {
        //saveOptions();
        loadOptions();
	}
	public void saveOptions()
    {
        StreamWriter writer = new StreamWriter("options.dat");
        writer.WriteLine(musicVolume);
        writer.WriteLine(sfxVolume);
        writer.WriteLine(fullscreenEnabled);
        writer.WriteLine(violenceEnabled);
        writer.Close();
        
    }
    public void loadOptions()
    {
        StreamReader reader = new StreamReader("options.dat");
        musicVolume = float.Parse(reader.ReadLine());
        sfxVolume = float.Parse(reader.ReadLine());
        fullscreenEnabled = bool.Parse(reader.ReadLine());
        violenceEnabled = bool.Parse(reader.ReadLine());
        reader.Close();

        musicCntrl.GetComponent<Slider>().value = musicVolume;
        sfxCntrl.GetComponent<Slider>().value = sfxVolume;
        
        
    }
	// Update is called once per frame
	void Update () {
        if (Application.loadedLevel.Equals(0))
            musicVolume = musicCntrl.GetComponent<Slider>().value;
        if (Application.loadedLevel.Equals(0))
            sfxVolume = sfxCntrl.GetComponent<Slider>().value;


    }
    public void toggleViolence()
    {
        if (violenceEnabled)
            violenceEnabled = false;
        else if (!violenceEnabled)
            violenceEnabled = true;
    }
    public void toggleFullscreen()
    {
        if (!fullscreenEnabled)
            fullscreenEnabled = true;
        else if (fullscreenEnabled)
            fullscreenEnabled = false;
    }
    public void setMusicVol(float vol)
    {
        musicVolume = vol;
    }
}
