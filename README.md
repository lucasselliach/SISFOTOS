##  SISFOTOS – Sistema para tratar imagem em WPF

Bom dia galera, hoje vou mostrar para vocês como fazer um programa simples para melhorar levemente uma imagens alterando seu contraste sendo que o objetivo desse tutorial não é exatamente a alteração da imagem mas ensinar a utilizar o WPF (Windows Presentation Foundation ).

Segundo a galera da Microsoft o  Windows Presentation Foundation (WPF) é a atual geração de user Interface, utilizado na construção de aplicações e sistemas sofisticados e interativos de alta qualidade. Ele oferece suporte a um amplo conjunto de recursos de desenvolvimento de aplicativos, incluindo modelo de aplicações, recursos, controles, elementos gráficos, layout, vinculação de dados, documentos e segurança.

Basicamente o WPF herda conceitos do CLR (Common Language Runtime) e no caso da parte de visão é dividido em dois seguimentos, o XAML e o CODEBEHIND. O XAML (Extensible Markup Language) é uma linguagem de marcação  utilizado na criação da UI (interface gráfica, exatamente o que o usuário final irá visualizar e interagir), sendo o code-behind a parte logica da tela.  Essa operação segue o conceito de um pattern chamado MVVM (Model View View Model), esse pattern estabelece uma separação de responsabilidade, no caso do WPF, ele visa separar o que for visão da logica.

![MVVM](https://raw.githubusercontent.com/lucasselliach/SISFOTOS/master/Imagens/ViewModel.png)

Nesse tutorial não irei aplicar 100% do pattern pois pretendo trazer de forma mais tranquila e rápida a utilização do WPF realizando o viewmodel direto no codebehind. A aplicação correta deixarei para o proximo tutorial seguindo o padrão, mas é possível por enquanto ver a aplicação correta do mvvm em [imasters](http://imasters.com.br/artigo/18900/desenvolvimento/entendendo-o-pattern-model-view-viewmodel-mvvm)

SISFOTOS WPF

1º Abra o Visual Studio (no meu caso o 2013) e vá em NEW PROJECT > VISUAL C# > WPF APPLICATION:

![Imagem1](https://raw.githubusercontent.com/lucasselliach/SISFOTOS/master/Imagens/Ensinamento1.png).

2º Em seguida crie três pastas para organizar a localização do nosso código futuramente e de dois click no MainWindow.

![Imagem2](https://raw.githubusercontent.com/lucasselliach/SISFOTOS/master/Imagens/Ensinamento2.png).

Nota-se que essa será a nossa primeira tela a ser visualizada quando compilar o programa, e aqui já é possível visualizar a notação **XAML** onde iremos moldar a nossa visão. Há duas formas de realizar a alocação dos componente na tela, com o famoso Drag and Drop ou na mão (programando). Eu prefiro fazer manualmente por causa da limpeza do código, já que o Visual Studio tende a montar o componente utilizando vários atributos.

3º Vamos montar nossa tela da seguinte forma:

![Código1](https://raw.githubusercontent.com/lucasselliach/SISFOTOS/master/Imagens/Codigo1.png).

Veja que que realizei a modificação do titulo da nossa tela, junto também o tamanho dela alterando as propriedades Title, Height e Widht. Também configurei ela para abrir centralizada a tela do usuário e como uma ToolWindow, além de deixar ela sempre do mesmo tamanho.
Costumo a utilizar um GRID para realizar o redimensionamento dinâmico da minha tela com os atributos Grid. ColumnDefinitions e Grid.RowDefinitions, pode ser utilizado outros tipos como StackPanel ou WrapPanel. Mais detalhes aqui [MSDN](https://msdn.microsoft.com/en-us/library/ms754152.aspx)

Dentro deste Grid adicionei uma imagem para colocar uma logotipo e três botões para realizar as ação do usuário. Para cada objeto eu coloquei sua posição no Grid, um nome para futura utilização e um evento. No caso do componente image utilizei uma coisinha chamada **Binding**.

Depois de deixar a parte da visão pronta iremos trabalhar com a lógica da tela. No XAML clique com o botão direito do mouse e vá em VIEW CODE e faça esse código:

  	namespace SisFotos
  	{
        public partial class MainWindow
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
            }
     
            private void ButtonMelhorar_OnClick(object sender, RoutedEventArgs e)
            {
            }
     
            private void ButtonCortar_OnClick(object sender, RoutedEventArgs e)
            {
            }
     
            #endregion Events
     
            #region INotifyPropertyChanged Members
     
            #endregion INotifyPropertyChanged Members
        }
  	}

Veja que adiciono algumas regions para realizar uma formatação do código para melhor visualização, entre elas a **INotifyPropertyChanged**. Dentro dessa region iremos adicionar o seguinte:

  	public event PropertyChangedEventHandler PropertyChanged;
   
  	void NotifyPropertyChanged(string info)
  	{
      	if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(info));
  	}
  
e vamos adicionar a seguinte interface a nossa classe:

	public partial class MainWindow : INotifyPropertyChanged
    

Com a adição do INotifyPropertyChanged podemos agora notificar mudança de estado e realiza visualizações de dados na visão. Podemos agora adicionar uma imagem inicial ao componente image, sendo que iremos carregar uma imagem qualquer antes no projeto.

Podem fazer o seguinte:

![Imagem3](https://raw.githubusercontent.com/lucasselliach/SISFOTOS/master/Imagens/Ensinamento3.png).

e adicionar em seguida:

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

Beleza, agora é só rodar o programa e ver sua imagem aparecendo. Sua imagem só apareceu porque foi definido no construtor o datacontext a ser utilizado, esse é utilizado para fazer a ligação entre a view e o nosso “view-model“.  Veja que é realizado a notificação de mudança com o NotifyPropertyChanged(“******”).

Até ai tudo bem mas e o tratamento de imagem? Ok vamos lá, comece criando a tela  de melhorar imagem:

![Imagem4](https://raw.githubusercontent.com/lucasselliach/SISFOTOS/master/Imagens/Ensinamento4.png).

e modele o view com esse código:

![Código2](https://raw.githubusercontent.com/lucasselliach/SISFOTOS/master/Imagens/Codigo2.png).

Perceba que é uma tela simples onde adicionei a mesma estrutura de Grid da tela principal. Nessa tela vai ser possível selecionar o local das imagens e visualizar o carregamento deles no WrapPanel além de realizar a ação de melhorar com o botão. Nessa tela adicionei ainda o progressbar utilizando Binding para receber notificações de mudanças.

Antes de ir ao nosso codebehind vamos adicionar ao nosso projeto uma DLL chamada [AFORGE](http://www.aforgenet.com), é ela que utilizaremos para tratar a imagem sem ter que perde horas manipulando pixel por pixel. Para adicionar essa DLL vá em TOOLS > NUGET PACKAGE MANAGER > MANAGE NUGET PACKAGE FOR SOLUTION > ONLINE e escreva em Search ONLINE o nome da dll (AFORGE) e instale o core library e o .Imaging.

Agora é só criar uma classe chamada TratamentoDeImagens na pasta Controller que realizará a modificações na imagem adicionando o seguinte código:

	using System.Collections.Generic;
	using System.Drawing;
	using System.Drawing.Imaging;
	using AForge.Imaging.Filters;

	namespace SisFotos.Controller
	{
      public class TratamentoDeImagens
      {
          #region Public Properties
  
          public ImageCodecInfo JpgEnconder { get; private set; }
          public EncoderParameters EncoderParameters { get; private set; }
          public List<Bitmap> BitmapsTratada  { get; private set; }
  
          #endregion Public Properties
          
          #region Internal Properties
          #endregion Internal Properties
          
          #region Constructors/Destructor
  
          public TratamentoDeImagens(List<Bitmap> imagensParaRealizarTratamento)
          {
              BitmapsTratada = new List<Bitmap>();
              RealizarMelhoriasEmImagens(imagensParaRealizarTratamento);
          }
  
          #endregion Constructors/Destructor
  
          #region Public Methods
          #endregion Public Methods
          
          #region Internal Methods
          
          private void RealizarMelhoriasEmImagens(List<Bitmap> imagensParaRealizarTratamento)
          {
              JpgEnconder = GetEncoder(ImageFormat.Jpeg);
              EncoderParameters = new EncoderParameters(1);
              
              var encoder = Encoder.Quality;
              var encoderParameter = new EncoderParameter(encoder, 60L);
              EncoderParameters.Param[0] = encoderParameter;
  
              var contrastCorrection = new ContrastCorrection(30);
  
              foreach (var bitmap in imagensParaRealizarTratamento)
              {
                  BitmapsTratada.Add(contrastCorrection.Apply(bitmap));
              }
          }
  
          private ImageCodecInfo GetEncoder(ImageFormat format)
          {
              ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();
  
              foreach (ImageCodecInfo codec in codecs)
              {
                  if (codec.FormatID == format.Guid)
                  {
                      return codec;
                  }
              }
              return null;
          }
  
          #endregion Internal Methods
          
          #region Events
          #endregion Events
      }
	}

Ok, temos tudo o que é necessário para continuar e realizar a modificação em nossas imagens. Agora finalmente vamos trabalhar na logica da nossa tela final. A estrutura é igual a tela base do sistema, inclusive com os mesmo eventos de notificação para fazer funcionar o binding.

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
   
          }
   
          private void Voltar()
          {
   
          }
   
          private void Melhorar()
          {
   
          }
   
          private void RealizarAlteraçõesDeImagens()
          {
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

Essa estrutura permite notificar a mudança do estado do ProgressBar, para fazer o carregamento das imagens utilizaremos o seguinte código no método ProcurarArquivos():

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

Utilizo o OpenFileDialog() para pesquisar o local das imagens e veja que temos ai algo diferente, eu não utilizo Binding para colocar as imagens carregadas no WrapPanelFotosSelecionadas, e sim carrego diretamente no Children. (Não é uma boa pratica mais funciona :/ ) 

Note-se também que a cada carregamento de imagem com foreach é realizado uma notificação para o progressbar, ou seja ele irá aumentando a cada interação.

Em seguida é só implementar o método que altera as imagens:

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

Nesse método ele irá  pegar as imagens carregas no _listBitmap e realizará as modificações necessárias neles, e seguida pegara as fotos modificadas e salvara em uma pasta chamada modificadas.

O Resultado final será:

![resultado1](https://raw.githubusercontent.com/lucasselliach/SISFOTOS/master/Imagens/resultado1.png).

![resultado2](https://raw.githubusercontent.com/lucasselliach/SISFOTOS/master/Imagens/resultado2.png).

![resultado3](https://raw.githubusercontent.com/lucasselliach/SISFOTOS/master/Imagens/resultado3.png).

Agora tente você continuar o projeto fazendo mais mudanças de imagens como modificações da cores, cortes, aumento de brilho e etc….

License
----

MIT


**Free Software, Hell Yeah!**
