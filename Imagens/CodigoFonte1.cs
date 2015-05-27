using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SisFotos
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : INotifyPropertyChanged
    {
        #region Public Properties
        #endregion Public Properties
        
        #region Internal Properties
        #endregion Internal Properties
        
        #region Constructors/Destructor
        
        public MainWindow()
        {
            InitializeComponent();
        }

        #endregion Constructors/Destructor
        
        #region Public Methods
        #endregion Public Methods
        
        #region Internal Methods
        #endregion Internal Methods
        
        #region Events

        private void ButtonSair_OnClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ButtonMelhorar_OnClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
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
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(info));
        }

        #endregion INotifyPropertyChanged Members
    }
}

