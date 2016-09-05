using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;

public class optionsData : MonoBehaviour {

    public float musicVolume, sfxVolume;
    public bool violenceEnabled;
    public bool fullscreenEnabled;
    public string netIp;
    public GameObject musicCntrl, sfxCntrl,addressText;
    
	void Start () {
        //saveOptions();
        loadOptions();
        if (Application.loadedLevel.Equals(0))
            netIp = addressText.GetComponent<Text>().text;
    }
	public void saveOptions()
    {
        StreamWriter writer = new StreamWriter("options.dat");
        writer.WriteLine(musicVolume);
        writer.WriteLine(sfxVolume);
        writer.WriteLine(fullscreenEnabled);
        writer.WriteLine(violenceEnabled);
        writer.WriteLine(netIp);
        writer.Close();
        
    }
    public void loadOptions()
    {
        StreamReader reader = new StreamReader("options.dat");
        musicVolume = float.Parse(reader.ReadLine());
        sfxVolume = float.Parse(reader.ReadLine());
        fullscreenEnabled = bool.Parse(reader.ReadLine());
        violenceEnabled = bool.Parse(reader.ReadLine());
        netIp = reader.ReadLine();
        reader.Close();

        musicCntrl.GetComponent<Slider>().value = musicVolume;
        sfxCntrl.GetComponent<Slider>().value = sfxVolume;
        addressText.GetComponent<Text>().text = netIp;
        
        
    }
    public void setIp(string button)
    {
        if (button.Equals("0") || button.Equals("1") || button.Equals("2") || button.Equals("3") || button.Equals("4") || button.Equals("5") || button.Equals("6") || button.Equals("7") || button.Equals("8") || button.Equals("9"))
            netIp += button;
        else if (button.Equals("C"))
            netIp = null;
        else if (button.Equals("D"))
            netIp = netIp;//needs work
        else if (button.Equals("P"))
            netIp += ".";
    }
	// Update is called once per frame
	void Update () {
        if (Application.loadedLevel.Equals(0))
            musicVolume = musicCntrl.GetComponent<Slider>().value;
        if (Application.loadedLevel.Equals(0))
            sfxVolume = sfxCntrl.GetComponent<Slider>().value;
        if (Application.loadedLevel.Equals(0))
            addressText.GetComponent<Text>().text = netIp;
        //if (Application.loadedLevel.Equals(0))
        //netIp = addressText.GetComponent<Text>().text;

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
