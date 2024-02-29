using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuInicio : MonoBehaviour
{

    [Header("GameObject")]
    public GameObject menu;
    public GameObject opciones;
    public GameObject opcionesPanel;
    public GameObject controles;
    public GameObject pausa;
    public GameObject volume;
    public GameObject externalSkillTree;
    public GameObject newGameSettings;
    public GameObject LoadingPanel;
    public GameObject BestiarioPanel;
    public GameObject RaptorPanel;
    public GameObject TriceratopsPanel;
    public GameObject PterodactiloPanel;
    public GameObject TRexPanel;
    public GameObject CompsognathusPanel;
    public GameObject warningPopUp;
    public GameObject RaptorLockedPanel;
    public GameObject TricepLockedPanel;
    public GameObject PteroLockedPanel;
    public GameObject TRexLockedPanel;
    public GameObject CompyLockedPanel;

    [Header("Bool")]
    private bool enmenu;
    public bool opcionesIngame;
    public bool volumePanelActive;
    public bool controlPanelActive;
    public bool BestiarioPanelActive;
    public bool RaptorPanelActive;
    public bool TricePanelActive;
    public bool TRexPanelActive;
    public bool CompyPanelActive;
    public bool PteroPanelActive;

    private static MenuInicio _Reference;

    public static MenuInicio giveMeReference
    {
        get
        {

             return _Reference;

            
        }
    }

    

    private void Awake()
    {
        _Reference = this;

    }

    

    public void Start()
    {
        Time.timeScale = 1.0f;
        if (SceneManager.GetSceneByBuildIndex(0).isLoaded)
        {
            enmenu = true;
            opcionesIngame = false;
        }

        CheckRaptorIfUnlocked();
        CheckPteroIfUnlocked();
        CheckTriceIfUnlocked();
        CheckTRexIfUnlocked();
        CheckCompyIfUnlocked();
    }
    public void NewGameSettings()
    {
        newGameSettings.SetActive(true);
        
        SoundManager.dameReferencia.PlayClipByName(clipName: "Click");
    }

    public void ReturnFromNewGameSettings()
    {
        newGameSettings.SetActive(false);
        
        SoundManager.dameReferencia.PlayClipByName(clipName: "Click");
    }

    public void NuevaPartida()
    {
        //volume.SetActive(true);
        Time.timeScale = 1;
        SoundManager.dameReferencia.PlayClipByName(clipName: "Click");
        SceneManager.LoadScene(1);
        pausa = GameObject.Find("PauseScreen");
        opciones.SetActive(true);
        LoadingPanel.SetActive(true);
    }
    
    private void OnLevelWasLoaded(int level)
    {
        
        if (level == 1)
        {
            
            enmenu = false;
            //opcionesCanvas = GameObject.FindGameObjectWithTag("OptionsPanel");
            opciones = GameObject.Find("Opciones");
            pausa = GameObject.Find("PauseScreen");
            
            opciones.SetActive(false);


        }
        

    }
    
    public void CargarPartida()
    {
        //SceneManager.LoadScene(1);
    }
    public void Opciones()
    {
        menu.gameObject.SetActive(false);
        opciones.gameObject.SetActive(true);
        SoundManager.dameReferencia.PlayOneClipByName(clipName: "Click");
    }

    public void Volume()
    {
        volume.gameObject.SetActive(true);
        volumePanelActive = true;
        opcionesIngame = false;
        //opcionesPanel.gameObject.SetActive(false);
        SoundManager.dameReferencia.PlayClipByName(clipName: "Click");
    }

    public void Bestiario()
    {
        BestiarioPanel.gameObject.SetActive(true);
        BestiarioPanelActive = true;
        opcionesIngame = false;
        //opcionesPanel.gameObject.SetActive(false);
        SoundManager.dameReferencia.PlayClipByName(clipName: "Click");
    }

    public void CheckRaptorIfUnlocked()
    {
        if (PlayerPrefs.GetFloat("raptor") == 0)
        {
            RaptorLockedPanel.SetActive(true);
            //SoundManager.dameReferencia.PlayOneClipByName(clipName: "Error");
        }
        if (PlayerPrefs.GetFloat("raptor") == 1)
        {
            RaptorLockedPanel.SetActive(false);
        }
    }

    public void CheckPteroIfUnlocked()
    {
        if (PlayerPrefs.GetFloat("Pterodactilo") == 0)
        {
            PteroLockedPanel.SetActive(true);
            //SoundManager.dameReferencia.PlayOneClipByName(clipName: "Error");
        }
        if (PlayerPrefs.GetFloat("Pterodactilo") == 1)
        {
            PteroLockedPanel.SetActive(false);
        }
    }

    public void CheckTriceIfUnlocked()
    {
        if (PlayerPrefs.GetFloat("Triceratops") == 0)
        {
            TricepLockedPanel.SetActive(true);
            //SoundManager.dameReferencia.PlayOneClipByName(clipName: "Error");
        }
        if (PlayerPrefs.GetFloat("Triceratops") == 1)
        {
            TricepLockedPanel.SetActive(false);
        }
    }

    public void CheckTRexIfUnlocked()
    {
        if (PlayerPrefs.GetFloat("Trex") == 0)
        {
            TRexLockedPanel.SetActive(true);
            //SoundManager.dameReferencia.PlayOneClipByName(clipName: "Error");
        }
        if (PlayerPrefs.GetFloat("Trex") == 1)
        {
            TRexLockedPanel.SetActive(false);
        }
    }

    public void CheckCompyIfUnlocked()
    {
        if (PlayerPrefs.GetFloat("Compy") == 0)
        {
            CompyLockedPanel.SetActive(true);
            //SoundManager.dameReferencia.PlayOneClipByName(clipName: "Error");
        }
        if (PlayerPrefs.GetFloat("Compy") == 1)
        {
            CompyLockedPanel.SetActive(false);
        }
    }

    public void Raptor()
    {
        if (PlayerPrefs.GetFloat("raptor") == 0)
        {
            RaptorLockedPanel.SetActive(true);
            //SoundManager.dameReferencia.PlayOneClipByName(clipName: "Error");
        }
        if (PlayerPrefs.GetFloat("raptor") == 1)
        {
            RaptorPanel.gameObject.SetActive(true);
            RaptorPanelActive = true;
            opcionesIngame = false;
            BestiarioPanelActive = false;
            //BestiarioPanel.gameObject.SetActive(false);
            SoundManager.dameReferencia.PlayClipByName(clipName: "Click");
        }
        
    }

    public void Triceratops()
    {
        if (PlayerPrefs.GetFloat("Triceratops") == 0)
        {
            TricepLockedPanel.SetActive(true);
            //SoundManager.dameReferencia.PlayOneClipByName(clipName: "Error");
        }
        if (PlayerPrefs.GetFloat("Triceratops") == 1)
        {
            TriceratopsPanel.gameObject.SetActive(true);
            TricePanelActive = true;
            opcionesIngame = false;
            BestiarioPanelActive = false;
            //BestiarioPanel.gameObject.SetActive(false);
            SoundManager.dameReferencia.PlayClipByName(clipName: "Click");
        }

    }

    public void Pterodactilo()
    {
        if (PlayerPrefs.GetFloat("Pterodactilo") == 0)
        {
            PteroLockedPanel.SetActive(true);
            //SoundManager.dameReferencia.PlayOneClipByName(clipName: "Error");
        }
        if (PlayerPrefs.GetFloat("Pterodactilo") == 1)
        {
            PterodactiloPanel.gameObject.SetActive(true);
            PteroPanelActive = true;
            opcionesIngame = false;
            BestiarioPanelActive = false;
            //BestiarioPanel.gameObject.SetActive(false);
            SoundManager.dameReferencia.PlayClipByName(clipName: "Click");
        }
        
    }

    public void TRex()
    {
        if (PlayerPrefs.GetFloat("Trex") == 0)
        {
            TRexLockedPanel.SetActive(true);
            //SoundManager.dameReferencia.PlayOneClipByName(clipName: "Error");
        }
        if (PlayerPrefs.GetFloat("Trex") == 1)
        {
            TRexPanel.gameObject.SetActive(true);
            TRexPanelActive = true;
            opcionesIngame = false;
            BestiarioPanelActive = false;
            //BestiarioPanel.gameObject.SetActive(false);
            SoundManager.dameReferencia.PlayClipByName(clipName: "Click");
        }
        
    }

    public void Compsognathus()
    {
        if (PlayerPrefs.GetFloat("Compy") == 0)
        {
            CompyLockedPanel.SetActive(true);
            //SoundManager.dameReferencia.PlayOneClipByName(clipName: "Error");
        }
        if (PlayerPrefs.GetFloat("Compy") == 1)
        {
            CompsognathusPanel.gameObject.SetActive(true);
            CompyPanelActive = true;
            opcionesIngame = false;
            BestiarioPanelActive = false;
            //BestiarioPanel.gameObject.SetActive (false);
            SoundManager.dameReferencia.PlayClipByName(clipName: "Click");
        }
        
    }

    public void Volver()
    {
        if (opcionesIngame == true && enmenu == false)
        {
            this.gameObject.SetActive(false);
            pausa.gameObject.SetActive(true);
            SoundManager.dameReferencia.PlayClipByName(clipName: "Click");
            opcionesIngame = false;
        }
        if(enmenu == true)
        {
            menu.gameObject.SetActive(true);
            opciones.gameObject.SetActive(false);
            SoundManager.dameReferencia.PlayClipByName(clipName: "Click");
        }
        
        
    }

    public void WarningBorrarDatos()
    {
        warningPopUp.gameObject.SetActive(true);
    }

    public void BorrarDatos()
    {

        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(0);
    }

    public void CancelarBorrarDatos()
    {
        warningPopUp.gameObject.SetActive(false);
    }

    public void ControlesVolver()
    {
        controles.gameObject.SetActive(false);
        controlPanelActive = false;
        //opcionesPanel.gameObject.SetActive(true);
        SoundManager.dameReferencia.PlayClipByName(clipName: "Click");
    }

    public void VolumeReturn()
    {
        volume.gameObject.SetActive(false);
        volumePanelActive = false;
        opcionesIngame = true;
        //opcionesPanel.gameObject.SetActive(true);
        SoundManager.dameReferencia.PlayClipByName(clipName: "Click");
    }

    public void BestiarioReturn()
    {
        BestiarioPanel.gameObject.SetActive(false);
        BestiarioPanelActive = false;
        opcionesIngame = true;
        //opcionesPanel.gameObject.SetActive(true);
        SoundManager.dameReferencia.PlayClipByName(clipName: "Click");
    }


    public void RaptorReturn()
    {
        RaptorPanel.gameObject.SetActive(false);
        RaptorPanelActive = false;
        opcionesIngame = true;
        BestiarioPanelActive = true;
        //BestiarioPanel.gameObject.SetActive(true);
        SoundManager.dameReferencia.PlayClipByName(clipName: "Click");
    }

    public void TriceratopsReturn()
    {
        TriceratopsPanel.gameObject.SetActive(false);
        TricePanelActive = false;  
        opcionesIngame = true;
        BestiarioPanelActive = true;
        //BestiarioPanel.gameObject.SetActive(true);
        SoundManager.dameReferencia.PlayClipByName(clipName: "Click");
    }

    public void PterodactiloReturn()
    {
        PterodactiloPanel.gameObject.SetActive(false);
        PteroPanelActive = false;
        opcionesIngame = true;
        BestiarioPanelActive = true;
        //BestiarioPanel.gameObject.SetActive(true);
        SoundManager.dameReferencia.PlayClipByName(clipName: "Click");
    }

    public void TRexReturn()
    {
        TRexPanel.gameObject.SetActive(false);
        TRexPanelActive = false;
        opcionesIngame = true;
        BestiarioPanelActive = true;
        //BestiarioPanel.gameObject.SetActive(true);
        SoundManager.dameReferencia.PlayClipByName(clipName: "Click");
    }

    public void CompsognathusReturn()
    {
        CompsognathusPanel.gameObject.SetActive(false);
        CompyPanelActive = false;
        opcionesIngame = true;
        BestiarioPanelActive = true;
        //BestiarioPanel.gameObject.SetActive(true);
        SoundManager.dameReferencia.PlayClipByName(clipName: "Click");
    }

    public void ExternalSkillTree()
    {
        externalSkillTree.gameObject.SetActive(true);
        opcionesPanel.gameObject.SetActive(false);
        SoundManager.dameReferencia.PlayClipByName(clipName: "Click");
    }
    public void ExternalSkillTreeReturn()
    {
        externalSkillTree.gameObject.SetActive(false);
        opcionesPanel.gameObject.SetActive(true);
        SoundManager.dameReferencia.PlayClipByName(clipName: "Click");
    }

    public void SalirJuego()
    {
        Application.Quit();
    }

    public void Controles()
    {
        //opcionesPanel.gameObject.SetActive(false);
        controles.gameObject.SetActive(true);
        controlPanelActive = true;
        opcionesIngame = false;
        SoundManager.dameReferencia.PlayClipByName(clipName: "Click");
    }

    public void Continue()
    {
        Time.timeScale = 1;
        pausa.gameObject.SetActive(false);
        SoundManager.dameReferencia.PlayClipByName(clipName: "Click");
    }

    public void QuitInGame()
    {
        SoundManager.dameReferencia.PlayClipByName(clipName: "Click");
        gameManager.giveMeReference.PlayerDead(); 
    }

    public void OpcionesInGame()
    {
        GameObject botonfix = GameObject.Find("Boton Fix");
        pausa = botonfix.GetComponent<BotonOpcionesFix>().pause;
        //pausa.gameObject.SetActive(false);
        pausa.GetComponent<PauseMenuEnabled>().EnableOrDisablePausePanel();

        if (opciones == null)
        {
            opciones = GameObject.Find("Opciones");
            this.gameObject.SetActive(true);
            opcionesIngame = true;
            SoundManager.dameReferencia.PlayClipByName(clipName: "Click");
        }
        else
        {
            opciones = GameObject.Find("Opciones");
            this.gameObject.SetActive(true);
            opcionesIngame = true;
            SoundManager.dameReferencia.PlayClipByName(clipName: "Click");
        }

        this.gameObject.SetActive(true);
    }

    public void OpcionesReturnInGame()
    {
        opciones.SetActive(false);
        GameObject botonfix = GameObject.Find("Boton Fix");
        pausa = botonfix.GetComponent<BotonOpcionesFix>().pause;
        pausa.gameObject.SetActive(true);
        SoundManager.dameReferencia.PlayClipByName(clipName: "Click");
    }

}
