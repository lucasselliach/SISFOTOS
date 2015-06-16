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

<p>Here is an example of AppleScript:</p>



Veja que que realizei a modificação do titulo da nossa tela, junto também o tamanho dela alterando as propriedades Title, Height e Widht. Também configurei ela para abrir centralizada a tela do usuário e como uma ToolWindow, além de deixar ela sempre do mesmo tamanho.
Costumo a utilizar um GRID para realizar o redimensionamento dinâmico da minha tela com os atributos Grid. ColumnDefinitions e Grid.RowDefinitions, pode ser utilizado outros tipos como StackPanel ou WrapPanel. Mais detalhes aqui [MSDN](https://msdn.microsoft.com/en-us/library/ms754152.aspx)

Dentro deste Grid adicionei uma imagem para colocar uma logotipo e três botões para realizar as ação do usuário. Para cada objeto eu coloquei sua posição no Grid, um nome para futura utilização e um evento. No caso do componente image utilizei uma coisinha chamada **Binding**.

Depois de deixar a parte da visão pronta iremos trabalhar com a lógica da tela. No XAML clique com o botão direito do mouse e vá em VIEW CODE e faça esse código:






License
----

MIT


**Free Software, Hell Yeah!**
