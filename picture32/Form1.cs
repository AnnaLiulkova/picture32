using System;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace picture32
{
    public partial class Form1 : Form
    {
        private Bitmap originalImage = null; // ������ ���������� ����������
        private Bitmap mirroredImage = null; // ������ ���������� ����������
        private string fileName = null; // ���� �� ������������ ����������
        private Regex regexExtForImage = new Regex("^\\.(bmp|gif|tiff?|jpe?g|png)$", RegexOptions.IgnoreCase); // �������� ���������� �����

        public Form1()
        {
            InitializeComponent();
        }

        private void BtnLoadImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog()) // �������� ����������� ������� ���� �� ������� �������
            {
                openFileDialog.Filter = "Image Files|*.bmp;*.jpg;*.jpeg;*.png;*.gif;*.tiff";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    fileName = openFileDialog.FileName;

                    // ��������
                    string extension = Path.GetExtension(fileName); // ������ ���������� �����
                    if (!regexExtForImage.IsMatch(extension))
                    {
                        MessageBox.Show("���� �� �� ������������� ����������. ���� �����, ������� ����������.",
                            "�������", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    try
                    {
                        // ����������� ������� ����������
                        Image loadedImage = Image.FromFile(fileName);

                        if (loadedImage.Width > pictureBox1.Width || loadedImage.Height > pictureBox1.Height)
                        {
                            originalImage = ResizeImage(loadedImage, pictureBox1.Width, pictureBox1.Height);
                        }
                        else
                        {
                            originalImage = new Bitmap(loadedImage);
                        }

                        loadedImage.Dispose(); // �� ������� ��� ���������� ������ ���'��

                        mirroredImage = null; // ������� ���������� ����������
                        pictureBox1.Image = originalImage; // ³��������� ����������
                        pictureBox2.Image = null; // ������� PictureBox2
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"�� ������� ����������� ����������.\n�������: {ex.Message}",
                            "�������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void BtnMirrorImage_Click(object sender, EventArgs e)
        {
            if (originalImage == null)
            {
                MessageBox.Show("�������� ���������� ����.", "�������", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            mirroredImage?.Dispose(); // ��������� ���'���, ���� ���� �������� ���������� ����������
            mirroredImage = new Bitmap(originalImage);
            mirroredImage.RotateFlip(RotateFlipType.RotateNoneFlipX); // ���������� �����������

            pictureBox2.Image = mirroredImage; 
        }

        private void BtnSaveImage_Click(object sender, EventArgs e)
        {
            if (mirroredImage == null)
            {
                MessageBox.Show("�������� ����������� ����.", "�������", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string directory = Path.GetDirectoryName(this.fileName); //������ ��������� ���������� �� ����� ����� ���� ��� ����� � ���������� ������� "-mirrored.gif"
            string fileName = Path.GetFileNameWithoutExtension(this.fileName) + "-mirrored.gif";
            string savePath = Path.Combine(directory, fileName);

            try
            {
                mirroredImage.Save(savePath, System.Drawing.Imaging.ImageFormat.Gif);
                MessageBox.Show($"���� ��������� �� �������: {savePath}", "����", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"�� ������� �������� ����������.\n�������: {ex.Message}",
                    "�������", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Bitmap ResizeImage(Image image, int width, int height)
        {
            Bitmap resizedBitmap = new Bitmap(width, height);
            using (var graphics = Graphics.FromImage(resizedBitmap))
            {
                graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;// ����������� ����������� ������� ������������ ��� ���� ������
                graphics.DrawImage(image, 0, 0, width, height);
            }
            return resizedBitmap;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
