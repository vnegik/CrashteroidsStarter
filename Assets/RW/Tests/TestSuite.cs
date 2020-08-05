using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

namespace Tests
{
    public class TestSuite : GeneralTest
    {
        [UnityTest]
        public IEnumerator AsteroidsMoveDown()
        {
            // 2
            // 3
            GameObject asteroid = game.GetSpawner().SpawnAsteroid();
            // 4
            float initialYPos = asteroid.transform.position.y;
            // 5
            yield return new WaitForSeconds(0.1f);
            // 6
            Assert.Less(asteroid.transform.position.y, initialYPos);
            // 7
            //Object.Destroy(game.gameObject);
        }

        [UnityTest]
        public IEnumerator GameOverOccursOnAsteroidCollision()
        {
            GameObject asteroid = game.GetSpawner().SpawnAsteroid();
            //1
            asteroid.transform.position = game.GetShip().transform.position;
            //2
            yield return new WaitForSeconds(0.1f);

            //3
            Assert.True(game.isGameOver);
        }

        [UnityTest]
        public IEnumerator NewGameRestartsGame()
        {
            //1
            game.isGameOver = true;
            game.NewGame();
            //2
            Assert.False(game.isGameOver);
            yield return null;
        }

        [UnityTest]
        public IEnumerator LaserMovesUp()
        {
            // 1
            GameObject laser = game.GetShip().SpawnLaser();
            // 2
            float initialYPos = laser.transform.position.y;
            yield return new WaitForSeconds(0.1f);
            // 3
            Assert.Greater(laser.transform.position.y, initialYPos);
        }

        [UnityTest]
        public IEnumerator LaserDestroysAsteroid()
        {
            // 1
            GameObject asteroid = game.GetSpawner().SpawnAsteroid();
            asteroid.transform.position = Vector3.zero;
            GameObject laser = game.GetShip().SpawnLaser();
            laser.transform.position = Vector3.zero;
            yield return new WaitForSeconds(0.1f);
            // 2
            UnityEngine.Assertions.Assert.IsNull(asteroid);
        }

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