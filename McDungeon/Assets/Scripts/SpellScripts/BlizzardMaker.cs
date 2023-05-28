using UnityEngine;

namespace McDungeon
{
    public class BlizzardMaker : MonoBehaviour, ISpellMaker
    {
        [SerializeField] private GameObject prefab_blizzard;
        [SerializeField] private GameObject blizzardPosIndicator;
        private float range = 4f;
        private Vector3 spellPos;


        public void ChangeRange(float radius)
        {
            this.range = radius;
        }

        public void Activate()
        {
            blizzardPosIndicator.SetActive(true);
        }

        public void ShowRange(Vector3 posistion, Vector3 mousePos)
        {
            // Recalculate Spell position.
            Debug.Log("Spell Aiming");
            Vector3 distanceVec = (mousePos - posistion);
            distanceVec.z = 0f;
            Vector3 spellDir = distanceVec.normalized;
            float distance = distanceVec.magnitude;

            if (distance > range)
            {
                distance = range;
            }

            spellPos = posistion + spellDir * distance;

            // move indicator
            blizzardPosIndicator.transform.position = spellPos;
        }


        public GameObject Execute(Vector3 posistion, Vector3 mousePos)
        {
            // Turn off indicator.
            blizzardPosIndicator.SetActive(false);

            // Instantiate spell
            Vector3 distanceVec = (mousePos - posistion);
            distanceVec.z = 0f;
            Vector3 spellDir = distanceVec.normalized;
            float distance = distanceVec.magnitude;
            
            if (distance > range)
            {
                distance = range;
            }

            spellPos = posistion + spellDir * distance;

            GameObject blizzard = Instantiate(prefab_blizzard, spellPos, Quaternion.identity);
            blizzard.GetComponent<BlizzardController>().Config(6, 10f, 1f, false, spellDir, 0f);

            return blizzard;
        }
    }
}
