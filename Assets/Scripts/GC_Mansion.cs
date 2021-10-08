using UnityEngine;

public class GC_Mansion : MonoBehaviour
{
    public bool lockDoor01_open;
    private AudioSource mainMus;
    public AudioClip mus_school;
    public MeshRenderer lockDoor01;
    public Material SwingDoor60;
    public Material button_click;
    public DialogeSystem dialogeSystem;

    void Start()
    {
        if (GameObject.FindGameObjectWithTag("MainMus") == null)
        {
            mainMus = new GameObject().AddComponent<AudioSource>();
            mainMus.gameObject.name = "MainMus";
            mainMus.gameObject.tag = "MainMus";
            mainMus.pitch = 0.1f;
            mainMus.volume = 0.7f;
            mainMus.loop = true;
            mainMus.clip = mus_school;
            mainMus.Play();
            DontDestroyOnLoad(mainMus);
        }

        else
        {
            mainMus = GameObject.FindGameObjectWithTag("MainMus").GetComponent<AudioSource>();
        }
    }

    void Update()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.name == "Button_opendoor01" & Vector3.Distance(GameObject.FindGameObjectWithTag("Player").transform.position, hit.transform.position) < 10f & !lockDoor01_open)
                {
                    lockDoor01_open = true;
                    Material[] mat = new Material[3];
                    mat[0] = lockDoor01.materials[0];
                    mat[1] = lockDoor01.materials[1];
                    mat[2] = SwingDoor60;
                    lockDoor01.materials = mat;
                    hit.transform.GetComponent<MeshRenderer>().material = button_click;
                    Hover hover = hit.transform.GetComponent<Hover>();
                    hover.MouseExit();
                    Destroy(hover);
                    dialogeSystem.StartDialoge(1);
                }
            }
        }
    }

    public void FallDown()
    {
        
    }
}