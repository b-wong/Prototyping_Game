using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [FMODUnity.EventRef]
    public string mainThemeEvent;

    public FMOD.Studio.EventInstance mainTheme;

    // Singleton pattern
    public static AudioManager amInstance = null;
    private void Awake()
    {
        if (amInstance == null)
        {
            amInstance = this;
        }
        else if (amInstance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        FMOD.Studio.PLAYBACK_STATE fmodPbState;
        mainTheme.getPlaybackState(out fmodPbState);
        if (fmodPbState != FMOD.Studio.PLAYBACK_STATE.PLAYING)
        {
            mainTheme.start();
        }
        FMODUnity.RuntimeManager.PlayOneShot(mainThemeEvent);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
