using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Windows;
using System.IO;


namespace WpfNutWatch
{
    class FTPClass
    {
        FtpWebResponse ftpResponse;

        public void apagar_ficheiro(String arq, String ftp, String username, String password, String nome_pasta)
        {
            try
            {
                string ftpfullpath = ftp + nome_pasta + arq;
                FtpWebRequest requestFileDelete = (FtpWebRequest)WebRequest.Create(ftpfullpath);
                requestFileDelete.Credentials = new NetworkCredential(username, password);
                requestFileDelete.Method = WebRequestMethods.Ftp.DeleteFile;
                FtpWebResponse responseFileDelete = (FtpWebResponse)requestFileDelete.GetResponse();
            }
            catch (WebException webex)
            {
                MessageBox.Show(webex.ToString());
            }

        }

        public String getfolderfile(String nomeDef, String especie)
        {
            string filename = "";
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();

            dlg.DefaultExt = ".jpg";

            dlg.Title = "Insira uma imagem para a folha do(a) " + especie + " com deficiencia de " + nomeDef;

            dlg.Filter = "All Images| *.BMP;*.DIB;*.RLE;*.JPG;*.JPEG;*.JPE;*.JFIF;*.GIF;*.TIF;*.TIFF;*.PNG";

            Nullable<bool> result = dlg.ShowDialog();

            if (result == true)
            {
                filename = dlg.FileName;
            }

            return filename;
        }

        public void criar_diretoria(String ftp, String username, String password, String nome_pasta)
        {
            //define os requesitos para se conectar com o servidor
            try
            {
                MessageBox.Show(nome_pasta);
                FtpWebRequest ftpRequest = (FtpWebRequest)FtpWebRequest.Create(new Uri(ftp + nome_pasta));
                ftpRequest.Proxy = null;
                ftpRequest.UseBinary = true;
                ftpRequest.Credentials = new NetworkCredential(username, password);
                ftpRequest.Method = WebRequestMethods.Ftp.MakeDirectory;
                FtpWebResponse CreateForderResponse = (FtpWebResponse)ftpRequest.GetResponse();
                MessageBox.Show(nome_pasta);

            }
            catch (WebException webex)
            {
                //MessageBox.Show("Não é possivel inserir duas especies com o mesmo nome");
                MessageBox.Show(webex.Message);
            }
        }

        public void upload(String arq, String ftp, String username, String password, String path, String nome_pasta)
        {
            try
            {
                FtpWebRequest ftpRequest = (FtpWebRequest)FtpWebRequest.Create(new Uri(ftp + nome_pasta + "/" + path));
                ftpRequest.Method = WebRequestMethods.Ftp.UploadFile;
                ftpRequest.Proxy = null;
                ftpRequest.UseBinary = true;
                ftpRequest.Credentials = new NetworkCredential(username, password);

                //Seleção do arquivo a ser enviado
                FileInfo arquivo = new FileInfo(arq);
                byte[] fileContents = new byte[arquivo.Length];

                using (FileStream fr = arquivo.OpenRead())
                {
                    fr.Read(fileContents, 0, Convert.ToInt32(arquivo.Length));
                }

                using (Stream writer = ftpRequest.GetRequestStream())
                {
                    writer.Write(fileContents, 0, fileContents.Length);
                }

                //obtem o FtpWebResponse da operação de upload
                ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();
                MessageBox.Show(ftpResponse.StatusDescription);
            }
            catch (WebException webex)
            {
                MessageBox.Show(webex.ToString());
            }
        }
    }
}
