using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private Vector3 _explosionForce;
    [SerializeField] private ParticleSystem _effect;

    public void Explode(Rigidbody cube)
    {
        cube.velocity = _explosionForce;
        Instantiate(_effect, cube.transform.position, cube.transform.rotation);
    }

    public void Explode(Rigidbody cube, float explosForce, float explosRadius)
    {
        Instantiate(_effect, cube.transform.position, cube.transform.rotation);

        foreach (Rigidbody explodableObject in GetExplodedObjects(cube.transform.position, explosRadius))
            explodableObject.AddExplosionForce(explosForce, cube.transform.position, explosRadius);
    }

    private IEnumerable<Rigidbody> GetExplodedObjects(Vector3 position, float radius)
    {
        Collider[] hits = Physics.OverlapSphere(position, radius);

        foreach (Collider hit in hits)
        {
            if (hit.attachedRigidbody != null)
                yield return hit.attachedRigidbody;
        }
    }
}