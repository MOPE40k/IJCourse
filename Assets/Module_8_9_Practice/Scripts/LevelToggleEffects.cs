using UnityEngine;

public class LevelToggleEffects : MonoBehaviour
{
    [SerializeField] private ParticleSystem[] _particles;

    [SerializeField] private Animator[] _animators;

    private void Start()
    {
        FindAllParticles();
        FindAllAnimators();

        StopParticles();
        StopEffects();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            StartParticles();
            StartEffects();
        }
    }

    private void StartParticles()
    {
        foreach (ParticleSystem particle in _particles)
            particle.Play();
    }

    private void StopParticles()
    {
        foreach (ParticleSystem particle in _particles)
            particle.Stop();
    }

    private void StartEffects()
    {
        foreach (Animator animator in _animators)
            animator.enabled = true;
    }

    private void StopEffects()
    {
        foreach (Animator animator in _animators)
            animator.enabled = false;
    }

    private void FindAllParticles()
    {
        _particles = FindObjectsOfType<ParticleSystem>();
    }

    private void FindAllAnimators()
    {
        _animators = FindObjectsOfType<Animator>();
    }
}
