public class NotificationManager
{
    public delegate void NotificationDelegate(string message);

    public void Notifier(string message)
    {
        Console.WriteLine(message);
    }

    public void AffichageNotification(string message){
        NotificationDelegate method;
        method = Notifier;
        method(message);

    }
}