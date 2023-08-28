using UnityEngine;
using UnityEngine.SceneManagement;

public class CompleteLevel : MonoBehaviour
{
    private AudioSource finishSFX;
    private Animator animator;
    [SerializeField] private Rigidbody2D player;
    private void Start()
    {
        this.animator = GetComponent<Animator>();
        this.finishSFX = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Complete();   
        }
    }

    private void Complete()
    {
        player.bodyType = RigidbodyType2D.Static;
        finishSFX.Play();
        animator.SetTrigger("finish");
        Invoke("NextLevel", 3f);
    }

    private void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
