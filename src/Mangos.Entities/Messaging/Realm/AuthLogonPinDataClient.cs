namespace Mangos.Entities.Messaging.Realm;

public class AuthLogonPinDataClient
{
    public byte[] salt = new byte[16];
    public byte[] hash = new byte[20];
}