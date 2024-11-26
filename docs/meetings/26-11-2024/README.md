## Briefing Doc - Arquitetura Limpa com DDD em .NET

---

**Data:** 26/11/2024

**Participantes:** Daniel, Arthur, Fernando e Thiago

**Tema Principal:** Discussão sobre a estrutura de um projeto .NET utilizando os conceitos de Arquitetura Limpa e Domain-Driven Design (DDD).

**Pontos-chave:**

#### **Camada de Controller:**

- Responsável por receber requisições e delegar para camadas com maior responsabilidade.
- Deve conter o mínimo de lógica possível.
- Exemplo no código: LeadController

#### **DTO (Data Transfer Object) / Request:**

- Classe "burra" sem regras de negócio, utilizada para transportar dados.
- Isolamento do domínio, permitindo que a API receba dados de forma simplificada.
- Possibilidade de aplicar validações específicas para garantir a consistência dos dados.
- Exemplo no código: LeadRequest

#### **Validação:**

- Utilização da biblioteca FluentValidation para implementar validações.
- Permite definir regras de validação para os dados recebidos na requisição, como obrigatoriedade, tamanho e formato.
- Exemplo no código: LeadRequestValidator, AddValidation (método no Program.cs)

#### **Domínio:**

- Modelagem de entidades representando o mundo real.
- Exemplo no código: Lead (entidade com Person)

#### **Repositório:**

- Interface que define os métodos de acesso a dados.
- Permite a troca da implementação de acesso a dados (ex: MySQL para Oracle) sem afetar outras camadas.
- Utilização de injeção de dependência para desacoplar a implementação concreta.
- Exemplo no código: ILeadRepository, LeadRepository (classe abstrata)

#### **Implementação do Repositório:**

- A implementação concreta do acesso ao banco de dados ainda não foi feita (not implemented exception).

**Próximos Passos:**

- Implementar a conexão com o banco de dados (MySQL) na classe LeadRepository.
- Continuar a discussão sobre as demais camadas da arquitetura.

**Dúvidas:**

- Como implementar a migração de banco de dados considerando a camada de repositório.

**Observações:**

- A camada de API foi referida como "UI" durante a discussão.
- O projeto utiliza o conceito de injeção de dependência, um dos princípios SOLID.

**Trechos importantes:**

"Porque existem cenários que eu não quero expor todas as informações que eu tenho configurada na minha aplicação para um cara que vai usar ela."

"Toda vez que você quiser validar dados, se ele é vazio, tamanho de dados, eh o tipo de dado que tá vindo no campo, se ele é um inteiro ou uma string, eh, Se é um e-mail válido, se é um telefone válido, você deixa aí. É para isso que serve o validator."

"Se eu mudar minha camada de banco de dados, eu simplesmente crio uma outra classe dessa e implemento a mesma interface. E é só um lugar que eu tenho para mexer. Por isso que é muito importante trabalhar com interface."

**Recomendações:**

- Estudo da biblioteca FluentValidation.
- Aprofundamento nos conceitos de Arquitetura Limpa e DDD.

**Recursos:**

- Documentação da biblioteca FluentValidation: (link [fornecido no áudio](https://docs.fluentvalidation.net/en/latest/index.html)).

- https://docs.fluentvalidation.net/en/latest/index.html

**Observação:** Este briefing doc foi elaborado com base em trechos da conversa transcrita. A gravação completa pode conter informações adicionais relevantes.
