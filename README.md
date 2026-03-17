# 🎮 Jogo da Forca - Console em C#

Este projeto é uma implementação do clássico **Jogo da Forca** desenvolvido em **C#** para execução em **aplicação de Console**.

O objetivo do jogo é descobrir a palavra secreta digitando letras. A cada erro, uma parte do boneco da forca é desenhada. O jogador perde quando o desenho é completado.

---

# 📌 Funcionalidades

- Escolha **aleatória de palavras**
- Exibição do **desenho da forca conforme os erros**
- Controle de **letras acertadas**
- Contagem de **erros do jogador**
- Mensagem de **vitória ou derrota**
- Opção para **jogar novamente**

---

# 🧠 Como o jogo funciona

1. O programa seleciona uma palavra aleatória de uma lista de frutas.
2. O jogador deve digitar **uma letra por vez**.
3. Se a letra existir na palavra, ela será revelada.
4. Se a letra não existir, um erro será contabilizado.
5. O jogo termina quando:
   - O jogador **descobre a palavra**, ou
   - O jogador **atinge o limite de erros**.

---

# 🕹️ Exemplo de execução

```
---------------------------------
Jogo da Forca
---------------------------------

 ___________
 |/        |
 |
 |
 |
 |
 |
_|____

Letras acertadas: _____
Erros cometidos: 0

Digite uma letra:
```

Se o jogador errar várias vezes, o desenho da forca evolui até completar o boneco.

---

# 📚 Palavras utilizadas

O jogo utiliza uma lista de frutas como palavras secretas:

- ABACATE
- ABACAXI
- ACEROLA
- AÇAÍ
- ARAÇA
- BACABA
- BACURI
- BANANA
- CAJÁ
- CAJU
- CARAMBOLA
- CUPUAÇU
- GRAVIOLA
- GOIABA
- JABUTICABA
- JENIPAPO
- MAÇÃ
- MANGABA
- MANGA
- MARACUJÁ
- MURICI
- PEQUI
- PITANGA
- PITAYA
- SAPOTI
- TANGERINA
- UMBU
- UVA
- UVAIA

---

# 🧩 Estrutura do Código

O programa foi dividido em métodos para facilitar a organização:

| Método | Função |
|------|------|
| `Main` | Controla o fluxo principal do jogo |
| `ExibirCabecalho` | Mostra o título do jogo |
| `EscolherPalavraAleatoria` | Seleciona uma palavra da lista |
| `PreencherLetrasAcertadas` | Inicializa os espaços da palavra |
| `ExecutarTentativas` | Controla a lógica das tentativas |
| `DesenharForca` | Desenha a forca conforme os erros |
| `JogadorDesejaContinuar` | Pergunta se o jogador quer jogar novamente |

---

# 🛠️ Tecnologias utilizadas

- **C#**
- **.NET**
- **Console Application**

---

# ▶️ Como executar o projeto

1. Clone o repositório:

```
git clone https://github.com/ThiaggoSylva/jogoDaForca.git
```

2. Abra o projeto em uma IDE como:

- Visual Studio
- Visual Studio Code

3. Compile e execute o projeto.

---

# 📷 Demonstração do jogo

O jogo funciona diretamente no **console**, exibindo o desenho da forca e o progresso do jogador a cada tentativa.

---

# 🎯 Objetivo do projeto

Este projeto foi desenvolvido com o objetivo de **praticar conceitos fundamentais de programação em C#**, como:

- Estruturas de repetição
- Estruturas condicionais
- Arrays
- Métodos
- Manipulação de strings
- Organização de código

---

# 📄 Licença

Este projeto é livre para uso educacional e aprendizado.

---

# 👨‍💻 Autor

Projeto desenvolvido por **Thiago Silva**.
