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
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Health>().healthPoints = 10;
    }

    // Update is called once per frame
    void Update()
    {
        Slow();
    }
    public void Slow()
    {
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

    private void OnMouseUpAsButton()
    {
        if (buildMenu.GetComponent<BuildMenuButton>().buildMenuActive == true)
        {
            return;
        }
        else
        {
            Mostrar();
        }

    }

    private void OnMouseExit()
    {
        Ocultar();
    }


    private void Mostrar()
    {
        rangeIndicator.transform.position = this.transform.position;
        rangeIndicator.GetComponent<MeshRenderer>().enabled = true;
        rangeIndicator.transform.localScale = new Vector3(UpgradeManager.giveMeReference.rangeSlow * 2, UpgradeManager.giveMeReference.rangeSlow * 2, UpgradeManager.giveMeReference.rangeSlow * 2);

        _mostrarRango = true;
    }

    private void Ocultar()
    {
        _mostrarRango = false;
        rangeIndicator.GetComponent<MeshRenderer>().enabled = false;
        rangeIndicator.transform.position = new Vector3(0, -50, 0);
    }
}
