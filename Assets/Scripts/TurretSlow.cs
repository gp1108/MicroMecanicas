using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TurretSlow : MonoBehaviour
{
    public LayerMask layer;
    private Collider[] _zoneSlow;

    public GameObject rangeIndicator;
    private bool _mostrarRango;
    public GameObject buildMenu;

    private GameObject canvas;
    // Start is called before the first frame update
    void Start()
    {
        canvas = GameObject.Find("Canvas");
        rangeIndicator = GameObject.FindGameObjectWithTag("RangeIndicator");
        buildMenu = GameObject.FindGameObjectWithTag("Canvas");
        Skills.giveMeReference.listaActualizarTurrets += ActualizarVidaTorres;
        GetComponent<Health>().healthPoints = UpgradeManager.giveMeReference.vidaSlow;
    }

    // Update is called once per frame
    void Update()
    {
        Slow();
    }
    public void Slow()
    {
        SoundManager.dameReferencia.PlayClipByName(clipName: "Slow");
        _zoneSlow= Physics.OverlapSphere(transform.position,20, layer);
        if (_zoneSlow.Length > 0)
        {
            foreach (Collider c in _zoneSlow)
            {
                if (c.gameObject.GetComponent<NavMeshAgent>()!=null)
                {
                    c.gameObject.GetComponent<Health>().GetSlow(this.gameObject);
                }
            }
        }
    }

    public void ActualizarVidaTorres()
    {
        GetComponent<Health>().healthPoints += 5;
    }
    void OnDestroy()
    {
        if (!this.gameObject.scene.isLoaded) return;
        Skills.giveMeReference.listaActualizarTurrets -= ActualizarVidaTorres;
        gameManager.giveMeReference.DeletTurret(this.gameObject);
    }

    private void OnMouseUpAsButton()
    {
        Mostrar();
    }

    private void OnMouseExit()
    {
        Ocultar();
    }


    private void Mostrar()
    {
        bool isDestroyModeActive = canvas.GetComponent<BuildMenuButton>().destroyModeActive;
        if (isDestroyModeActive == false)
        {
            rangeIndicator.transform.position = this.transform.position;
            rangeIndicator.GetComponent<MeshRenderer>().enabled = true;
            rangeIndicator.transform.localScale = new Vector3(UpgradeManager.giveMeReference.rangeSlow * 2, UpgradeManager.giveMeReference.rangeSlow * 2, UpgradeManager.giveMeReference.rangeSlow * 2);

            _mostrarRango = true;
        }
        else
        {
            return;
        }

    }

    private void Ocultar()
    {
        _mostrarRango = false;
        rangeIndicator.GetComponent<MeshRenderer>().enabled = false;
        rangeIndicator.transform.position = new Vector3(0, -50, 0);
    }
}
