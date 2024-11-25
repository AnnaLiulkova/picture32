using System;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace picture32
{
    public partial class Form1 : Form
    {
        private Bitmap originalImage = null; // зберігає оригінальне зображення
        private Bitmap mirroredImage = null; // зберігає дзеркальне зображення
        private string fileName = null; // шлях до оригінального зображення
        private Regex regexExtForImage = new Regex("^\\.(bmp|gif|tiff?|jpe?g|png)$", RegexOptions.IgnoreCase); // перевірка розширення файлу

        public Form1()
        {
            InitializeComponent();
        }

        private void BtnLoadImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog()) // дозволяє користувачу вибрати файл із файлової системи
            {
                openFileDialog.Filter = "Image Files|*.bmp;*.jpg;*.jpeg;*.png;*.gif;*.tiff";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    fileName = openFileDialog.FileName;

                    // перевірка
                    string extension = Path.GetExtension(fileName); // отримує розширення файлу
                    if (!regexExtForImage.IsMatch(extension))
                    {
                        MessageBox.Show("Файл не має підтримуваного розширення. Будь ласка, виберіть зображення.",
                            "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    try
                    {
                        // завантажуємо вибране зображення
                        Image loadedImage = Image.FromFile(fileName);

                        if (loadedImage.Width > pictureBox1.Width || loadedImage.Height > pictureBox1.Height)
                        {
                            originalImage = ResizeImage(loadedImage, pictureBox1.Width, pictureBox1.Height);
                        }
                        else
                        {
                            originalImage = new Bitmap(loadedImage);
                        }

                        loadedImage.Dispose(); // це важливо для запобігання витоків пам'яті

                        mirroredImage = null; // скидаємо дзеркальне зображення
                        pictureBox1.Image = originalImage; // Відображаємо зображення
                        pictureBox2.Image = null; // Очищуємо PictureBox2
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Не вдалося завантажити зображення.\nПомилка: {ex.Message}",
                            "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void BtnMirrorImage_Click(object sender, EventArgs e)
        {
            if (originalImage == null)
            {
                MessageBox.Show("Спочатку завантажте фото.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            mirroredImage?.Dispose(); // звільняємо пам'ять, якщо було створено дзеркальне зображення
            mirroredImage = new Bitmap(originalImage);
            mirroredImage.RotateFlip(RotateFlipType.RotateNoneFlipX); // дзеркальне відображення

            pictureBox2.Image = mirroredImage; 
        }

        private void BtnSaveImage_Click(object sender, EventArgs e)
        {
            if (mirroredImage == null)
            {
                MessageBox.Show("Спочатку відзеркальте фото.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string directory = Path.GetDirectoryName(this.fileName); //отримує директорію збереження та формує новий шлях для файлу з додаванням суфікса "-mirrored.gif"
            string fileName = Path.GetFileNameWithoutExtension(this.fileName) + "-mirrored.gif";
            string savePath = Path.Combine(directory, fileName);

            try
            {
                mirroredImage.Save(savePath, System.Drawing.Imaging.ImageFormat.Gif);
                MessageBox.Show($"Фото збережено за адресою: {savePath}", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не вдалося зберегти зображення.\nПомилка: {ex.Message}",
                    "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Bitmap ResizeImage(Image image, int width, int height)
        {
            Bitmap resizedBitmap = new Bitmap(width, height);
            using (var graphics = Graphics.FromImage(resizedBitmap))
            {
                graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;// використовує високоякісну бікубічну інтерполяцію для зміни розміру
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
