<?php
error_reporting(E_ALL);
ini_set('display_errors', 1);

class Character
{
    public string $name;
    public string $role;
    public string $height = "";
    public string $bodyType = "";
    public string $hairColor = "";
    public string $eyeColor = "";
    public string $clothes = "";
    public array $inventory = [];
    public array $actions = [];

    public function showInfo(): void
    {
        echo "<h2>{$this->role}: {$this->name}</h2>";
        echo "<p><strong>Зріст:</strong> {$this->height}</p>";
        echo "<p><strong>Статура:</strong> {$this->bodyType}</p>";
        echo "<p><strong>Колір волосся:</strong> {$this->hairColor}</p>";
        echo "<p><strong>Колір очей:</strong> {$this->eyeColor}</p>";
        echo "<p><strong>Одяг:</strong> {$this->clothes}</p>";
        echo "<p><strong>Інвентар:</strong> " . implode(", ", $this->inventory) . "</p>";
        echo "<p><strong>Справи:</strong> " . implode(", ", $this->actions) . "</p>";
    }
}

interface CharacterBuilder
{
    public function setName(string $name): self;
    public function setHeight(string $height): self;
    public function setBodyType(string $bodyType): self;
    public function setHairColor(string $hairColor): self;
    public function setEyeColor(string $eyeColor): self;
    public function setClothes(string $clothes): self;
    public function addInventoryItem(string $item): self;
    public function addAction(string $action): self;
    public function getResult(): Character;
}

class HeroBuilder implements CharacterBuilder
{
    private Character $character;

    public function __construct()
    {
        $this->character = new Character();
        $this->character->role = "Герой";
    }

    public function setName(string $name): self
    {
        $this->character->name = $name;
        return $this;
    }

    public function setHeight(string $height): self
    {
        $this->character->height = $height;
        return $this;
    }

    public function setBodyType(string $bodyType): self
    {
        $this->character->bodyType = $bodyType;
        return $this;
    }

    public function setHairColor(string $hairColor): self
    {
        $this->character->hairColor = $hairColor;
        return $this;
    }

    public function setEyeColor(string $eyeColor): self
    {
        $this->character->eyeColor = $eyeColor;
        return $this;
    }

    public function setClothes(string $clothes): self
    {
        $this->character->clothes = $clothes;
        return $this;
    }

    public function addInventoryItem(string $item): self
    {
        $this->character->inventory[] = $item;
        return $this;
    }

    public function addAction(string $action): self
    {
        $this->character->actions[] = "Добра справа: " . $action;
        return $this;
    }

    public function getResult(): Character
    {
        return $this->character;
    }
}

class EnemyBuilder implements CharacterBuilder
{
    private Character $character;

    public function __construct()
    {
        $this->character = new Character();
        $this->character->role = "Ворог";
    }

    public function setName(string $name): self
    {
        $this->character->name = $name;
        return $this;
    }

    public function setHeight(string $height): self
    {
        $this->character->height = $height;
        return $this;
    }

    public function setBodyType(string $bodyType): self
    {
        $this->character->bodyType = $bodyType;
        return $this;
    }

    public function setHairColor(string $hairColor): self
    {
        $this->character->hairColor = $hairColor;
        return $this;
    }

    public function setEyeColor(string $eyeColor): self
    {
        $this->character->eyeColor = $eyeColor;
        return $this;
    }

    public function setClothes(string $clothes): self
    {
        $this->character->clothes = $clothes;
        return $this;
    }

    public function addInventoryItem(string $item): self
    {
        $this->character->inventory[] = $item;
        return $this;
    }

    public function addAction(string $action): self
    {
        $this->character->actions[] = "Зла справа: " . $action;
        return $this;
    }

    public function getResult(): Character
    {
        return $this->character;
    }
}

class CharacterDirector
{
    public function createDreamHero(CharacterBuilder $builder): Character
    {
        return $builder
            ->setName("Kiaomi")
            ->setHeight("185 см")
            ->setBodyType("Атлетична")
            ->setHairColor("Темне")
            ->setEyeColor("Зелені")
            ->setClothes("Лицарські обладунки")
            ->addInventoryItem("Меч світла")
            ->addInventoryItem("Щит честі")
            ->addInventoryItem("Зілля здоров'я")
            ->addAction("Рятує мирних жителів")
            ->addAction("Захищає королівство")
            ->getResult();
    }

    public function createWorstEnemy(CharacterBuilder $builder): Character
    {
        return $builder
            ->setName("Balaxy")
            ->setHeight("210 см")
            ->setBodyType("Масивна")
            ->setHairColor("Чорне")
            ->setEyeColor("Червоні")
            ->setClothes("Темна броня")
            ->addInventoryItem("Проклятий меч")
            ->addInventoryItem("Книга темної магії")
            ->addInventoryItem("Отрута")
            ->addAction("Руйнує міста")
            ->addAction("Краде артефакти")
            ->getResult();
    }
}

echo "<h1>Лабораторна робота №2 — Builder</h1>";

$director = new CharacterDirector();

$hero = $director->createDreamHero(new HeroBuilder());
$enemy = $director->createWorstEnemy(new EnemyBuilder());

$hero->showInfo();
$enemy->showInfo();
?>