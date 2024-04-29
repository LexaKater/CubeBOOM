using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField, Range(0, 5)] private float _explosionForce;
    [SerializeField] private ClickReader _click;
    [SerializeField] private ParticleSystem _effect;

    private void OnEnable() => _click.MousePressed += Explode;

    private void OnDisable() => _click.MousePressed -= Explode;

    private void Explode()
    {
        Instantiate(_effect, transform.position, transform.rotation);

        foreach (Rigidbody explodableObject in GetExplodedObjects())
            explodableObject.AddExplosionForce(_explosionForce, transform.position, transform.localScale.x);
    }

    private IEnumerable<Rigidbody> GetExplodedObjects()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, transform.localScale.x);

        foreach (Collider hit in hits)
        {
            if (hit.attachedRigidbody != null)
                yield return hit.attachedRigidbody;
        }
    }
}