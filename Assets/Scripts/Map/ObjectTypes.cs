namespace DefaultNamespace.Map
{
    public enum UnitType
    {
        Attacker,
        Miner
    }
    
    public enum ResourceType
    {
        Red = 1000, //Attacker
        Green = 1001, // Miner
        Blue = 1002, // Engineer
        Yellow = 1003 // Universal
    }
    
    public enum TileType
    {
        RedResource = 1000,
        GreenResource = 1001,
        BlueResource = 1002,
        YellowResource = 1003,
        Empty = 998,
        Obstacle = 999,
        AttackerUnit = 2000,
        MinerUnit = 2001,
        
    }
    
}