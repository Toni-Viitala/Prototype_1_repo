using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController_3 : MonoBehaviour
{   
    public StatsManager statsManager;
    public GameObject gameOverPanel;


    private Rigidbody playerRb;
    private Animator playerAnim;
    private AudioSource playerAudio;

    // We take the position and rotation of the player in Start() for SpawnManager.
    public Vector3 initialPosition;
    public Quaternion initialRotation;

    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;

    public AudioClip jumpSound;
    public AudioClip crashSound;

    public float jumpForce;
    public float gravityModifier;


    public bool isOnGround = true;

    public bool restart = false;
    public bool gameOver = false;


    void Start()
    {
        Time.timeScale = 0; // When game starts we set the time to be zero. (Since all the components are loaded under the canvas.) 
                            // The game is then started from a button which uses the GameStart()-method which sets the time to be 1.

        playerAudio = GetComponent<AudioSource>();
        playerAnim = GetComponent<Animator>();
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;

        initialPosition = transform.position;
        initialRotation = transform.rotation;
    }

   
    void Update()  // All of the funcionality inside the Update() were made during the tutorials.
    {
        if (Input.GetKeyDown(KeyCode.Space) &&  isOnGround && !gameOver)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            playerAnim.SetTrigger("Jump_trig");

            playerAudio.PlayOneShot(jumpSound, 1f);

            dirtParticle.Stop();
        }
    }

    public void GameStart()     // GameStart() is called in UI by the StartButton (OnClickEvent)
    {
        Time.timeScale = 1;
    }

    public void QuitGame()      // QuitGame() is called in UI by the QuitButton (OnClickEvent)
    {
        Debug.Log("QUIT!");

        //Application.Quit();     // Not used since the game is not expected to be built.
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            dirtParticle.Play();
        }

        if (collision.gameObject.CompareTag("Obstacle")  && statsManager.playerLives > 1)
        {

            Debug.Log("Player hit an obstacle");

            statsManager.playerLives --;

            playerAudio.PlayOneShot(crashSound, 1f);
            explosionParticle.Play(); 
        }


        else if (collision.gameObject.CompareTag("Obstacle") && statsManager.playerLives == 1)
        {
            statsManager.playerLives= 0;

            Debug.Log("Game over!");
            gameOver = true;

            playerAudio.PlayOneShot(crashSound, 1f);
            dirtParticle.Stop();
            explosionParticle.Play();
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);  

            if(gameOver == true)    // We wait for 5 seconds after the gameOver condition is true for the animations to play.
            {
                Invoke("activateGameOverPanel", 5); // Then invoke.
            }
        }
    }
    public void activateGameOverPanel() // For invocation if gameOver = true.
    {
        gameOverPanel.SetActive(true); 
    }

    public void ReloadCurrentScene()    // This method is used by the ReturnButton (OnClickEvent) in the GameOverPanel, restarting the scene.
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }

}
