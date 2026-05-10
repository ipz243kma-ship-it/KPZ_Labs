<?php
error_reporting(E_ALL);
ini_set('display_errors', 1);

interface Subscription
{
    public function getName(): string;
    public function getMonthlyFee(): float;
    public function getMinimumPeriod(): int;
    public function getChannels(): array;
    public function getFeatures(): array;
    public function showInfo(): void;
}

abstract class BaseSubscription implements Subscription
{
    protected string $name;
    protected float $monthlyFee;
    protected int $minimumPeriod;
    protected array $channels;
    protected array $features;

    public function getName(): string
    {
        return $this->name;
    }

    public function getMonthlyFee(): float
    {
        return $this->monthlyFee;
    }

    public function getMinimumPeriod(): int
    {
        return $this->minimumPeriod;
    }

    public function getChannels(): array
    {
        return $this->channels;
    }

    public function getFeatures(): array
    {
        return $this->features;
    }

    public function showInfo(): void
    {
        echo "<h3>{$this->getName()}</h3>";
        echo "<p><strong>Щомісячна плата:</strong> {$this->getMonthlyFee()} грн</p>";
        echo "<p><strong>Мінімальний період:</strong> {$this->getMinimumPeriod()} міс.</p>";
        echo "<p><strong>Канали:</strong> " . implode(", ", $this->getChannels()) . "</p>";
        echo "<p><strong>Можливості:</strong> " . implode(", ", $this->getFeatures()) . "</p>";
    }
}

class DomesticSubscription extends BaseSubscription
{
    public function __construct()
    {
        $this->name = "Domestic Subscription";
        $this->monthlyFee = 199;
        $this->minimumPeriod = 1;
        $this->channels = ["1+1", "ICTV", "СТБ", "Новий канал"];
        $this->features = ["Базова якість", "Доступ на 1 пристрої"];
    }
}

class EducationalSubscription extends BaseSubscription
{
    public function __construct()
    {
        $this->name = "Educational Subscription";
        $this->monthlyFee = 149;
        $this->minimumPeriod = 6;
        $this->channels = ["Discovery", "National Geographic", "History"];
        $this->features = ["Освітній контент", "Архів передач", "Доступ на 2 пристроях"];
    }
}

class PremiumSubscription extends BaseSubscription
{
    public function __construct()
    {
        $this->name = "Premium Subscription";
        $this->monthlyFee = 399;
        $this->minimumPeriod = 12;
        $this->channels = ["HBO", "Netflix Channel", "Eurosport", "Discovery"];
        $this->features = ["Ultra HD", "Без реклами", "Доступ на 5 пристроях", "Преміум-підтримка"];
    }
}

abstract class SubscriptionCreator
{
    abstract public function createSubscription(): Subscription;

    public function buySubscription(): void
    {
        $subscription = $this->createSubscription();

        echo "<div style='border:1px solid #999; padding:12px; margin:12px 0;'>";
        echo "<h2>Оформлення через " . static::class . "</h2>";
        $subscription->showInfo();
        echo "</div>";
    }
}

class WebSite extends SubscriptionCreator
{
    public function createSubscription(): Subscription
    {
        return new DomesticSubscription();
    }
}

class MobileApp extends SubscriptionCreator
{
    public function createSubscription(): Subscription
    {
        return new EducationalSubscription();
    }
}

class ManagerCall extends SubscriptionCreator
{
    public function createSubscription(): Subscription
    {
        return new PremiumSubscription();
    }
}

echo "<h1>Лабораторна робота №2 — Factory Method</h1>";

$website = new WebSite();
$mobileApp = new MobileApp();
$managerCall = new ManagerCall();

$website->buySubscription();
$mobileApp->buySubscription();
$managerCall->buySubscription();
?>