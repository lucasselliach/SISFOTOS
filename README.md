### SISFOTOS – Sistema para tratar imagem em WPF

Bom dia galera, hoje vou mostrar para vocês como fazer um programa simples para melhorar levemente uma imagens alterando seu contraste sendo que o objetivo desse tutorial não é exatamente a alteração da imagem mas ensinar a utilizar o WPF (Windows Presentation Foundation ).

Segundo a galera da Microsoft o  Windows Presentation Foundation (WPF) é a atual geração de user Interface, utilizado na construção de aplicações e sistemas sofisticados e interativos de alta qualidade. Ele oferece suporte a um amplo conjunto de recursos de desenvolvimento de aplicativos, incluindo modelo de aplicações, recursos, controles, elementos gráficos, layout, vinculação de dados, documentos e segurança.

Basicamente o WPF herda conceitos do CLR (Common Language Runtime) e no caso da parte de visão é dividido em dois seguimentos, o XAML e o CODEBEHIND. O XAML (Extensible Markup Language) é uma linguagem de marcação  utilizado na criação da UI (interface gráfica, exatamente o que o usuário final irá visualizar e interagir), sendo o code-behind a parte logica da tela.  Essa operação segue o conceito de um pattern chamado MVVM (Model View View Model), esse pattern estabelece uma separação de responsabilidade, no caso do WPF, ele visa separar o que for visão da logica.

![]({{site.baseurl}}/https://i-msdn.sec.s-msft.com/dynimg/IC448690.png)

Nesse tutorial não irei aplicar 100% do pattern pois pretendo trazer de forma mais tranquila e rápida a utilização do WPF realizando o viewmodel direto no codebehind. a aplicação correta deixarei para o proximo tutorial seguindo o padrão, mas é possível por enquanto ver a aplicação correta do mvvm em [http://imasters.com.br/artigo/18900/desenvolvimento/entendendo-o-pattern-model-view-viewmodel-mvvm](http://imasters.com.br/artigo/18900/desenvolvimento/entendendo-o-pattern-model-view-viewmodel-mvvm)

## SISFOTOS WPF

1º Abra o Visual Studio (no meu caso o 2013) e vá em NEW PROJECT > VISUAL C# > WPF APPLICATION:





License
----

MIT


**Free Software, Hell Yeah!**
