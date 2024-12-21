using System;
using System.Collections.Generic;
using DefaultNamespace.Map;
using UnityEngine;
using UnityEngine.Tilemaps;
using Random = UnityEngine.Random;

namespace Managers
{
    public class MapManager : MonoBehaviour
    {
        public static MapManager Instance;
        
        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }
        
        
        public Map Map { get; private set; }

        [SerializeField] private Tilemap GeneralMap;
        [SerializeField] private Tilemap ResourceMap;
        [SerializeField] private Tilemap UnitsMap;
        
        public List<TileData> TileDataList;
        
        
        public void Initialize()
        {
            Map = new Map();
            Map.Initialize(123, 20, 20);
            SetSprites();
        }

        public void SetSprites()
        {
            foreach (var tile in Map.GeneralMap)
            {
                GeneralMap.SetTile(new Vector3Int(tile.X, tile.Y, 0), GetTileData(tile.Type).Tile);
            }
        }
        
        private TileData GetTileData(TileType type)
        {
            return TileDataList.Find(x => x.Type == type);
        }
    }

    public class Map
    {
        public MapTile[,] GeneralMap { get; private set; }
        public int Width { get; private set; }
        public int Height { get; private set; }
        
        private int _seed;
        
        
        
        public void Initialize(int seed, int width, int height)
        {
            _seed = seed;
            Width = width;
            Height = height;
            GeneralMap = new MapTile[Width, Height];
            
            GeneralRandomMap();
        }
        
        public void GeneralRandomMap()
        {
            Random.InitState(_seed);
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    // random enum type
                    TileType type = (TileType)Random.Range(998, 1004);
                    GeneralMap[x, y] = new MapTile();
                    GeneralMap[x, y].Initialize(x, y, type, GetTileHash(x, y), 0);
                }
            }
        }
        
        
        
        private ulong GetTileHash(int x, int y)
        {
            return (ulong) (x * 1000 + y);
        }
        
    }
    
    public class MapTile
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public TileType Type { get; private set; }
        public ulong TileID { get; private set; }
        public ulong OwnerID { get; private set; }
        
        public void Initialize(int x, int y, TileType type, ulong tileID, ulong ownerID)
        {
            X = x;
            Y = y;
            Type = type;
            TileID = tileID;
            OwnerID = ownerID;
        }
    }

    [Serializable]
    public class TileData
    {
        public TileType Type;
        public TileBase Tile;
    }
}