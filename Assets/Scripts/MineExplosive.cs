using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.AI;

public class MineExplosive : MonoBehaviour
{
    public LayerMask layer;
    private Collider[] _zoneExplosion;
    private Collider[] _zonerrActivation;
    public GameObject explosionEffect;

    public bool itsPoisoned;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RangeExplosion();
    }
    public void RangeExplosion()
    {
        _zonerrActivation = Physics.OverlapSphere(transform.position, 1, layer);
        if (_zonerrActivation.Length > 0)
        {
            Explosion();
        }
    }
    public void Explosion()
    {
        SoundManager.dameReferencia.PlayOneClipByName(clipName: "Explosion");
        Instantiate(explosionEffect, this.gameObject.transform.position, Quaternion.identity);
        _zoneExplosion = Physics.OverlapSphere(transform.position, UpgradeManager.giveMeReference.rangeM, layer);
        foreach (Collider c in _zoneExplosion)
        {
            c.transform.GetComponent<Health>().GetDamaged(UpgradeManager.giveMeReference.damagedM, Bullet.tipoDeDamaged.Armadura);
            if (UpgradeManager.giveMeReference.itsUpgraded == 1)
            {
                c.transform.GetComponent<Health>().ItsPoisoned();
            }
        }
        Destroy(this.gameObject);
    }
}
