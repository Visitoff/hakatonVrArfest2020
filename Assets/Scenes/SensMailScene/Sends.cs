using UnityEngine;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using UnityEngine.SceneManagement;

public class Sends : MonoBehaviour
{
    string currentEmail;
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    public void ChangeEmail(string email)
    {
        currentEmail = email;
    }

    public void SendTest(Logs log )
    {
        string body = "";
        foreach (var item in log.logs)
        {
            body += string.Format ("{0} \n", item);
        }
       // string body = "Анальный мудрец 2007";//Текст сообщения
        MailMessage message = new MailMessage();
        message.Subject = string.Format("");//Тема сообщения(Заголовок)
        message.Body = body;
        message.From = new MailAddress("kvantoriumtumentest@gmail.com");//От кого
        message.To.Add(currentEmail);//Кому
        message.BodyEncoding = System.Text.Encoding.UTF8;
        SmtpClient client = new SmtpClient();
        client.Host = "smtp.gmail.com";
        client.Port = 587;
        client.Credentials = new NetworkCredential(message.From.Address, "123123123faF");//Логин и пороль
        client.EnableSsl = true;
        ServicePointManager.ServerCertificateValidationCallback = delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            return true;
        };
        client.Send(message);
        Debug.Log("Отправлено");
    }
   
    public void StartScene()
    {
        SceneManager.LoadScene("LoadScreen", LoadSceneMode.Single);
    }
    
}