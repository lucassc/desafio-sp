# desafio-sp
O Objetivo deste projeto é realizar o cálculo de juros. Esse projeto possui duas aplicações. **InterestRate** fornece o percentual de juros e a aplicação **InterestCalc** realiza o cálculo de acordo com os parâmetros recebido.

# Como rodar o projeto

### Testes unitários e de integração

Para executá-los você deve executar os comandos abaixo na raiz do repositório

**InterestRate**

`docker build --pull --rm -f "InterestRate\Dockerfile" -t interest-rate:latest "InterestRate" --target test`

**InterestCalc**

`docker build --pull --rm -f "InterestCalc\Dockerfile" -t interest-calc:latest "InterestCalc" --target test`


### Contruir as imagens
Caso os testes tenham rodado com sucesso, você deve construir as imagens. Na raiz do repositório execute:

**InterestRate**

`docker build --pull --rm -f "InterestRate\Dockerfile" -t interest-rate:latest "InterestRate"`

**InterestCalc**

`docker build --pull --rm -f "InterestCalc\Dockerfile" -t interest-calc:latest "InterestCalc"`

### Rodar aplicações

Após fazer o bluid das imagens você já pode rodar a aplicação. Na raiz do repositório execute:

`docker-compose up`

De acordo com a definição do arquivo docker-composer.yaml, a aplicação subirá na porta `8002`. Para acessar o Swagger da aplicação basta você acessar esse endereço http://localhost:8002/swagger/index.html.

**Exemplo de requisição:**

[GET] http://localhost:8002/v1/interest-calc?months=1&initialValue=100

months: é a quantidade de meses utilizado para realizar o cálculo.
initialValue: O valor inicial aplicado.

**Response:**

```json
{
  "CalcResult": 101
}
```

# Testes End-To-End

Você pode executar o teste end to end para verificar a interação entre os dois serviços, garantindo assim que aplicação está funcionando conforme esperado.

Na raiz do diretorio contrua a imagem do projeto de teste. Execute:

`docker build --pull --rm -f "InterestEndToEndTest\Dockerfile" -t interest-e2e-test:latest "InterestEndToEndTest"`

Após contruir a imagem que do container que irá rodar os testes, vá para a pasta InterestEndToEndTest\ através do comando:

`cd InterestEndToEndTest\`

E execute o teste:

`docker-compose up --exit-code-from interest-e2e-test`

Caso o teste seja executado corretamente você verá no console as seguintes mensagens:

`interest-e2e-test_1  | Start End-To-End Tests`
`interest-e2e-test_1  | SUCCESS: The end to end test was executed with success`
`interest-e2e-test_1  | Finish End-To-End Tests`

Caso ocorra algum erro, ao invés das mensagens acima, será exibido o erro ocorrido.

** **Você deve garantir que a aplicação não está rodando para executar este teste.**