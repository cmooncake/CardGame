public class Card
{
    public int Id { get; set; }
    public string Name { get; set; }

    public string Story { get; set; }

    public Card(int id, string name, string story)
    {
        Id = id;
        Name = name;
        Story = story;
    }
}

public class MonsterCard:Card
{
    public int Attack;
    public int Healthpoint;
    public int HealthpointMax;

    public MonsterCard(int id, string name, string story, int attack, int healthmax):base(id,name, story)
    {
        Attack = attack;
        Healthpoint = healthmax;   
        HealthpointMax = healthmax;
    }
}

public class SpellCard : Card
{
    public string Effect { get; set; }

    public SpellCard(int id, string name, string story, string effect): base(id, name, story)
    {
        Effect = effect;
    }
}