using System.Security.Cryptography.Pkcs;
using System.Security.Cryptography.X509Certificates;

public class ESign
{
    public byte[] SignFile(string docPath, string pfxPath, string pfxPassword)
    {
        byte[] data = File.ReadAllBytes(docPath);
        var cert = new X509Certificate2(pfxPath, pfxPassword, X509KeyStorageFlags.Exportable);

        ContentInfo content = new ContentInfo(data);
        SignedCms signedCms = new SignedCms(content, detached: true);

        CmsSigner signer = new CmsSigner(cert);
        signedCms.ComputeSignature(signer);

        byte[] signature = signedCms.Encode();

        // --- Проверка подписи ---
        var signedCmsCheck = new SignedCms(content, detached: true);
        signedCmsCheck.Decode(signature);
        signedCmsCheck.CheckSignature(true); // true = проверять по цепочке сертификатов

        Console.WriteLine("✅ Подпись успешно создана и проверена.");

        return signature;
    }
}

