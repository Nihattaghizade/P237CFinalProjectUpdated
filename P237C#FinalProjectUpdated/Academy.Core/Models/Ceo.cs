namespace Academy.Core.Models
{
    public  class Ceo
    {
        public string Name { get; } = "Nihat";
        public string SurName { get; } = "Taghizade";
        public string FullName => $"{Name} {SurName}";
        public string Username { get; } = "Nihattt";
        public string Password { get; } = "Nihat123";
        
    }
}
