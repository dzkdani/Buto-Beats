using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour
{
    //for changeable volume
    float volumeAllBGMs;
    float volumeAllSFXs;
    float volumeAllVoices;

    //for default volume
    private const float DEFAULT_BGM_VOLUME = .8f;
    private const float DEFAULT_SFX_VOLUME = .8f;
    private const float DEFAULT_VOI_VOLUME = .8f;

    //for const non changeable volume
    private const float CONSTANTA_VOLUME_ALL_BGMS = 1.0f;
    private const float CONSTANTA_VOLUME_ALL_SFXS = 0.7f;
    private const float CONSTANTA_VOLUME_ALL_VOIS = 0.7f;

    private static SoundManager Instance;

    void Awake()
    {
        setBGMVolume(DEFAULT_BGM_VOLUME);
        setSFXVolume(DEFAULT_SFX_VOLUME);
        setVoiceVolume(DEFAULT_VOI_VOLUME);

        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (Instance != this)
            Destroy(gameObject);
    }


    public static SoundManager getInstance()
    {

        return Instance;
    }

    #region SETTER-GETTER

    public void setBGMVolume(float _volumeAllBGMs)
    {
        volumeAllBGMs = _volumeAllBGMs * CONSTANTA_VOLUME_ALL_BGMS;
        implementChangeVolumeAllBGMs();
    }

    public float getBGMVolume()
    {
        return volumeAllBGMs;
    }

    public void setSFXVolume(float _volumeAllSFXs)
    {
        volumeAllSFXs = _volumeAllSFXs * CONSTANTA_VOLUME_ALL_SFXS;
    }

    public float getSFXVolume()
    {
        return volumeAllSFXs;
    }

    public void setVoiceVolume(float _volumeAllVoices)
    {
        volumeAllVoices = _volumeAllVoices * CONSTANTA_VOLUME_ALL_VOIS;
    }

    public float getVoiceVolume()
    {
        return volumeAllVoices;

    }

    #endregion

    //#region BGM

    private AudioSource bGM_Source;
    void init_BGM_Source()
    {
        bGM_Source = gameObject.AddComponent<AudioSource>();
        bGM_Source.loop = true;
    }
    
    #region BGM_GamePlay
    [SerializeField]
    private AudioClip bGM_GamePlay;
    private const float CONSTANTA_VOLUME_BGM_GAME_PLAY = 1;



    public void play_BGM_GamePlay()
    {
        if (bGM_Source == null) init_BGM_Source();
        bGM_Source.clip = bGM_GamePlay;
        bGM_Source.volume = getBGMVolume() * CONSTANTA_VOLUME_BGM_GAME_PLAY * CONSTANTA_VOLUME_ALL_BGMS;
        bGM_Source.Play();
    }

    private void stop_BGM_GamePlay()
    {
        bGM_Source.Stop();
    }

    private void updateVolume_BGM_GamePlay()
    {
        if (bGM_Source == null) init_BGM_Source();
        bGM_Source.volume = getBGMVolume() * CONSTANTA_VOLUME_BGM_GAME_PLAY * CONSTANTA_VOLUME_ALL_BGMS;
    }

    #endregion

    #region BGM_GamePlay
    [SerializeField]
    private AudioClip bGM_Comic;
    private const float CONSTANTA_VOLUME_BGM_COMIC = 1;

    public void play_BGM_Comic()
    {
        if (bGM_Source == null) init_BGM_Source();
        bGM_Source.clip = bGM_Comic;
        bGM_Source.volume = getBGMVolume() * CONSTANTA_VOLUME_BGM_COMIC * CONSTANTA_VOLUME_ALL_BGMS;
        bGM_Source.Play();
    }

    private void stop_BGM_Comic()
    {
        bGM_Source.Stop();
    }

    private void updateVolume_BGM_Comic()
    {
        if (bGM_Source == null) init_BGM_Source();
        bGM_Source.volume = getBGMVolume() * CONSTANTA_VOLUME_BGM_COMIC * CONSTANTA_VOLUME_ALL_BGMS;
    }

    #endregion


    #region BGM_MainMenu

    [SerializeField]
    private AudioClip bGM_MainMenu;
    private const float CONSTANTA_VOLUME_BGM_MAIN_MENU = 1;

    public void play_BGM_MainMenu()
    {
        if (bGM_Source == null) init_BGM_Source();
        bGM_Source.clip = bGM_MainMenu;
        bGM_Source.volume = getBGMVolume() * CONSTANTA_VOLUME_BGM_MAIN_MENU * CONSTANTA_VOLUME_ALL_BGMS;
        bGM_Source.Play();
    }

    public void fadeOut_BGM_MainMenu()
    {
        bGM_Source.volume *= 0.9f;
        if (bGM_Source.volume > 0.025f)
        {
            Invoke("fadeOut_BGM_MainMenu", .25f);
        }
        else
        {
            stop_BGM_MainMenu();
        }
    }

    private void stop_BGM_MainMenu()
    {
        bGM_Source.Stop();
    }

    private void updateVolume_BGM_MainMenu()
    {
        if (bGM_Source == null) init_BGM_Source();
        bGM_Source.volume = getBGMVolume() * CONSTANTA_VOLUME_BGM_MAIN_MENU * CONSTANTA_VOLUME_ALL_BGMS;
    }

    #endregion

    //#endregion

    //#region SFX
    private AudioSource sFX_Source;
    void init_SFX_Source()
    {
        sFX_Source = gameObject.AddComponent<AudioSource>();
    }


    #region SFX_Button

    [SerializeField]
    private AudioClip sFX_Button;
    private const float CONSTANTA_VOLUME_SFX_BUTTON = 2f;

    public void play_sFX_Button()
    {
        if (sFX_Source == null) init_SFX_Source();
        float volume = getSFXVolume() * CONSTANTA_VOLUME_SFX_BUTTON * CONSTANTA_VOLUME_ALL_SFXS;
        sFX_Source.PlayOneShot(sFX_Button, volume);
        sFX_Source.pitch = Random.Range(1.25f, 1.5f);

    }

    #endregion

    #region SFX_HiScore

    [SerializeField]
    private AudioClip sFX_HiScore;
    private const float CONSTANTA_VOLUME_SFX_HISCORE = 2f;

    public void play_sFX_HiScore()
    {
        if (sFX_Source == null) init_SFX_Source();
        float volume = getSFXVolume() * CONSTANTA_VOLUME_SFX_HISCORE * CONSTANTA_VOLUME_ALL_SFXS;
        sFX_Source.PlayOneShot(sFX_HiScore, volume);

    }

    #endregion

    #region SFX_Gamelan

    [SerializeField]
    //private AudioClip sFX_Gamelan;
    private const float CONSTANTA_VOLUME_SFX_GAMELAN = 1f;

    public void play_sFX_Gamelan(AudioClip sFX_Gamelan, float vol)
    {
        if (sFX_Source == null) init_SFX_Source();
        float volume = vol * getSFXVolume() * CONSTANTA_VOLUME_SFX_GAMELAN * CONSTANTA_VOLUME_ALL_SFXS;
        sFX_Source.PlayOneShot(sFX_Gamelan, volume);
        sFX_Source.pitch = Random.Range(.95f, 1.05f);
        sFX_Source.volume = volume * Random.Range(.95f, 1.05f);
    }
    #endregion

    #region SFX_Lose
    [SerializeField]
    private AudioClip sFX_Lose;
    private const float CONSTANTA_VOLUME_SFX_LOSE = 2f;

    public void play_sFX_Lose()
    {
        if (sFX_Source == null) init_SFX_Source();
        float volume = getSFXVolume() * CONSTANTA_VOLUME_SFX_LOSE * CONSTANTA_VOLUME_ALL_SFXS;
        sFX_Source.PlayOneShot(sFX_Lose, volume);
    }
    #endregion


    #region VOICE
    private AudioSource vOI_Source;
    void init_VOI_Source()
    {
        vOI_Source = gameObject.AddComponent<AudioSource>();
    }

    #region VOI_Buto

    [SerializeField]
    private AudioClip vOI_ButoDie;
    private const float CONSTANTA_VOLUME_VOI_BUTO = .6f;

    public void play_vOI_ButoDie()
    {
        if (vOI_Source == null) init_VOI_Source();
        float volume = getVoiceVolume() * CONSTANTA_VOLUME_VOI_BUTO * CONSTANTA_VOLUME_ALL_VOIS;
        vOI_Source.PlayOneShot(vOI_ButoDie, volume);
        vOI_Source.pitch = Random.Range(.95f, 1.1f);
    }

    #endregion

    #region VOI_ButoGrowl

    [SerializeField]
    private AudioClip vOI_ButoGrowl;
    private const float CONSTANTA_VOLUME_VOI_BUTO_GROWL = 1;

    public void play_vOI_ButoGrowl()
    {
        if (vOI_Source == null) init_VOI_Source();
        float volume = getVoiceVolume() * CONSTANTA_VOLUME_VOI_BUTO_GROWL * CONSTANTA_VOLUME_ALL_VOIS;
        vOI_Source.PlayOneShot(vOI_ButoGrowl, volume);
        vOI_Source.pitch = Random.Range(.1f, 1.25f);
    }

    #endregion

    #region VOI_ButoGrowl2

    [SerializeField]
    private AudioClip vOI_ButoGrowlShort;
    private const float CONSTANTA_VOLUME_VOI_BUTO_GROWL_SHORT = 2;

    public void play_vOI_ButoGrowlShort()
    {
        if (vOI_Source == null) init_VOI_Source();
        float volume = getVoiceVolume() * CONSTANTA_VOLUME_VOI_BUTO_GROWL_SHORT * CONSTANTA_VOLUME_ALL_VOIS;
        vOI_Source.PlayOneShot(vOI_ButoGrowlShort, volume);
        vOI_Source.pitch = Random.Range(.95f, 1.1f);
    }

    #endregion

    #endregion


    #region SOUND_MANAGER_DEFAULT_FUNCTION

    private void implementChangeVolumeAllBGMs()
    {
        updateVolume_BGM_GamePlay();
        updateVolume_BGM_MainMenu();
    }

    public void stopAllBGMs()
    {
        stop_BGM_GamePlay();
        stop_BGM_MainMenu();
    }

    public void soundOn()
    {
        setBGMVolume(DEFAULT_BGM_VOLUME);
        setSFXVolume(DEFAULT_SFX_VOLUME);
        setVoiceVolume(DEFAULT_VOI_VOLUME);
        implementChangeVolumeAllBGMs();
    }

    public void soundOff()
    {
        setBGMVolume(0);
        setSFXVolume(0);
        setVoiceVolume(0);
        implementChangeVolumeAllBGMs();
    }

    public void stopAllSounds()
    {
        stopAllBGMs();
    }

    #endregion

}
