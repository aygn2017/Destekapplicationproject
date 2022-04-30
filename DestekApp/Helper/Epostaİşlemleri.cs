using System.Text;

namespace DestekApp.Helper
{
    public class Epostaİşlemleri
    {


        public static void AktivasyonMailiGonder(string alici)
        {
            System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
            mail.To.Add(alici);
            mail.From = new System.Net.Mail.MailAddress("fbuyazilim@gmail.com");
            mail.Subject = "Destek App Kullanıcı Aktivasyonu";
            mail.SubjectEncoding = System.Text.Encoding.UTF8;

            string linkk = "https://localhost:44357/Hesap/EpostaAktivasyon?kkk=" + Şifreleme.Sifrele(alici);


            var HtmlBody = new StringBuilder();
            HtmlBody.AppendFormat("Hoşgeldiniz , {0}\n", "Sevgili Kullanıcımız");
            HtmlBody.AppendLine(@"Hesabınızı aktive etmek için aşağıdaki bağlantıya tıklayın.");
            HtmlBody.AppendLine("<a href=\"" + linkk + "\">AKTİVASYON</a>");
            mail.Body = HtmlBody.ToString();
            mail.BodyEncoding = System.Text.Encoding.UTF8;
            mail.IsBodyHtml = true;
            mail.Priority = System.Net.Mail.MailPriority.High;

            System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient();
            client.Credentials = new System.Net.NetworkCredential("fbuyazilim@gmail.com", "Sifre123!");
            client.Port = 587;   /* 587 / 465*/
            client.Host = "smtp.gmail.com";
            client.EnableSsl = true;
            try
            {
                client.Send(mail);

            }
            catch (Exception ex)
            {
                Exception ex2 = ex;
                string errorMessage = string.Empty;
                while (ex2 != null)
                {
                    errorMessage += ex2.ToString();
                    ex2 = ex2.InnerException;
                }
            }
        }

        public static void ŞifremiUnuttumMaili(string alici)
        {
            System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
            mail.To.Add(alici);
            mail.From = new System.Net.Mail.MailAddress("fbuyazilim@gmail.com");
            mail.Subject = "Destek App Şifre Sıfırlama";
            mail.SubjectEncoding = System.Text.Encoding.UTF8;


            string epostaKapalı = Şifreleme.Sifrele(alici);

            string linkk = "https://localhost:44357/Hesap/ŞifreSıfırla?xrtt="+epostaKapalı;


            var HtmlBody = new StringBuilder();
            HtmlBody.AppendFormat("Hoşgeldiniz , {0}\n", "Sevgili Kullanıcımız");
            HtmlBody.AppendLine(@"Şifrenizi sıfırlamak için aşağıdaki bağlantıya tıklayın.");
            HtmlBody.AppendLine("<a href=\"" + linkk + "\">ŞİFRE SIFIRLA</a>");
            mail.Body = HtmlBody.ToString();
            mail.BodyEncoding = System.Text.Encoding.UTF8;
            mail.IsBodyHtml = true;
            mail.Priority = System.Net.Mail.MailPriority.High;

            System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient();
            client.Credentials = new System.Net.NetworkCredential("fbuyazilim@gmail.com", "Sifre123!");
            client.Port = 587;   /* 587 / 465*/
            client.Host = "smtp.gmail.com";
            client.EnableSsl = true;
            try
            {
                client.Send(mail);

            }
            catch (Exception ex)
            {
                Exception ex2 = ex;
                string errorMessage = string.Empty;
                while (ex2 != null)
                {
                    errorMessage += ex2.ToString();
                    ex2 = ex2.InnerException;
                }
            }
        }
    }
}
