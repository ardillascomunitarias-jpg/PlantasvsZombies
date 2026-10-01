using UnityEngine;

public class Sun : MonoBehaviour
{
    [SerializeField]
    private int value;
    public int Value => value;
    [SerializeField]
    private GameObject sunParticles;
    [SerializeField]
    private string collectSound;
    private Animator Animator;
    private void Awake()
    {
        Animator = GetComponent<Animator>();
    }
    private void OnEnable()
    {
        Animator.Play("Appear", 0, 0f);
    }
    public void Collect()
    {
        SoundManager.instance.Play(collectSound);
        PoolManager.Instance.GetObject(sunParticles, transform.position);
        gameObject.SetActive(false);
    }
}
