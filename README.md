# Cadastro Cliente
---

## Script MySQL
```
CREATE TABLE cadastro.Pessoa (
	pessoaId int auto_increment NOT NULL,
	tipoPessoa varchar(1) not null,	
	CPF varchar(14),
	DataNascimento date,
	Nome varchar(20),
	Sobrenome varchar(15),	
	CNPJ varchar(18),
	RazaoSocial varchar(20),
	NomeFantasia varchar(15),	
	CEP varchar(9),
	Logradouro varchar(100),
	Numero int,
	Completemento varchar(20),
	Bairro varchar(100),
	Cidade varchar(100),
	UF varchar(2),
	CONSTRAINT Pessoa_PK PRIMARY KEY (pessoaId)
)
ENGINE=InnoDB
DEFAULT CHARSET=utf8
COLLATE=utf8_general_ci;
```

---

## Configuração


#### 1. Configurar informações do banco de dados no arquivo appsettings.json

```
"ConexaoMySql": {
    "MySqlConnectionString": "Server=host;DataBase=database;Uid=root;Pwd=****"
  }
```
---
## Execução via Docker

#### 1. Criação do build do docker
```
docker build -t cadastroclientemvc .
```

#### 2. Execução do docker
```
docker run -d -p 8080:80 --name myapp cadastroclientemvc
```

#### 3. Pronto ja pode acessar a url

```
http://localhost:8080
```