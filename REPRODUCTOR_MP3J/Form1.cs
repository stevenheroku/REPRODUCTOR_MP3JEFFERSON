using REPRODUCTOR_MP3J.Clases.reproducir;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace REPRODUCTOR_MP3J
{
    public partial class Form1 : Form
    {

        OpenFileDialog buscarCanciones = new OpenFileDialog();
        int cant = 1;
        int tam;
        int vl = 100;
        private string arch;
        private string rut;
        ListarCanciones list = new ListarCanciones();
        int play = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void bunifuImagebtn_agregar_Click(object sender, EventArgs e)
        {
            try
            {

                buscarCanciones.Multiselect = true;
                buscarCanciones.Filter = "Archivos audios (*.mp3),(*.mp4),(*.wav),(*.png)|";


                if (buscarCanciones.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {

                    if (list.buscar(buscarCanciones.SafeFileName))
                    {
                        MessageBox.Show("ESA CANCION YA ESTA INGRESADA");
                        //continue;
                    }
                    else
                    {

                        for (int i = 0; i < buscarCanciones.SafeFileNames.Length; i++)
                        {
                            list.insertar(buscarCanciones.SafeFileNames[i]);
                            lis_canciones.Items.Add(/*+cant+". "+*/buscarCanciones.SafeFileNames[i]);
                            cant++;
                            tam++;
                        }

                        axWindowsMediaPlayer1.URL = buscarCanciones.FileNames[0];
                        lis_canciones.SelectedIndex = 0;
                        time_slider.Start();

                        MessageBox.Show("CANCIONES AGREGADAS AL PLAYLIST");
                    }
                    int pausa;
                    pausa = 0;



                }
            }
            catch (Exception en)
            {
                MessageBox.Show(en.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bunifuImagebtn_eliminar_Click(object sender, EventArgs e)
        {
            if (list.IsEmpty())
            {
                return;
            }
            else
            if (lis_canciones.SelectedIndex != -1)
            {
                arch = buscarCanciones.SafeFileNames[lis_canciones.SelectedIndex];

                list.eliminarNodo(arch);
                lis_canciones.Items.Remove(lis_canciones.SelectedItem);
                bunifuCustomlbl_nombre.Text = "------";
                axWindowsMediaPlayer1.Ctlcontrols.stop();


            }

            int pausa;
            pausa = 0;
        }

        private void lis_canciones_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                if (lis_canciones.SelectedIndex != -1)
                {


                    axWindowsMediaPlayer1.URL = buscarCanciones.FileNames[lis_canciones.SelectedIndex];
                    bunifuCustomlbl_nombre.Text = buscarCanciones.SafeFileNames[lis_canciones.SelectedIndex];

                }


            }
            catch (IndexOutOfRangeException exi)
            {
                MessageBox.Show("ERROR" + exi);
            }
        }

        private void bunifuImagebtn_anterior_Click(object sender, EventArgs e)
        {
            //keybd_event(VK_MEDIA_NEXT_TRACK, 0, KEYEVENTF_EXTENTEDKEY, IntPtr.Zero);
            if (lis_canciones.SelectedIndex <= 0)
            {
                MessageBox.Show("YA NO HAY CANCIONES ANTERIORES");
            }
            else if (lis_canciones.SelectedIndex > 0)
            {
                lis_canciones.SelectedIndex -= 1;
            }
        }

        private void bunifuImagebtn_siguiente_Click(object sender, EventArgs e)
        {
            if (lis_canciones.SelectedIndex == lis_canciones.Items.Count + 1)
            {
                MessageBox.Show("YA NO HAY CANCIONES PARA SEGUIR ");
            }
            else if (lis_canciones.SelectedIndex < lis_canciones.Items.Count - 1)
            {
                lis_canciones.SelectedIndex += 1;
            }
        }

        private void bunifuImagebtn_pause_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.pause();
            bunifuImagebtn_pause.Visible = false;
            btn_play.Visible = true;
        }

        private void btn_play_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.play();
            btn_play.Visible = false;
            bunifuImagebtn_pause.Visible = true;
        }

        private void timer_hora_Tick(object sender, EventArgs e)
        {
            lbl_fecha.Text = "hola";
            lbl_hora.Text = DateTime.Now.ToString("HH:mm:ss");
            lbl_fecha.Text = DateTime.Now.ToLongDateString();
        }

        private void validar_volumen_ValueChanged(object sender, decimal value)
        {
            axWindowsMediaPlayer1.settings.volume = validar_volumen.Value;

            lvl_volumen.Text = axWindowsMediaPlayer1.settings.volume.ToString();
        }

        private void duracion_cancion_ValueChanged(object sender, decimal value)
        {
            duracion_cancion.Maximum = (int)axWindowsMediaPlayer1.currentMedia.duration;

            if (duracion_cancion.Value == (int)axWindowsMediaPlayer1.Ctlcontrols.currentPosition)
            {

            }
            else
            {
                axWindowsMediaPlayer1.Ctlcontrols.currentPosition = duracion_cancion.Value;
            }
        }

        private void bunifuImagebtn_minimizar_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void bunifuImagebtn_cerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_maximizar_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            btn_maximizar.Visible = false;
            btn_restaurar.Visible = true;
        }

        private void btn_restaurar_Click(object sender, EventArgs e)
        {

            WindowState = FormWindowState.Normal;
            btn_restaurar.Visible = false;
            btn_maximizar.Visible = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lvl_volumen.Text = (validar_volumen.Value = axWindowsMediaPlayer1.settings.volume = vl).ToString();
            this.axWindowsMediaPlayer1.uiMode = "none";
        }

        private void time_slider_Tick(object sender, EventArgs e)
        {
            try
            {
                duracion_cancion.Value = (int)axWindowsMediaPlayer1.Ctlcontrols.currentPosition;
                lbl_inicio.Text = axWindowsMediaPlayer1.Ctlcontrols.currentPositionString;
                lbl_final.Text = axWindowsMediaPlayer1.currentMedia.durationString;


            }
            catch
            {
                MessageBox.Show("Error");
            }
        }

        private void timer_hora_Tick_1(object sender, EventArgs e)
        {
            lbl_fecha.Text = "hola";
            lbl_hora.Text = DateTime.Now.ToString("HH:mm:ss");
            lbl_fecha.Text = DateTime.Now.ToLongDateString();
        }
    }
    }

