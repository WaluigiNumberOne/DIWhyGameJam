using System;
using UnityEditor;
using UnityEngine;

namespace Unity.FPS.Game.UpgradeTiles
{
    public class TileGridTester : MonoBehaviour
    {
        public TestTile[] assets;

        [Serializable]
        public struct TestTile
        {
            public TileProperties asset;
            public int x;
            public int y;
        }
        
        private void Start()
        {
            TileGrid grid = GetComponent<TileGrid>();
            
            foreach (TestTile testTile in assets)
            {
                TileProperties tile = Instantiate<TileProperties>(testTile.asset);
                if (!grid.AddTile(tile, testTile.x, testTile.y))
                {
                    Debug.Log("Tile placement failed.");
                }
            }
            
            Debug.Log(grid.ToString());
        }
    }
}