namespace DefaultNamespace
{
    public struct UnitStats
    {
        // Attacker & Miner stats
        public float Health { get; private set; }
        public float Damage { get; private set; }
        public float Cooldown { get; private set; }
        public float Range { get; private set; }
        // There are more stats that can be added here (fore new units, etc.)
        
        public UnitStats(float health, float damage, float cooldown, float range)
        {
            Health = health;
            Damage = damage;
            Cooldown = cooldown;
            Range = range;
        }
        
        public UnitStats DefaultAttackerStats()
        {
            return new UnitStats(100, 10, 1, 1);
        }
        public UnitStats DefaultMinerStats()
        {
            return new UnitStats(100, 10, 1, 1);
        }
        
        
    }
}