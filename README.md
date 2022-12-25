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
<br><br>
Na tela inicial você irá se deparar com um cubo no centro da tela. É ele quem vamos utilizar para gerar o arquivo (.obj).
<br><br>
Se o mesmo, por algum acaso, não estiver na tela inicial, você pode criar um novo com o seguinte atalho:
<br>
- **Shift+A** - Irá abrir uma pequena janela.
<br>
- Então você irá navegar por: **Mash** > **Cube**
<br><br>
Pronto! Objeto criado.
<br><br>
Continuando...
<br><br>
