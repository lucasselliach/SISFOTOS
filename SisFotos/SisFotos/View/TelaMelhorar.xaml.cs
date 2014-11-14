using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Microsoft.Win32;
using SisFotos.Controller;
using Image = System.Windows.Controls.Image;

namespace SisFotos.View
{
    public partial class TelaMelhorar : INotifyPropertyChanged
    {
        #region Public Properties

        public int ProgressBarMaximum
        {
            get { return _progressBarMaximum; }
            set
            {
                _progressBarMaximum = value;
                NotifyPropertyChanged("ProgressBarMaximum");
            }
        }

        public int ProgressBarValue
        {
            get { return _progressBarValue; }
            set
            {
                _progressBarValue = value;
                NotifyPropertyChanged("ProgressBarValue");
            }
        }

        #endregion Public Properties
        
        #region Internal Properties

        private List<Bitmap> _listBitmap;

        private string _ultimoDiretorioUtilizado;
        private int _progressBarMaximum;
        private int _progressBarValue;

        #endregion Internal Properties
        
        #region Constructors/Destructor

        public TelaMelhorar()
        {
            InitializeComponent();
            DataContext = this;
            Inicializar();
        }

        private void Inicializar()
        {
            ProgressBarMaximum = 1;
            ProgressBarValue = 0;
            _listBitmap = new List<Bitmap>();
        }

        #endregion Constructors/Destructor
        
        #region Public Methods
        #endregion Public Methods
        
        #region Internal Methods

        private void ProcurarArquivos()
        {
            var openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Images(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF|" + "All files (*.*)|*.*";
            openFileDialog.Multiselect = true;
            var resultado = openFileDialog.ShowDialog();

            if (resultado == true)
            {
                _ultimoDiretorioUtilizado = Path.GetDirectoryName(openFileDialog.FileName);
                TextBoxCaminho.Text = _ultimoDiretorioUtilizado;

                ProgressBarMaximum = openFileDialog.FileNames.Count();
                foreach (var file in openFileDialog.FileNames)
                {
                    try
                    {
                        var imagem = new Image
                        {
                            Source = new BitmapImage(new Uri(file)),
                            Height = 125,
                            Width = 165,
                            Margin = new Thickness(5, 5, 5, 5),
                            Stretch = Stretch.UniformToFill
                        };
                        WrapPanelFotosSelecionadas.Children.Add(imagem);

                        var localImage = new Bitmap(file);
                        _listBitmap.Add(localImage); 

                        ProgressBarValue++;
                    }
                    catch (Exception e)
                    {
                       
                    }
                }
            }
        }

        private void Voltar()
        {
            Close();
        }

        private void Melhorar()
        {
            if (!Directory.Exists(_ultimoDiretorioUtilizado + "/modificadas"))
            {
                Directory.CreateDirectory(_ultimoDiretorioUtilizado + "/modificadas");
                RealizarAlteraçõesDeImagens();
            }
            else
            {
                if (MessageBox.Show("Desejas excluir a pasta com as fotos modificadas?", "Pasta já existe!", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                {
                    Directory.Delete(_ultimoDiretorioUtilizado + "/modificadas", true);
                    Directory.CreateDirectory(_ultimoDiretorioUtilizado + "/modificadas");
                    RealizarAlteraçõesDeImagens();
                }
                else
                {
                    Close();
                }
            }
        }

        private void RealizarAlteraçõesDeImagens()
        {
            try
            {
                var tratamentoDeImagens = new TratamentoDeImagens(_listBitmap);

                var cont = 0;
                foreach (var bitmap in tratamentoDeImagens.BitmapsTratada)
                {
                    cont++;
                    bitmap.Save(_ultimoDiretorioUtilizado + "/modificadas" + "/MOD" + cont + ".jpg", tratamentoDeImagens.JpgEnconder, tratamentoDeImagens.EncoderParameters);
                }
                
                _listBitmap.Clear();
                WrapPanelFotosSelecionadas.Children.Clear();

                MessageBox.Show("Fotos tratadas com sucesso! ", "Tudo certo", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Falha Genérica: " + ex.Message, "Alerta!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        #endregion Internal Methods
        
        #region Events

        private void ProcurarArquivos_OnClick(object sender, RoutedEventArgs e)
        {
            ProcurarArquivos();
        }

        private void ButtonVoltar_OnClick(object sender, RoutedEventArgs e)
        {
            Voltar();
        }

        private void ButtonMelhorar_OnClick(object sender, RoutedEventArgs e)
        {
            Melhorar();
        }

        #endregion Events
        
        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;
        
        void NotifyPropertyChanged(string info)
        {
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(info));
        }

        #endregion INotifyPropertyChanged Members
    }
}
