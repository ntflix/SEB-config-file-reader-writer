using System.Security.Cryptography.X509Certificates;
using DictObj = System.Collections.Generic.Dictionary<string, object>;

public static class Main
{
    // Prefixes
    private const int PREFIX_LENGTH = 4;
    private const int MULTIPART_LENGTH = 8;
    private const int CUSTOMHEADER_LENGTH = 4;
    private const string PUBLIC_KEY_HASH_MODE = "pkhs";
    private const string PUBLIC_SYMMETRIC_KEY_MODE = "phsk";
    private const string PASSWORD_MODE = "pswd";
    private const string PLAIN_DATA_MODE = "plnd";
    private const string PASSWORD_CONFIGURING_CLIENT_MODE = "pwcc";
    private const string UNENCRYPTED_MODE = "<?xm";
    private const string MULTIPART_MODE = "mphd";
    private const string CUSTOM_HEADER_MODE = "cmhd";

    // Public key hash identifier length
    private const int PUBLIC_KEY_HASH_LENGTH = 20;
    public static void main()
    {
        string fileName = "<.seb config file path>";
        bool forEditing = false;
        string filePassword = "";
        bool passwordIsHash = false;
        X509Certificate2 fileCertificateRef = null;
        var settings = SEBSettings.ReadSebConfigurationFile(fileName, forEditing, ref filePassword, ref passwordIsHash, ref fileCertificateRef);
        // WriteSebConfigurationFile(String fileName, string filePassword, bool passwordIsHash, X509Certificate2 fileCertificateRef, bool useAsymmetricOnlyEncryption, SEBSettings.sebConfigPurposes configPurpose, bool forEditing = false)
        SEBSettings.WriteSebConfigurationFile(fileName + ".new.seb", filePassword, passwordIsHash, fileCertificateRef, false, SEBSettings.sebConfigPurposes.sebConfigPurposeStartingExam, false);
        Console.WriteLine("Written to " + fileName + ".new.seb");
    }
}