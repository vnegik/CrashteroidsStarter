using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

namespace Tests
{
    public class TheSecondTestScript : GeneralTest
    {
        [UnityTest]
        public IEnumerator DestroyedAsteroidRaisesScore()
        {
            // 1
            GameObject asteroid = game.GetSpawner().SpawnAsteroid();
            asteroid.transform.position = Vector3.zero;
            GameObject laser = game.GetShip().SpawnLaser();
            laser.transform.position = Vector3.zero;
            yield return new WaitForSeconds(0.1f);
            // 2
            Assert.AreEqual(game.score, 1);
        }
    }
}
