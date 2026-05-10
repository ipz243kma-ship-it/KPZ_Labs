<?php
error_reporting(E_ALL);
ini_set('display_errors', 1);

class Virus
{
    private float $weight;
    private int $age;
    private string $name;
    private string $type;
    private array $children = []; 

    public function __construct(float $weight, int $age, string $name, string $type) 
    {
        $this->weight = $weight;
        $this->age = $age;
        $this->name = $name;
        $this->type = $type; 
    }

    public function addChild(Virus $child): void
    {
        $this->children[] = $child; 
    }

    public function __clone() 
    {
        foreach ($this->children as $key => $child) {
            $this->children[$key] = clone $child; 
        }
    }

    public function showInfo(int $level = 0): void
    {
        $indent = str_repeat("&nbsp;&nbsp;&nbsp;&nbsp;", $level);

        echo "{$indent}<strong>{$this->name}</strong> ";
        echo "(вид: {$this->type}, вага: {$this->weight}, вік: {$this->age})<br>";

        foreach ($this->children as $child) {
            $child->showInfo($level + 1);
        }
    }
}

echo "<h1>Лабораторна робота №2 — Prototype</h1>";

$grandParent = new Virus(1.5, 10, "Alpha", "Coronavirus");

$parent1 = new Virus(1.2, 5, "Beta", "Coronavirus");
$parent2 = new Virus(1.1, 4, "Gamma", "Coronavirus");

$child1 = new Virus(0.8, 2, "Delta", "Coronavirus");
$child2 = new Virus(0.7, 1, "Omicron", "Coronavirus");
$child3 = new Virus(0.6, 1, "Sigma", "Coronavirus");

$parent1->addChild($child1);
$parent1->addChild($child2);
$parent2->addChild($child3);

$grandParent->addChild($parent1);
$grandParent->addChild($parent2);

echo "<h2>Оригінальне сімейство вірусів:</h2>";
$grandParent->showInfo();

$clonedGrandParent = clone $grandParent;

echo "<h2>Клоноване сімейство вірусів:</h2>";
$clonedGrandParent->showInfo();

?>