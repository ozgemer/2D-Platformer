using UnityEngine;
using UnityEngine.UI;

public class ItemCollect : MonoBehaviour
{
    private int pineapples = 0;
    [SerializeField] private Text pineapplesCount;
    [SerializeField] private AudioSource collectSFX;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Pineapple"))
        {
            pineapples++;
            pineapplesCount.text = pineapples.ToString();
            Destroy(collision.gameObject);
            collectSFX.Play();
        }
    }
}
