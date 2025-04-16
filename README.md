#  Clube do Livro
![](https://i.imgur.com/cHEh7MP.gif)
Sistema de gerenciamento de empréstimos de revistas entre amigos, desenvolvido como aplicação console em C#.

? Funcionalidades
Cadastro de amigos, caixas, revistas e empréstimos

Registro de devoluções com cálculo automático de multas

Visualização de empréstimos ativos e finalizados

Exibição de "lista negra" com amigos que têm multas pendentes

Validação de dados para evitar cadastros duplicados ou inconsistentes

# Estrutura do Projeto
```
ClubeDoLivro.ConsoleApp/
?
??? ModuloAmigo/         -> Cadastro, edição e visualização de amigos
??? ModuloCaixas/        -> Cadastro e gestão de caixas de armazenamento
??? ModuloRevistas/      -> Cadastro e organização de revistas em caixas
??? ModuloEmprestimos/   -> Controle de empréstimos e devoluções
??? Principal/           -> TelaPrincipal e menu de navegação
?
??? Program.cs           -> Ponto de entrada da aplicação
```

#  Lógica de Negócio
- Cada revista pertence a uma caixa.

- Um amigo pode ter vários empréstimos registrados.

- Cada empréstimo tem uma data de devolução prevista (calculada automaticamente).

- Empréstimos não devolvidos dentro do prazo geram multas de R$2,00 por dia.

- Ao devolver uma revista, o status do empréstimo muda para "Fechado".

- Revistas podem ser reemprestadas após a devolução.

##  Validações
- Nome e telefone de amigos devem ser únicos.

- Campos obrigatórios não podem estar em branco.

- Só é possível emprestar revistas que estejam disponíveis.

## Tecnologias
- Linguagem: C#

- Tipo: Aplicação Console

- Framework: .NET 6+

- Paradigma: Programação Orientada a Objetos

# Como testar?

## Clone o Repositório
````
git clone https://github.com/xleonardoxmed/ClubeDoLivro.git
````
## Navegue até a pasta raiz da solução
````
cd ClubeDoLivro
````
## Restaure as dependências
````
dotnet restore
````
## Navegue até a pasta do projeto
````
cd ClubeDoLivro.ConsoleApp
````
## Execute o projeto
````
dotnet run
````

## ?? Observações Finais
O sistema usa listas internas para simular um "banco de dados".

Ainda não possui persistência de dados — ao encerrar o programa, os dados são perdidos.

Ideal para fins didáticos e projetos de introdução à programação.

