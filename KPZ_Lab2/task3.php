<?php
error_reporting(E_ALL);
ini_set('display_errors', 1);

class Authenticator
{
    private static ?Authenticator $instance = null;

    private function __construct()
    {
        echo "Authenticator створено<br>";
    }

    private function __clone() {}

    public function __wakeup()
    {
        throw new Exception("Cannot !!!unserialize singleton"); 
    }

    public static function getInstance(): Authenticator
    {
        if (self::$instance === null) {
            self::$instance = new Authenticator();
        }

        return self::$instance; 
    }

    public function login(string $user): void
    {
        echo "Користувач {$user} увійшов у систему<br>";
    }
}
echo "<h1>Singleton: Authenticator</h1>";

$auth1 = Authenticator::getInstance();
$auth2 = Authenticator::getInstance();

$auth1->login("Макс");
$auth2->login("Іван");

if ($auth1 === $auth2) {
    echo "<b>Це один і той самий екземпляр!</b>";
} else { 
    echo "<b>Це різні об’єкти!</b>"; 
}
?>  