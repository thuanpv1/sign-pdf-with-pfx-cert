using iTextSharp.text.pdf;
using iTextSharp.text.pdf.security;
using Org.BouncyCastle.X509;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using X509Certificate = Org.BouncyCastle.X509.X509Certificate;

namespace sign_pdf_with_pfx_cert
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        public string SignPDF(string pdfPath, string pfxPath, string pfxPassword,  int locationx, int locationy, int numPage)
        {
            byte[] bytes = File.ReadAllBytes(pdfPath);
            string strRe = "";
            try
            {
                //Initialize the Windows store.
                X509Store store = new X509Store(StoreName.My, StoreLocation.CurrentUser);
                //store.Open(OpenFlags.ReadOnly | OpenFlags.OpenExistingOnly);

                X509Certificate2 certClient = null;
                certClient = new X509Certificate2(File.ReadAllBytes(pfxPath), pfxPassword, X509KeyStorageFlags.Exportable);


                //Get Cert Chain
                IList<X509Certificate> chain = new List<X509Certificate>();
                X509Chain x509Chain = new X509Chain();

                x509Chain.Build(certClient);

                foreach (X509ChainElement x509ChainElement in x509Chain.ChainElements)
                {
                    chain.Add(Org.BouncyCastle.Security.DotNetUtilities.FromX509Certificate(x509ChainElement.Certificate));
                }

                string dtn = DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString();
                System.IO.FileStream stream = new FileStream(@".\" + dtn + ".pdf", FileMode.CreateNew);
                System.IO.BinaryWriter writer = new BinaryWriter(stream);
                writer.Write(bytes, 0, bytes.Length);
                writer.Close();

                PdfReader inputPdf = new PdfReader(@".\" + dtn + ".pdf");

                FileStream signedPdf = new FileStream(@".\" + dtn + "_signed.pdf", FileMode.Create);

                PdfStamper pdfStamper = PdfStamper.CreateSignature(inputPdf, signedPdf, '\0');

                IExternalSignature externalSignature = new X509Certificate2Signature(certClient, "SHA-1");

                Console.WriteLine(certClient);

                PdfSignatureAppearance signatureAppearance = pdfStamper.SignatureAppearance;

                int positionx = locationx + 5;
                int positiony = 832 - (locationy + 55);
                int positionyrel = positiony - 55;
                int positionxrel = positionx + 160;

                signatureAppearance.SetVisibleSignature(new iTextSharp.text.Rectangle(positionx, positiony, positionxrel, positionyrel), numPage, "Signature");
                signatureAppearance.Reason = "I have reviewed this document";
                signatureAppearance.Location = "Hanoi";
                signatureAppearance.Contact = "Email: info@egt.com.vn";
                //signatureAppearance.SignatureGraphic = Image.GetInstance(100, 200,, @"D:\\tick.png");

                //signatureAppearance.Image = iTextSharp.text.Image.GetInstance(@"D:\\logosmartsign.png");
                //signatureAppearance.ImageScale = 0.36f;
                //signatureAppearance.Image.Alignment = 300;
                //signatureAppearance.Acro6Layers = true;



                MakeSignature.SignDetached(signatureAppearance, externalSignature, chain, null, null, null, 0,
                    CryptoStandard.CMS);



                inputPdf.Close();
                pdfStamper.Close();


                File.Delete(@".\" + dtn + ".pdf");

                Byte[] input = File.ReadAllBytes(@".\" + dtn + "_signed.pdf");

                strRe = Convert.ToBase64String(input);
            }
            catch (Exception) {

            }
            return strRe;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string pathToPdf = this.textBoxPathToPdf.Text;
            string pathToPfx = this.textBoxPathToPfx.Text;
            string pfxPassword = this.textBoxPfxPassword.Text;
            try
            {
                double coorX = Double.Parse(this.textBoxCoordinateX.Text);
                double coorY = Double.Parse(this.textBoxCoordinateY.Text);
                int pageNum = Int32.Parse(this.textBoxPageNumber.Text);

                // validate path
                if (!File.Exists(pathToPdf))
                {
                    MessageBox.Show("Path to pdf file is not valid", "Error");
                }
                if (!File.Exists(pathToPfx))
                {
                    MessageBox.Show("Path to pfx file is not valid", "Error");
                }
                if (pageNum < 0)
                {
                    pageNum = 0;
                }

                if (coorX < 0) coorX = 0;
                if (coorY < 0) coorY = 0;


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                MessageBox.Show("Something is wrong coordinateX or coordinateY or pageNumber occurred, please check it again", "Error");
            }

        }
    }
}
