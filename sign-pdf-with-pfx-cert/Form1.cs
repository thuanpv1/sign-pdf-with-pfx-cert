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
using static iTextSharp.text.pdf.PdfSignatureAppearance;
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

        public void test()
        {

        }
        public string SignPDF(string pdfPath, string pfxPath, string pfxPassword,  int locationx = 5, int locationy = 20, int numPage = 1, string signDate = "05/29/2015 5:50 AM")
        {
            string fontPath = @".\ARIALUNI.TTF";
            string strRe = "";
            try
            {

                X509Certificate2 certClient = null;
                certClient = new X509Certificate2(File.ReadAllBytes(pfxPath), pfxPassword, X509KeyStorageFlags.Exportable);

                var privateKey = Org.BouncyCastle.Security.DotNetUtilities.GetKeyPair(certClient.PrivateKey).Private;

                IExternalSignature externalSignature = new PrivateKeySignature(privateKey, "SHA-256");

                //Get Cert Chain
                IList<X509Certificate> chain = new List<X509Certificate>();
                X509Chain x509Chain = new X509Chain();

                x509Chain.Build(certClient);

                foreach (X509ChainElement x509ChainElement in x509Chain.ChainElements)
                {
                    chain.Add(Org.BouncyCastle.Security.DotNetUtilities.FromX509Certificate(x509ChainElement.Certificate));
                }

                string dtn = DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString();

                PdfReader inputPdf = new PdfReader(pdfPath);

                FileStream signedPdf = new FileStream(@"output\" + dtn + "_signed.pdf", FileMode.Create);

                PdfStamper pdfStamper = PdfStamper.CreateSignature(inputPdf, signedPdf, '\0', null, true);

                Console.WriteLine(certClient);

                PdfSignatureAppearance signatureAppearance = pdfStamper.SignatureAppearance;

                // setup font

                BaseFont bf = null;
                try
                {
                    if (String.IsNullOrEmpty(fontPath))
                    {
                        bf = BaseFont.CreateFont(fontPath, BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
                    }
                    else
                    {
                        bf = BaseFont.CreateFont(fontPath, BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }

                iTextSharp.text.Font f = new iTextSharp.text.Font(bf, 7, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.RED);

                signatureAppearance.Layer2Font = f;
                // Custom signature appearance text
                string personWhoSigned = "unknown";
                foreach (var info in certClient.Subject.Split(','))
                {
                    if (info.Contains("CN="))
                    {
                        personWhoSigned = info.Split('=')[1];
                    }
                }

                signatureAppearance.Layer2Text = "Chứng thực bởi iGreensCA\nKý bởi: " + personWhoSigned + "\nNgày Ký: " + signDate;
                iTextSharp.text.Rectangle pagesize = inputPdf.GetPageSize(1);

                float positionx = (3 - 1) * 100 + locationx;
                float positiony = locationy;
                float positionyrel = positiony + 40;
                float positionxrel = positionx + 100;
                iTextSharp.text.Rectangle container = new iTextSharp.text.Rectangle(positionx, positiony, positionxrel, positionyrel);
                container.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                try
                {
                    signatureAppearance.SetVisibleSignature(container, numPage, certClient.GetSerialNumberString());
                }
                catch
                {
                    MessageBox.Show("Bạn đã ký rồi!", "Error");
                    return strRe;
                }
                signatureAppearance.SignatureRenderingMode = RenderingMode.DESCRIPTION;
                signatureAppearance.SignDate = DateTime.Parse(signDate);
                signatureAppearance.Reason = "I approved this document";
                signatureAppearance.Location = "VN";
                signatureAppearance.Contact = "Email: info@egt.vn";
                //signatureAppearance.SignatureGraphic = Image.GetInstance(100, 200,, @"D:\\tick.png");

                //signatureAppearance.Image = iTextSharp.text.Image.GetInstance(@"D:\\logosmartsign.png");
                //signatureAppearance.ImageScale = 0.36f;
                //signatureAppearance.Image.Alignment = 300;
                //signatureAppearance.Acro6Layers = true;



                MakeSignature.SignDetached(signatureAppearance, externalSignature, chain, null, null, null, 0,
                    CryptoStandard.CMS);



                inputPdf.Close();
                pdfStamper.Close();
                MessageBox.Show("Ký thành công!", "Info");
                Byte[] input = File.ReadAllBytes(@"output\" + dtn + "_signed.pdf");

                strRe = Convert.ToBase64String(input);
            }
            catch (Exception ex) {
                Console.WriteLine(ex.ToString());
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
                int coorX = Int32.Parse(this.textBoxCoordinateX.Text);
                int coorY = Int32.Parse(this.textBoxCoordinateY.Text);
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

                SignPDF(pathToPdf, pathToPfx, pfxPassword, locationx: coorX, locationy: coorY, numPage: pageNum);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                MessageBox.Show("Something is wrong coordinateX or coordinateY or pageNumber occurred, please check it again", "Error");
            }

        }

        private void buttonBrowsePfx_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Multiselect = false;
            openFileDialog1.Filter = "Files|*.pfx;*.p12";

            DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                string file = openFileDialog1.FileName;
                this.textBoxPathToPfx.Text = file;
            }
        }

        private void buttonBrowsePdf_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Multiselect = false;
            openFileDialog1.Filter = "Files|*.pdf;*.PDF";

            DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                string file = openFileDialog1.FileName;
                this.textBoxPathToPdf.Text = file;
                PdfReader inputPdf = new PdfReader(file);
                // Page size
                iTextSharp.text.Rectangle pagesize = inputPdf.GetPageSize(1);
                labelPdfSize.Text = "PdfSize: " + pagesize.Width.ToString() + "x" + pagesize.Height.ToString();
            }
        }
    }
}
