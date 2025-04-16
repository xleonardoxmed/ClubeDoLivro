#  Clube do Livro
![](https://i.imgur.com/cHEh7MP.gif)
Sistema de gerenciamento de empr�stimos de revistas entre amigos, desenvolvido como aplica��o console em C#.

? Funcionalidades
Cadastro de amigos, caixas, revistas e empr�stimos

Registro de devolu��es com c�lculo autom�tico de multas

Visualiza��o de empr�stimos ativos e finalizados

Exibi��o de "lista negra" com amigos que t�m multas pendentes

Valida��o de dados para evitar cadastros duplicados ou inconsistentes

# Estrutura do Projeto
```
ClubeDoLivro.ConsoleApp/
?
??? ModuloAmigo/         -> Cadastro, edi��o e visualiza��o de amigos
??? ModuloCaixas/        -> Cadastro e gest�o de caixas de armazenamento
??? ModuloRevistas/      -> Cadastro e organiza��o de revistas em caixas
??? ModuloEmprestimos/   -> Controle de empr�stimos e devolu��es
??? Principal/           -> TelaPrincipal e menu de navega��o
?
??? Program.cs           -> Ponto de entrada da aplica��o
```

#  L�gica de Neg�cio
- Cada revista pertence a uma caixa.

- Um amigo pode ter v�rios empr�stimos registrados.

- Cada empr�stimo tem uma data de devolu��o prevista (calculada automaticamente).

- Empr�stimos n�o devolvidos dentro do prazo geram multas de R$2,00 por dia.

- Ao devolver uma revista, o status do empr�stimo muda para "Fechado".

- Revistas podem ser reemprestadas ap�s a devolu��o.

##  Valida��es
- Nome e telefone de amigos devem ser �nicos.

- Campos obrigat�rios n�o podem estar em branco.

- S� � poss�vel emprestar revistas que estejam dispon�veis.

## Tecnologias
- Linguagem: C#

- Tipo: Aplica��o Console

- Framework: .NET 6+

- Paradigma: Programa��o Orientada a Objetos

# Como testar?

## Clone o Reposit�rio
````
git clone https://github.com/xleonardoxmed/ClubeDoLivro.git
````
## Navegue at� a pasta raiz da solu��o
````
cd ClubeDoLivro
````
## Restaure as depend�ncias
````
dotnet restore
````
## Navegue at� a pasta do projeto
````
cd ClubeDoLivro.ConsoleApp
````
## Execute o projeto
````
dotnet run
````

## ?? Observa��es Finais
O sistema usa listas internas para simular um "banco de dados".

Ainda n�o possui persist�ncia de dados � ao encerrar o programa, os dados s�o perdidos.

Ideal para fins did�ticos e projetos de introdu��o � programa��o.

