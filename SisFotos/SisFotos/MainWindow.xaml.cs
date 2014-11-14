using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using SisFotos.View;

namespace SisFotos
{
    public partial class MainWindow : INotifyPropertyChanged
    {
        #region Public Properties

        public ImageSource LogoTipo
        {
            get { return _logoTipo; }
            set
            {
                _logoTipo = value;
                NotifyPropertyChanged("LogoTipo");
            }
        }

        #endregion Public Properties
        
        #region Internal Properties

        private ImageSource _logoTipo;

        #endregion Internal Properties
        
        #region Constructors/Destructor
        
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            Carregar();
        }

        #endregion Constructors/Destructor
        
        #region Internal Methods

        private void Carregar() 
        {
            var imageParaLogoTipo = new BitmapImage(new Uri(String.Format("Imagens/LogoTipoLucas.png"), UriKind.Relative));
            LogoTipo = imageParaLogoTipo;
        }

        #endregion Internal Methods
        
        #region Events

        private void ButtonSair_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ButtonMelhorar_OnClick(object sender, RoutedEventArgs e)
        {
            var melhorarFoto = new TelaMelhorar();
            melhorarFoto.ShowDialog();
        }

        private void ButtonCortar_OnClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
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

