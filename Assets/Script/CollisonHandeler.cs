using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisonHandeler : MonoBehaviour
{

    [SerializeField] float timeLevel = 1f;
    [SerializeField] AudioClip crash;
    [SerializeField] AudioClip succses;

    [SerializeField] ParticleSystem crashPartical;
    [SerializeField] ParticleSystem succsesPartical;

    
    AudioSource audioSource;

    
    
    bool isTransitioning = false;

    void Start() 
    {
        audioSource = GetComponent<AudioSource>();
    }


    // what happen with collison and success
    void OnCollisionEnter(Collision other) 
    {

        if(isTransitioning) { return; }

        switch(other.gameObject.tag)
        {
            case "friend":
                Debug.Log("this thing is friendly");
                break;
            case "Finish":
                SuccesSequence();
                break;
            default:
                StartCrashSequence();
                break;
    

        }
    }

    void StartCrashSequence()
    {
        isTransitioning = true;
        audioSource.Stop();
        audioSource.PlayOneShot(crash);
        crashPartical.Play();

        GetComponent<Movment>().enabled = false;
        Invoke("ReloadLevel", timeLevel);
    }

    void SuccesSequence()
    {
        isTransitioning = true;
        audioSource.Stop();
        audioSource.PlayOneShot(succses);
        succsesPartical.Play();

        GetComponent<Movment>().enabled = false;
        Invoke("LoadnextLevel", timeLevel);
    }



    void ReloadLevel() {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
    void LoadnextLevel() {

        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nexSceneIndex = currentSceneIndex + 1;
        if( nexSceneIndex == SceneManager.sceneCountInBuildSettings )
        {
            nexSceneIndex = 0;
        }
        SceneManager.LoadScene(nexSceneIndex);
    }

}
