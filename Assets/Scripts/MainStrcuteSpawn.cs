using UnityEngine;
//using Unity.AI.Navigation;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MainStrcuteSpawn : MonoBehaviour
{
    
    private GameObject navMeshUpdater;
    private GameObject canvas;
    private GameObject loadingScreen;
    private bool aviableToSpawn;
    public GameObject rangeIndicator;
    public GameObject aerialNavMesh;

    public GameObject mainCamera;
    public GameObject bottonFix;

    void Start()
    {
        aviableToSpawn = false;
        GetComponent<Health>().healthPoints = 30;
        GetComponent<Rigidbody>().mass = 0.001f;
        navMeshUpdater = GameObject.FindGameObjectWithTag("NavMeshUpdater");
        canvas = GameObject.FindGameObjectWithTag("Canvas");
        loadingScreen = GameObject.FindGameObjectWithTag("LoadingScreen");
        rangeIndicator = GameObject.FindGameObjectWithTag("RangeIndicator");
        rangeIndicator.SetActive(false);
        Invoke("MainStrcuteErrorSpawning", 5f);
        aerialNavMesh = GameObject.Find("AerialNavmeshCube");
        mainCamera = GameObject.Find("Main Camera");
        bottonFix = GameObject.Find("Boton Fix");
    }

    public void MainStrcuteErrorSpawning()
    {
        if(aviableToSpawn == false)
        {
            SceneManager.LoadScene(1);
        }
        
    }
  
    void Update()
    {
        RaycastHit hit1, hit2, hit3, hit4, hit5, hit6, hit7, hit8, hit9;
        if (Physics.Raycast(transform.position, -transform.up, out hit1, 0.4f) &&
            Physics.Raycast(new Vector3(transform.position.x - 1f, transform.position.y, transform.position.z - 1f), -transform.up, out hit2, 0.4f) &&
            Physics.Raycast(new Vector3(transform.position.x + 1f, transform.position.y, transform.position.z - 1f), -transform.up, out hit3, 0.4f) &&
            Physics.Raycast(new Vector3(transform.position.x - 1f, transform.position.y, transform.position.z + 1f), -transform.up, out hit4, 0.4f) &&
            Physics.Raycast(new Vector3(transform.position.x + 1f, transform.position.y, transform.position.z + 1f), -transform.up, out hit5, 0.4f) &&

            Physics.Raycast(new Vector3(transform.position.x + 1f, transform.position.y, transform.position.z + 0f), -transform.up, out hit6, 0.4f) &&
            Physics.Raycast(new Vector3(transform.position.x + 0f, transform.position.y, transform.position.z + 1f), -transform.up, out hit7, 0.4f) &&
            Physics.Raycast(new Vector3(transform.position.x - 1f, transform.position.y, transform.position.z + 0f), -transform.up, out hit8, 0.4f) &&
            Physics.Raycast(new Vector3(transform.position.x + 0f, transform.position.y, transform.position.z - 1f), -transform.up, out hit9, 0.4f))
        {


            if (hit1.collider.CompareTag("Node") &&
                hit2.collider.CompareTag("Node") &&
                hit3.collider.CompareTag("Node") &&
                hit4.collider.CompareTag("Node") &&
                hit5.collider.CompareTag("Node") &&
                hit6.collider.CompareTag("Node") &&
                hit7.collider.CompareTag("Node") &&
                hit8.collider.CompareTag("Node") &&
                hit9.collider.CompareTag("Node"))
            {
                //Ultimo arreglo del generador
                int heightFix = Mathf.FloorToInt(transform.position.y);
                transform.position = new Vector3(transform.position.x, heightFix, transform.position.z);
                navMeshUpdater.GetComponent<NavMeshBake>().doNavMeshBake();

                //Dejar elegante la escena ocultando los nodos
                canvas.GetComponent<BuildMenuButton>().EnableOrDisableBuildPanel();

                this.gameObject.GetComponent<MainStrcuteSpawn>().enabled = false;
                loadingScreen.gameObject.SetActive(false);
                aviableToSpawn = true;

                //RangeIndicator
                rangeIndicator.gameObject.SetActive(true);

                //AerialNavMesh
                aerialNavMesh.GetComponent<MeshRenderer>().enabled = false;

                //rigibody
                Invoke("IsKinematicDisabled", 2);

            }
           
        }
        
      

    }

    private void IsKinematicDisabled()
    {
        GetComponent<Rigidbody>().isKinematic = true;
        mainCamera.GetComponent<CameraMovement>().enabled = true;
        bottonFix.GetComponent<BotonOpcionesFix>().enabled = true;
    }
    
}

