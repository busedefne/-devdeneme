/*using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            lbl_over.Hide();
        }
        bool right, left, space;
        int score;

        void Game_Result()
        {
            foreach (Control j in this.Controls)
            {
                foreach (Control i in this.Controls)
                {
                    if (j is PictureBox && j.Tag == "bullet")
                    {
                        if (i is PictureBox && i.Tag == "enemy")
                        {
                            if (j.Bounds.IntersectsWith(i.Bounds))
                            {
                                i.Top = -100;
                                ((PictureBox)i).Image = Properties.Resources.explosion;
                                score++;
                                lbl_score.Text = "Score :" + score;
                            }
                        }
                    }
                }
            }
            if (player.Bounds.IntersectsWith(spaceship.Bounds)|| player.Bounds.IntersectsWith(asteroid.Bounds))
                    {
                timer1.Stop();
                lbl_over.Show();
                lbl_over.BringToFront();
            
            }
        }
        void Star()
        {
            foreach (Control j in this.Controls)
            {
                if (j is PictureBox && j.Tag == "stars")
                {
                    j.Top += 10; // Yıldızın yukarı kayması
                    if (j.Top > this.ClientSize.Height) // Ekranın alt sınırına ulaşınca
                    {
                        j.Top = -j.Height; // Yıldız yukarıdan tekrar başlasın
                    }
                }
            }
        }

        /*
void Star()
{
    foreach (Control j in this.Controls)
    {
                if (j is PictureBox && j.Tag == "stars")
                {
                    j.Top += 10;
                    if (j.Top > 400)
                    {
                        j.Top = 0;
                    }
                }
            }
        }
        
        void Add_Bullet()
        {
            PictureBox bullet = new PictureBox();
            bullet.SizeMode = PictureBoxSizeMode.AutoSize;
            bullet.Image = Properties.Resources.bulleta;
            bullet.BackColor = System.Drawing.Color.Transparent;
            bullet.Tag = "bullet";
            bullet.Left = player.Left + 15;
            bullet.Top = player.Top - 30;
            this.Controls.Add(bullet);
            bullet.BringToFront();
          

        }
        void Bullet_Movement()
        {
            foreach (Control x in this.Controls) {
                if (x is PictureBox && x.Tag == "bullet")
                {
                    x.Top -= 10;
                    if(x.Top<100)
                    {
                        this.Controls.Remove(x);
                    }
                }
}
        }

        void Enemy_Movement()
        {
            Random rnd = new Random();
            int x, y;
            if (spaceship.Top >= 750)
            {
                x = rnd.Next(0, 300);
                spaceship.Location = new Point(x, 0);
            }
            if (asteroid.Top >= 750)
            {
                y = rnd.Next(0, 300);
                asteroid.Location = new Point(y, 0);
            }
            else 
            {
                spaceship.Top += 15;
                asteroid.Top += 10;
            
            }


        }
        void Arrow_key_Movement()
        {
            if (right == true)
            {
                if (player.Left < 425)
                {
                    player.Left += 20;
                }
            }
            if (left == true)
            {
                if (player.Left > 10)
                {
                    player.Left -= 20;
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Arrow_key_Movement();
            Enemy_Movement();
            Bullet_Movement();
            Star();
            Game_Result();

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                right = true;
            }
            if (e.KeyCode == Keys.Left)
            {
                left = true;
            }
            if (e.KeyCode == Keys.Space)
            {
                space = true;
                Add_Bullet();
            }
            
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                right = false;
            }
            if (e.KeyCode == Keys.Left)
            {
                left = false;
            }
            if (e.KeyCode == Keys.Space)
            {
                space =false;
            }
        }
    }
}
*/

/* son kodum sağlam
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            lbl_over.Hide();
            InitializeStars(); // Yıldızları başlatıyoruz
            InitializeEnemies(); // Düşmanları başlatıyoruz
        }

        bool right, left, space;
        int score;

      
        // Düşmanları başlatma fonksiyonu
        private void InitializeEnemies()
        {
            // Spaceship
            spaceship.Tag = "enemy";
            spaceship.Image = Properties.Resources.icons8_spaceship_48__1_; // Düşman resmi
            spaceship.Left = new Random().Next(0, this.ClientSize.Width - spaceship.Width);
            spaceship.Top = 0; // Üstten başlatıyoruz

            // Asteroid
            asteroid.Tag = "enemy";
            asteroid.Image = Properties.Resources.icons8_asteroid_50__1_; // Asteroid resmi
            asteroid.Left = new Random().Next(0, this.ClientSize.Width - asteroid.Width);
            asteroid.Top = 0; // Üstten başlatıyoruz
        }
        void Game_Result()
        {
            foreach (Control j in this.Controls)
            {
                foreach (Control i in this.Controls)
                {
                    if (j is PictureBox && j.Tag == "bullet")
                    {
                        if (i is PictureBox && i.Tag == "enemy")
                        {
                            if (j.Bounds.IntersectsWith(i.Bounds))
                            {
                                // Düşmanı kaybolması için yukarı taşıyoruz
                                i.Top = -100;
                                ((PictureBox)i).Image = Properties.Resources.explosion; // Patlama animasyonu

                                // Skoru artırıyoruz
                                score++;
                                lbl_score.Text = "Score: " + score;

                                // Eğer bu düşman spaceship ise
                                if (i == spaceship)
                                {
                                    Timer spaceshipTimer = new Timer();
                                    spaceshipTimer.Interval = 2000; // Spaceship için 2 saniye
                                    spaceshipTimer.Tick += (sender, e) =>
                                    {
                                        // Spaceship yeniden başlatılıyor
                                        int newX = new Random().Next(0, 500 - spaceship.Width); // Yeni X pozisyonu
                                        spaceship.Top = 0; // Üstten başlatıyoruz
                                        spaceship.Left = newX; // Yeni X pozisyonu
                                        spaceship.Image = Properties.Resources.icons8_spaceship_48__1_; // Düşman resmini geri yüklüyoruz
                                        spaceshipTimer.Stop(); // Timer'ı durduruyoruz
                                    };
                                    spaceshipTimer.Start(); // Spaceship için yenileme timer'ını başlatıyoruz
                                }

                                // Eğer bu düşman asteroid ise
                                if (i == asteroid)
                                {
                                    Timer asteroidTimer = new Timer();
                                    asteroidTimer.Interval = 3000; // Asteroid için 3 saniye
                                    asteroidTimer.Tick += (sender, e) =>
                                    {
                                        // Asteroid yeniden başlatılıyor
                                        int newX = new Random().Next(0, 500 - asteroid.Width); // Yeni X pozisyonu
                                        asteroid.Top = 0; // Üstten başlatıyoruz
                                        asteroid.Left = newX; // Yeni X pozisyonu
                                        asteroid.Image = Properties.Resources.icons8_asteroid_50__1_; // Asteroid resmini geri yüklüyoruz
                                        asteroidTimer.Stop(); // Timer'ı durduruyoruz
                                    };
                                    asteroidTimer.Start(); // Asteroid için yenileme timer'ını başlatıyoruz
                                }
                            }
                        }
                    }
                }
            }

            // Eğer oyuncu düşmanlara çarptıysa oyunu durduruyoruz
            if (player.Bounds.IntersectsWith(spaceship.Bounds) || player.Bounds.IntersectsWith(asteroid.Bounds))
            {
                timer1.Stop();
                lbl_over.Show();
                lbl_over.BringToFront();
            }
        }

        // Yıldızları başlatıyoruz
        // Yıldızları başlatıyoruz
        private void InitializeStars()
        {
            int starCount = 30; // Yıldız sayısını artırdık
            int starSpacing = 50; // Yıldızlar arasındaki mesafe (toplamda 10 yıldız olacak)

            for (int i = 0; i < starCount; i++)
            {
                PictureBox star = new PictureBox();
                star.Tag = "stars";
                star.Image = Properties.Resources.yıldızlarson; // Yıldız görseli
                star.SizeMode = PictureBoxSizeMode.AutoSize;
                star.Left = 0; // Yıldızları soldan yerleştiriyoruz
                star.Top = i * starSpacing; // Yıldızlar arasına mesafe ekliyoruz
                this.Controls.Add(star);
            }
        }

        // Yıldızların kaymasını sağlıyoruz
        void Star()
        {
            foreach (Control j in this.Controls)
            {
                if (j is PictureBox && j.Tag == "stars")
                {
                    j.Top += 10; // Yıldızları aşağı kaydırma
                    if (j.Top > this.ClientSize.Height) // Eğer formun alt kısmına ulaşırsa
                    {
                        j.Top = 0; // En üste sıfırlıyoruz
                    }
                }
            }
        }

     

      
        void Add_Bullet()
        {
            PictureBox bullet = new PictureBox();
            bullet.SizeMode = PictureBoxSizeMode.AutoSize;
            bullet.Image = Properties.Resources.icons8_bullet_16__1_1;
            bullet.BackColor = System.Drawing.Color.Transparent;
            bullet.Tag = "bullet";
            bullet.Left = player.Left + 15;
            bullet.Top = player.Top - 30;
            this.Controls.Add(bullet);
            bullet.BringToFront();
        }

        // Mermilerin hareketini sağlıyoruz
        void Bullet_Movement()
        {
            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && x.Tag == "bullet")
                {
                    x.Top -= 10;
                    if (x.Top < 100)
                    {
                        this.Controls.Remove(x);
                    }
                }
            }
        }

        // Düşman hareketini sağlıyoruz
        void Enemy_Movement()
        {
            Random rnd = new Random();

            // Spaceship hareketi
            if (spaceship.Top >= 750) // Ekranın altına ulaştıysa
            {
                int newX = rnd.Next(0, 500 - spaceship.Width); // Yeni X pozisyonu
                spaceship.Location = new Point(newX, 0); // Yeniden başlat
            }
            else
            {
                spaceship.Top += 15; // Hareket etmeye devam
            }

            // Asteroid hareketi
            if (asteroid.Top >= 750) // Ekranın altına ulaştıysa
            {
                int newX = rnd.Next(0, 500 - asteroid.Width); // Yeni X pozisyonu
                asteroid.Location = new Point(newX, 0); // Yeniden başlat
            }
            else
            {
                asteroid.Top += 10; // Hareket etmeye devam
            }
        }

        // Ok tuşları ile roket hareketi
        void Arrow_key_Movement()
        {
            if (right == true)
            {
                if (player.Left < 425)
                {
                    player.Left += 20;
                }
            }
            if (left == true)
            {
                if (player.Left > 10)
                {
                    player.Left -= 20;
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Arrow_key_Movement();
            Enemy_Movement();   
            Bullet_Movement();
            Star();  // Yıldızları hareket ettiriyoruz
            Game_Result();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                right = true;
            }
            if (e.KeyCode == Keys.Left)
            {
                left = true;
            }
            if (e.KeyCode == Keys.Space)
            {
                space = true;
                Add_Bullet();
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                right = false;
            }
            if (e.KeyCode == Keys.Left)
            {
                left = false;
            }
            if (e.KeyCode == Keys.Space)
            {
                space = false;
            }
        }
    }
}
*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            lbl_over.Hide();
            InitializeStars(); // Yıldızları başlatıyoruz
            InitializeEnemies(); // Düşmanları başlatıyoruz
        }

        bool right, left, space;
        int score;

        // Düşmanları başlatma fonksiyonu
        private void InitializeEnemies()
        {
            // Spaceship
            spaceship.Tag = "enemy";
            spaceship.Image = Properties.Resources.icons8_spaceship_48__1_; // Düşman resmi
            spaceship.Left = new Random().Next(0, this.ClientSize.Width - spaceship.Width);
            spaceship.Top = 0; // Üstten başlatıyoruz

            // Asteroid
            asteroid.Tag = "enemy";
            asteroid.Image = Properties.Resources.icons8_asteroid_50__1_; // Asteroid resmi
            asteroid.Left = new Random().Next(0, this.ClientSize.Width - asteroid.Width);
            asteroid.Top = 0; // Üstten başlatıyoruz
        }
        void Game_Result()
        {
            foreach (Control j in this.Controls)
            {
                foreach (Control i in this.Controls)
                {
                    if (j is PictureBox && j.Tag == "bullet")
                    {
                        if (i is PictureBox && i.Tag == "enemy")
                        {
                            if (j.Bounds.IntersectsWith(i.Bounds))
                            {
                                // Düşmanı kaybolması için yukarı taşıyoruz
                                i.Top = -100;
                                ((PictureBox)i).Image = Properties.Resources.explosion; // Patlama animasyonu

                                // Skoru artırıyoruz
                                score++;
                                lbl_score.Text = "Score: " + score;

                                // Eğer bu düşman spaceship ise
                                if (i == spaceship)
                                {
                                    Timer spaceshipTimer = new Timer();
                                    spaceshipTimer.Interval = 2000; // Spaceship için 2 saniye
                                    spaceshipTimer.Tick += (sender, e) =>
                                    {
                                        // Spaceship yeniden başlatılıyor
                                        int newX = new Random().Next(0, 500 - spaceship.Width); // Yeni X pozisyonu
                                        spaceship.Top = 0; // Üstten başlatıyoruz
                                        spaceship.Left = newX; // Yeni X pozisyonu
                                        spaceship.Image = Properties.Resources.icons8_spaceship_48__1_; // Düşman resmini geri yüklüyoruz
                                        spaceshipTimer.Stop(); // Timer'ı durduruyoruz
                                    };
                                    spaceshipTimer.Start(); // Spaceship için yenileme timer'ını başlatıyoruz
                                }

                                // Eğer bu düşman asteroid ise
                                if (i == asteroid)
                                {
                                    Timer asteroidTimer = new Timer();
                                    asteroidTimer.Interval = 3000; // Asteroid için 3 saniye
                                    asteroidTimer.Tick += (sender, e) =>
                                    {
                                        // Asteroid yeniden başlatılıyor
                                        int newX = new Random().Next(0, 500 - asteroid.Width); // Yeni X pozisyonu
                                        asteroid.Top = 0; // Üstten başlatıyoruz
                                        asteroid.Left = newX; // Yeni X pozisyonu
                                        asteroid.Image = Properties.Resources.icons8_asteroid_50__1_; // Asteroid resmini geri yüklüyoruz
                                        asteroidTimer.Stop(); // Timer'ı durduruyoruz
                                    };
                                    asteroidTimer.Start(); // Asteroid için yenileme timer'ını başlatıyoruz
                                }
                            }
                        }
                    }
                }
            }

            // Eğer oyuncu düşmanlara çarptıysa oyunu durduruyoruz
            if (player.Bounds.IntersectsWith(spaceship.Bounds) || player.Bounds.IntersectsWith(asteroid.Bounds))
            {
                timer1.Stop();
                lbl_over.Show();
                lbl_over.BringToFront();
            }
        }

        // Yıldızları başlatıyoruz
        // Yıldızları başlatıyoruz
        private void InitializeStars()
        {
            int starCount = 30; // Yıldız sayısını artırdık
            int starSpacing = 50; // Yıldızlar arasındaki mesafe (toplamda 10 yıldız olacak)

            for (int i = 0; i < starCount; i++)
            {
                PictureBox star = new PictureBox();
                star.Tag = "stars";
                star.Image = Properties.Resources.yıldızlarson; // Yıldız görseli
                star.SizeMode = PictureBoxSizeMode.AutoSize;
                star.Left = 0; // Yıldızları soldan yerleştiriyoruz
                star.Top = i * starSpacing; // Yıldızlar arasına mesafe ekliyoruz
                this.Controls.Add(star);
            }
        }

        // Yıldızların kaymasını sağlıyoruz
        void Star()
        {
            foreach (Control j in this.Controls)
            {
                if (j is PictureBox && j.Tag == "stars")
                {
                    j.Top += 10; // Yıldızları aşağı kaydırma
                    if (j.Top > this.ClientSize.Height) // Eğer formun alt kısmına ulaşırsa
                    {
                        j.Top = 0; // En üste sıfırlıyoruz
                    }
                }
            }
        }




        void Add_Bullet()
        {
            PictureBox bullet = new PictureBox();
            bullet.SizeMode = PictureBoxSizeMode.AutoSize;
            bullet.Image = Properties.Resources.icons8_bullet_16__1_1;
            bullet.BackColor = System.Drawing.Color.Transparent;
            bullet.Tag = "bullet";
            bullet.Left = player.Left + 15;
            bullet.Top = player.Top - 30;
            this.Controls.Add(bullet);
            bullet.BringToFront();
        }

        // Mermilerin hareketini sağlıyoruz
        void Bullet_Movement()
        {
            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && x.Tag == "bullet")
                {
                    x.Top -= 10;
                    if (x.Top < 100)
                    {
                        this.Controls.Remove(x);
                    }
                }
            }
        }

        // Düşman hareketini sağlıyoruz
        void Enemy_Movement()
        {
            Random rnd = new Random();

            // Spaceship hareketi
            if (spaceship.Top >= 750) // Ekranın altına ulaştıysa
            {
                int newX = rnd.Next(0, 500 - spaceship.Width); // Yeni X pozisyonu
                spaceship.Location = new Point(newX, 0); // Yeniden başlat
            }
            else
            {
                spaceship.Top += 15; // Hareket etmeye devam
            }

            // Asteroid hareketi
            if (asteroid.Top >= 750) // Ekranın altına ulaştıysa
            {
                int newX = rnd.Next(0, 500 - asteroid.Width); // Yeni X pozisyonu
                asteroid.Location = new Point(newX, 0); // Yeniden başlat
            }
            else
            {
                asteroid.Top += 10; // Hareket etmeye devam
            }
        }

        // Ok tuşları ile roket hareketi
        void Arrow_key_Movement()
        {
            if (right == true)
            {
                if (player.Left < 425)
                {
                    player.Left += 20;
                }
            }
            if (left == true)
            {
                if (player.Left > 10)
                {
                    player.Left -= 20;
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Arrow_key_Movement();
            Enemy_Movement();
            Bullet_Movement();
            Star();  // Yıldızları hareket ettiriyoruz
            Game_Result();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                right = true;
            }
            if (e.KeyCode == Keys.Left)
            {
                left = true;
            }
            if (e.KeyCode == Keys.Space)
            {
                space = true;
                Add_Bullet();
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                right = false;
            }
            if (e.KeyCode == Keys.Left)
            {
                left = false;
            }
            if (e.KeyCode == Keys.Space)
            {
                space = false;
            }
        }
    }
}


