using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace McDungeon
{
    public class MageSpellController : MonoBehaviour
    {
        [SerializeField]
        private int spellSpeed = 500;
        [SerializeField]
        private EffectTypes type;
        private int damage = 1;
        private float knockbackDuration;
        void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "PlayerHitbox")
            {
                Vector2 location = this.transform.position;
                Vector2 playerLocation = collision.transform.position;
                var deltaLocation = playerLocation - location;
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(deltaLocation * spellSpeed);
                collision.gameObject.GetComponent<PlayerController>().TakeDamage(damage, this.type);
                Destroy(this.gameObject);
            }
            if (collision.gameObject.tag != "Throwable")
            {
                Destroy(this.gameObject);
            }
            

        }

        public void Cast(Vector2 playerLocation, EffectTypes type)
        {
            this.type = type;
            Vector2 location = this.transform.position;
            var deltaLocation = playerLocation - location;
            deltaLocation.Normalize();
            this.gameObject.GetComponent<Rigidbody2D>().AddForce(deltaLocation * spellSpeed);
            Destroy(this.gameObject, 3);
        }
    }
}