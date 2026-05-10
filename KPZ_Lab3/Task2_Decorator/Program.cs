using System;

public interface IHero
{
    string GetDescription();
    int GetPower();
}

public class Warrior : IHero
{
    public string GetDescription() => "Warrior";
    public int GetPower() => 50;
}

public class Mage : IHero
{
    public string GetDescription() => "Mage";
    public int GetPower() => 40;
}

public class Paladin : IHero
{
    public string GetDescription() => "Paladin";
    public int GetPower() => 45;
}

public abstract class HeroDecorator : IHero
{
    protected IHero _hero;

    public HeroDecorator(IHero hero)
    {
        _hero = hero;
    }

    public virtual string GetDescription() => _hero.GetDescription();
    public virtual int GetPower() => _hero.GetPower();
}

public class Sword : HeroDecorator
{
    public Sword(IHero hero) : base(hero) {}

    public override string GetDescription() => _hero.GetDescription() + " + Sword";
    public override int GetPower() => _hero.GetPower() + 20;
}

public class Armor : HeroDecorator
{
    public Armor(IHero hero) : base(hero) {}

    public override string GetDescription() => _hero.GetDescription() + " + Armor";
    public override int GetPower() => _hero.GetPower() + 15;
}

public class Ring : HeroDecorator
{
    public Ring(IHero hero) : base(hero) {}

    public override string GetDescription() => _hero.GetDescription() + " + Ring";
    public override int GetPower() => _hero.GetPower() + 10;
}

class Program
{
    static void Main()
    {
        IHero hero = new Warrior();

        hero = new Sword(hero);
        hero = new Armor(hero);
        hero = new Ring(hero);

        Console.WriteLine("Hero: " + hero.GetDescription());
        Console.WriteLine("Power: " + hero.GetPower());
    }
}