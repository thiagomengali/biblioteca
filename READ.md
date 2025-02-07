# 📚 Sistema de Gestão de Biblioteca

Este é um sistema de gestão de biblioteca desenvolvido em **.NET**. O sistema permite cadastrar livros e usuários, realizar empréstimos e devoluções, e notificar usuários sobre suas transações.

## 🛠️ Tecnologias Utilizadas

- **Linguagem:** C# (.NET)
- **Paradigmas:** Programação Orientada a Objetos (POO)
- **Padrões de Design:** Observer, Encapsulamento, Herança e Polimorfismo
- **IDE:** VS Code

## 📌 Funcionalidades

✅ Cadastrar livros com ISBN único  
✅ Cadastrar usuários (automaticamente adicionados como observadores de notificações)  
✅ Realizar empréstimos e verificar disponibilidade de livros  
✅ Devolver livros e atualizar o status no sistema  
✅ Exibir histórico de empréstimos para cada usuário  
✅ Enviar notificações de transações para os usuários

## 🚀 Como Rodar o Projeto

### 1️⃣ Pré-requisitos

- **.NET SDK** instalado
- **Visual Studio** ou **VS Code** configurado para C#

### 2️⃣ Clonar o Repositório

```sh
git clone https://github.com/thiagomengali/biblioteca.git
cd sistema-biblioteca

3️⃣ Executar o Projeto

dotnet run
```

📂 Estrutura do Projeto
📦 Biblioteca
┣ 📂 Models # Modelos de dados (Livro, Usuario, Emprestimo)
┣ 📂 Services # Regras de negócio (Cadastro, Empréstimo, Devolução)
┣ 📂 Observers # Implementação do padrão Observer (Serviço de Notificação)
┣ 📂 Utils # Utilitários comuns do programa
┣ 📜 Program.cs # Ponto de entrada do programa
┗ 📜 README.md # Documentação do projeto

📄 Licença
Este projeto está sob a licença MIT. Sinta-se livre para usá-lo e modificá-lo.
