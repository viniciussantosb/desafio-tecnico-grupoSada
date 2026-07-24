# Desafio técnico Grupo Sada
## Descrição e requisitos:
Sua tarefa é criar uma aplicação web (API) que funcione como uma "Gestão de Tarefas" simples. O objetivo é permitir que os usuários criem, editem e removam tarefas, e visualizem as tarefas de maneira organizada. O sistema também precisa fornecer uma funcionalidade de buscar tarefas.

## Funcionalidades:
### 1. Cadastro de Tarefa:
- O usuário deve poder criar uma nova tarefa. Para isso, o usuário deve fornecer:
    - Título (obrigatório)
    - Descrição (opcional)
    - Data de vencimento (opcional)
    - Status (com as opções: "Pendente", "Em progresso", "Concluída")

  - O sistema deve retornar um código único para cada tarefa criada.

### 2. Listagem de Tarefas:
- O usuário deve poder visualizar todas as tarefas cadastradas.
  - O sistema deve permitir filtrar as tarefas por status e/ou data de vencimento.


### 3. Edição de Tarefa:
- O usuário deve poder editar uma tarefa existente, incluindo a atualização do título, descrição, status e data de vencimento.

### 4. Exclusão de Tarefa:
- O usuário deve poder excluir uma tarefa.

## Requisitos Técnicos:
- Utilize o framework .NET 8+ (ou versão mais recente) para o desenvolvimento da API.
- Aplique o princípio de SOLID em suas classes e controllers.
- Utilize o Entity Framework Core para persistência de dados, utilize o InMemory para não haver necessidade de ter uma Base de Dados.
- A aplicação deve seguir o padrão RESTful.
- Utilize Swagger para documentar a API.
- Aplique validações adequadas de entrada de dados.
- Inclua testes automatizados utilizando xUnit ou NUnit para as camadas de lógica de negócios.

## Considerações Adicionais:
- Faça uso de DTOs (Data Transfer Objects) para a comunicação entre camadas.
- A API deve retornar códigos de status HTTP apropriados (200, 201, 400, 404, etc.).
- O projeto deve ser estruturado de forma modular e bem organizada, com camadas claras para as responsabilidades (por exemplo, camada de controlador, camada de serviço, camada de repositório, etc.).
- Utilize dependência de injeção (Dependency Injection) para gerenciar as dependências.
- Implemente um tratamento de erros adequado e um sistema de logging básico.

## Critérios de Avaliação:
- Qualidade do Código: Código limpo, bem estruturado e fácil de entender.
- Boas Práticas: Uso adequado de padrões como SOLID, design patterns, injeção de dependência e testes.
- Funcionamento da API: A API deve ser funcional e atender aos requisitos descritos.
- Testes: Qualidade e cobertura dos testes.
- Documentação: A documentação da API (Swagger) deve ser clara e estar completa.
- Estrutura do Projeto: Organização e modularidade do código.

## Entrega:
- Enviar o repositório do projeto no GitHub ou similar.
- Fique a vontade sobre a decisão da arquitetura, lembrando de explicar o conceito e motivo de ter escolhido este modelo.
- Lembrando que o projeto é apenas sobre o backend, não existe a necessidade de criar um frontend para consumi-lo
- O código deve estar bem documentado, com um arquivo README.md explicando como rodar o projeto e como testar as funcionalidades.
