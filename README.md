# OpenOBJ-CSharp
## Descrição
Para aqueles que estudam Computação Gráfica e utilizam a **OpenGL** para renderizar objetos, estarei disponibilizando aqui duas classes de leitura de arquivos em .obj. Assim como, para aqueles que utilizam a **OpenTK**, uma classe para ser usada como objeto no padrão a ser utilizados pelos shaders.
<br><br>
Uma para retornar apenas as linhas relevantes do arquivo e outra para ser utilizada como o próprio objeto, contendo vértices, vetores normais e faces ordenadas.


## Versão 1.0
- ObjectReader.cs
- [x] Leitura do arquivo .obj
- [x] Busca e imprime apenas vértices
- [x] Busca e imprime apenas vetores normais
- [ ] Busca e imprime apenas textura (Em desenvolvimento...)
- [x] Busca e imprime apenas faces

- LoadedObject.cs
- [x] Vértices
- [x] Vetores normais
- [x] Vértices e vetores interpolados
- [x] Faces
- [x] Índices de faces


## Como utilizar
O scripts foram desenvolvidos em DotNet 6, mas como será utilizado apenas as classes que estão contidas no projeto, versões do DotNet 5 ou superior irão ser o suficiente.
### Do que vai precisar
Como o padrão estabelecido foi o mais utilizado pela **OpenGL**, ou seja, renderização de triângulos, é necessário que o objeto (.obj) esteja com todas as faces trianguladas.
- Certifique-se de ter instalado em sua máquina:
- [x] DotNet 5 (ou superior)
- [x] Blender

### Preparando o objeto (.obj)
Em uma busca rápida pela internet você consegue encontrar diversos objetos **gratuitos** modelados em 3D, você pode baixa-los e importar no Blender. Mas nesta explicação vamos utilizar apenas o Blender para isso.
<br><br>
Abra o blender.
<br>
Na tela inicial você irá se deparar com um cubo no centro da tela. É ele quem vamos utilizar para gerar o arquivo (.obj).
<br><br>
Se o mesmo, por algum acaso, não estiver na tela inicial, você pode criar um novo com o seguinte atalho:
- **Shift+A**: Irá abrir uma pequena janela.
- Então você irá navegar por: **Mash** > **Cube**

<div align="center">
<img src="https://user-images.githubusercontent.com/94082665/209472162-a5d0ec25-0163-4ddc-b14d-665f131ba896.png" widith="700px" />
</div>

Pronto! Objeto criado.
<br>
Continuando...

Agora precisamos triangular as faces do objeto, ou seja, por mais que o nosso objeto seja um cubo e tenha faces quadradas, precisamos subdividir as faces em triângulos, pois é assim que a **OpenGL** trabalha.
<br><br>
Siga o seguinte caminho:
- **File** > **Export** > **Wavefront (.obj)**: Irá abrir uma janela de exportação.
- Em **Geometry**, deixe marcado apenas: **Write Normals** e **Triangulate Faces**
- Escolha o nome do arquivo e a pasta destino. Agora **Export OBJ**.

<div align="center">
<img src="https://user-images.githubusercontent.com/94082665/209472181-ea67dd1e-083d-4219-b775-5a4a8a4619c6.png" widith="700px" />
</div>

<div align="center">
<img src="https://user-images.githubusercontent.com/94082665/209472183-3ef02015-5e71-435a-b3d8-8a9e4109c9b6.png" widith="700px" />
</div>

### Utilizando as Classes
#### ObjectReader.cs
Ao instanciar um objeto **ObjectReader**, ele necessita do **caminho absoluto** do arquivo (.obj). Assim que ele é criado, já busca todas as linhas do arquivos que serão necessárias para a renderização do objeto (até o momento: vértices, vetores normais e faces).
~~~C#
string pathFile = @"C:\AbsolutePath";
ObjectReader objReader = new ObjectReader(pathFile);
// objReader.ShowVertices();
// objReader.ShowNormalVector();
// objReader.ShowFaces();
~~~

#### LoadedObject.cs
O **LoadedObject** é o objeto em si que você vai utilizar nos códigos **OpenGL**. Para instancia-lo ele necessita do **ObjectReader**, pois retorna os componente necessários para a criação do objeto.
~~~C#
LoadedObject loadObj = new LoadedObject
(
    objReader.GetAllVertex(),
    objReader.GetAllNormalVector(),
    objReader.GetAllFaces()
);

// loadObj.ShowVertices();
// loadObj.ShowNormalVector();
// loadObj.ShowFaces();
// loadObj.ShowInterpolated();
// loadObj.ShowIndexFaces();
~~~
Ao ser instanciado ele interpola os vértices com os vetores normais. Ou seja, para cada vértice adicionado, será acompanhado do seu vetor normal. Da seguinte maneira:

<div align="center">
<img src="https://user-images.githubusercontent.com/94082665/209472789-788f69ef-effc-4dc2-aa06-5e72259171a7.png" widith="700px" />
</div>

### Melhorando as Classes
O código foi montado de maneira simples, então melhore e faça as modificações de acordo com as suas necessidades.
<br>
Os métodos, tais como **ShowVertices()**, são para verificar se o arquivo carregou como desejado, não necessariamente devem ser usadas.

## Referências
- Learn OpenTK: <https://opentk.net/learn/index.html>
- Learn .NET: <https://dotnet.microsoft.com/en-us/learn> 
- Blender: <https://www.blender.org/support/tutorials/>
