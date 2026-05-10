<?php
error_reporting(E_ALL);
ini_set('display_errors', 1);

interface Laptop
{
    public function getInfo(): string;
}

interface Netbook
{
    public function getInfo(): string;
}

interface EBook
{
    public function getInfo(): string;
}

interface Smartphone
{
    public function getInfo(): string;
}

class IProneLaptop implements Laptop
{
    public function getInfo(): string
    {
        return "IProne Laptop - потужний ноутбук для роботи";
    }
}

class IProneNetbook implements Netbook
{
    public function getInfo(): string
    {
        return "IProne Netbook - компактний нетбук для навчання";
    }
}

class IProneEBook implements EBook
{
    public function getInfo(): string
    {
        return "IProne EBook - електронна книга з підсвіткою";
    }
}

class IProneSmartphone implements Smartphone
{
    public function getInfo(): string
    {
        return "IProne Smartphone - преміальний смартфон";
    }
}

class KiaomiLaptop implements Laptop
{
    public function getInfo(): string
    {
        return "Kiaomi Laptop - збалансований ноутбук";
    }
}

class KiaomiNetbook implements Netbook
{
    public function getInfo(): string
    {
        return "Kiaomi Netbook - доступний нетбук";
    }
}

class KiaomiEBook implements EBook
{
    public function getInfo(): string
    {
        return "Kiaomi EBook - електронна книга для читання";
    }
}

class KiaomiSmartphone implements Smartphone
{
    public function getInfo(): string
    {
        return "Kiaomi Smartphone - функціональний смартфон";
    }
}

class BalaxyLaptop implements Laptop
{
    public function getInfo(): string
    {
        return "Balaxy Laptop - ноутбук для мультимедіа";
    }
}

class BalaxyNetbook implements Netbook
{
    public function getInfo(): string
    {
        return "Balaxy Netbook - легкий нетбук";
    }
}

class BalaxyEBook implements EBook
{
    public function getInfo(): string
    {
        return "Balaxy EBook - зручна електронна книга";
    }
}

class BalaxySmartphone implements Smartphone
{
    public function getInfo(): string
    {
        return "Balaxy Smartphone - сучасний смартфон";
    }
}

interface DeviceFactory
{
    public function createLaptop(): Laptop; //
    public function createNetbook(): Netbook;
    public function createEBook(): EBook;
    public function createSmartphone(): Smartphone;
}

class IProneFactory implements DeviceFactory
{
    public function createLaptop(): Laptop
    {
        return new IProneLaptop();
    }

    public function createNetbook(): Netbook
    {
        return new IProneNetbook();
    }

    public function createEBook(): EBook
    {
        return new IProneEBook();
    }

    public function createSmartphone(): Smartphone
    {
        return new IProneSmartphone();
    }
}

class KiaomiFactory implements DeviceFactory
{
    public function createLaptop(): Laptop
    {
        return new KiaomiLaptop();
    }

    public function createNetbook(): Netbook
    {
        return new KiaomiNetbook();
    }

    public function createEBook(): EBook
    {
        return new KiaomiEBook();
    }

    public function createSmartphone(): Smartphone
    {
        return new KiaomiSmartphone();
    }
}

class BalaxyFactory implements DeviceFactory
{
    public function createLaptop(): Laptop
    {
        return new BalaxyLaptop();
    }

    public function createNetbook(): Netbook
    {
        return new BalaxyNetbook();
    }

    public function createEBook(): EBook
    {
        return new BalaxyEBook();
    }

    public function createSmartphone(): Smartphone
    {
        return new BalaxySmartphone();
    }
}
function showDevices(DeviceFactory $factory, string $brandName): void
{
    echo "<h2>Бренд: {$brandName}</h2>";

    $laptop = $factory->createLaptop();
    $netbook = $factory->createNetbook();
    $ebook = $factory->createEBook();
    $smartphone = $factory->createSmartphone();

    echo "<ul>";
    echo "<li>" . $laptop->getInfo() . "</li>";
    echo "<li>" . $netbook->getInfo() . "</li>";
    echo "<li>" . $ebook->getInfo() . "</li>";
    echo "<li>" . $smartphone->getInfo() . "</li>";
    echo "</ul>";
}
echo "<h1>Лабораторна робота №2 — Abstract Factory</h1>";

showDevices(new IProneFactory(), "IProne");
showDevices(new KiaomiFactory(), "Kiaomi");
showDevices(new BalaxyFactory(), "Balaxy");
?>