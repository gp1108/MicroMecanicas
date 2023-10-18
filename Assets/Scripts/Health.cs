using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public float healthPoints;
    public Slider healthSlider;
    private GameObject mainCamera;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        StartCoroutine("SliderTracksCamera");
        healthSlider.maxValue = healthPoints;
        healthSlider.value = healthPoints;
        healthSlider.GetComponentInChildren<Image>().enabled = false;
    }

   
    public void GetDamaged(float Damaged)
    {
        healthSlider.GetComponentInChildren<Image>().enabled = true;
        healthPoints -= Damaged;
        healthSlider.value = healthPoints;
        if (healthPoints <= 0)
        {
            if (this.tag == "Wall")
            {
                BuildManager.dameReferencia.RemoveAndWallUpdate(this.gameObject);
            }
            if (this.tag == "Enemies")
            {
                gameManager.giveMeReference.GetGold(10);
                gameManager.giveMeReference.EnemyDead();
            }

            Destroy(this.gameObject);
            return;
        }
    }
    IEnumerator SliderTracksCamera()
    {
        while(true)
        {
            Vector3 cameraposition = mainCamera.transform.position;
            healthSlider.transform.LookAt(cameraposition);
            //healthSlider.transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
            yield return new WaitForSeconds(0.05f);
        }
    }
}
