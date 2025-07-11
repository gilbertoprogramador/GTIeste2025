# ModeloProjeto - GTI



Configurações para rodar o projeto, as procedores são apenas para utilizar no projeto webforms para o projeto MVCWEB com api foi utilizado entity



# CRIAR A BASE E AS PROCEDORES





/\*\*\*\*\*\* Object:  Database \[GTIBD]    Script Date: 11/07/2025 12:17:41 \*\*\*\*\*\*/

CREATE DATABASE \[GTIBD]

&nbsp;CONTAINMENT = NONE

&nbsp;ON  PRIMARY 

( NAME = N'GTIBD', FILENAME = N'C:\\Program Files\\Microsoft SQL Server\\MSSQL16.MSSQLSERVER\\MSSQL\\DATA\\GTIBD.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )

&nbsp;LOG ON 

( NAME = N'GTIBD\_log', FILENAME = N'C:\\Program Files\\Microsoft SQL Server\\MSSQL16.MSSQLSERVER\\MSSQL\\DATA\\GTIBD\_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )

&nbsp;WITH CATALOG\_COLLATION = DATABASE\_DEFAULT, LEDGER = OFF

GO



IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))

begin

EXEC \[GTIBD].\[dbo].\[sp\_fulltext\_database] @action = 'enable'

end

GO



ALTER DATABASE \[GTIBD] SET ANSI\_NULL\_DEFAULT OFF 

GO



ALTER DATABASE \[GTIBD] SET ANSI\_NULLS OFF 

GO



ALTER DATABASE \[GTIBD] SET ANSI\_PADDING OFF 

GO



ALTER DATABASE \[GTIBD] SET ANSI\_WARNINGS OFF 

GO



ALTER DATABASE \[GTIBD] SET ARITHABORT OFF 

GO



ALTER DATABASE \[GTIBD] SET AUTO\_CLOSE OFF 

GO



ALTER DATABASE \[GTIBD] SET AUTO\_SHRINK OFF 

GO



ALTER DATABASE \[GTIBD] SET AUTO\_UPDATE\_STATISTICS ON 

GO



ALTER DATABASE \[GTIBD] SET CURSOR\_CLOSE\_ON\_COMMIT OFF 

GO



ALTER DATABASE \[GTIBD] SET CURSOR\_DEFAULT  GLOBAL 

GO



ALTER DATABASE \[GTIBD] SET CONCAT\_NULL\_YIELDS\_NULL OFF 

GO



ALTER DATABASE \[GTIBD] SET NUMERIC\_ROUNDABORT OFF 

GO



ALTER DATABASE \[GTIBD] SET QUOTED\_IDENTIFIER OFF 

GO



ALTER DATABASE \[GTIBD] SET RECURSIVE\_TRIGGERS OFF 

GO



ALTER DATABASE \[GTIBD] SET  DISABLE\_BROKER 

GO



ALTER DATABASE \[GTIBD] SET AUTO\_UPDATE\_STATISTICS\_ASYNC OFF 

GO



ALTER DATABASE \[GTIBD] SET DATE\_CORRELATION\_OPTIMIZATION OFF 

GO



ALTER DATABASE \[GTIBD] SET TRUSTWORTHY OFF 

GO



ALTER DATABASE \[GTIBD] SET ALLOW\_SNAPSHOT\_ISOLATION OFF 

GO



ALTER DATABASE \[GTIBD] SET PARAMETERIZATION SIMPLE 

GO



ALTER DATABASE \[GTIBD] SET READ\_COMMITTED\_SNAPSHOT OFF 

GO



ALTER DATABASE \[GTIBD] SET HONOR\_BROKER\_PRIORITY OFF 

GO



ALTER DATABASE \[GTIBD] SET RECOVERY FULL 

GO



ALTER DATABASE \[GTIBD] SET  MULTI\_USER 

GO



ALTER DATABASE \[GTIBD] SET PAGE\_VERIFY CHECKSUM  

GO



ALTER DATABASE \[GTIBD] SET DB\_CHAINING OFF 

GO



ALTER DATABASE \[GTIBD] SET FILESTREAM( NON\_TRANSACTED\_ACCESS = OFF ) 

GO



ALTER DATABASE \[GTIBD] SET TARGET\_RECOVERY\_TIME = 60 SECONDS 

GO



ALTER DATABASE \[GTIBD] SET DELAYED\_DURABILITY = DISABLED 

GO



ALTER DATABASE \[GTIBD] SET ACCELERATED\_DATABASE\_RECOVERY = OFF  

GO



ALTER DATABASE \[GTIBD] SET QUERY\_STORE = ON

GO



ALTER DATABASE \[GTIBD] SET QUERY\_STORE (OPERATION\_MODE = READ\_WRITE, CLEANUP\_POLICY = (STALE\_QUERY\_THRESHOLD\_DAYS = 30), DATA\_FLUSH\_INTERVAL\_SECONDS = 900, INTERVAL\_LENGTH\_MINUTES = 60, MAX\_STORAGE\_SIZE\_MB = 1000, QUERY\_CAPTURE\_MODE = AUTO, SIZE\_BASED\_CLEANUP\_MODE = AUTO, MAX\_PLANS\_PER\_QUERY = 200, WAIT\_STATS\_CAPTURE\_MODE = ON)

GO



ALTER DATABASE \[GTIBD] SET  READ\_WRITE 

GO







GO

/\*\*\*\*\*\* Object:  Table \[dbo].\[\_\_MigrationHistory]    Script Date: 11/07/2025 12:17:11 \*\*\*\*\*\*/

SET ANSI\_NULLS ON

GO

SET QUOTED\_IDENTIFIER ON

GO

CREATE TABLE \[dbo].\[\_\_MigrationHistory](

&nbsp;	\[MigrationId] \[nvarchar](150) NOT NULL,

&nbsp;	\[ContextKey] \[nvarchar](300) NOT NULL,

&nbsp;	\[Model] \[varbinary](max) NOT NULL,

&nbsp;	\[ProductVersion] \[nvarchar](32) NOT NULL,

&nbsp;CONSTRAINT \[PK\_dbo.\_\_MigrationHistory] PRIMARY KEY CLUSTERED 

(

&nbsp;	\[MigrationId] ASC,

&nbsp;	\[ContextKey] ASC

)WITH (PAD\_INDEX = OFF, STATISTICS\_NORECOMPUTE = OFF, IGNORE\_DUP\_KEY = OFF, ALLOW\_ROW\_LOCKS = ON, ALLOW\_PAGE\_LOCKS = ON, OPTIMIZE\_FOR\_SEQUENTIAL\_KEY = OFF) ON \[PRIMARY]

) ON \[PRIMARY] TEXTIMAGE\_ON \[PRIMARY]

GO

/\*\*\*\*\*\* Object:  Table \[dbo].\[Clientes]    Script Date: 11/07/2025 12:17:11 \*\*\*\*\*\*/

SET ANSI\_NULLS ON

GO

SET QUOTED\_IDENTIFIER ON

GO

CREATE TABLE \[dbo].\[Clientes](

&nbsp;	\[CPF] \[nvarchar](14) NOT NULL,

&nbsp;	\[Nome] \[nvarchar](100) NOT NULL,

&nbsp;	\[RG] \[nvarchar](max) NULL,

&nbsp;	\[DataExpedicao] \[datetime] NULL,

&nbsp;	\[OrgaoExpedicao] \[nvarchar](max) NULL,

&nbsp;	\[UF\_Expedicao] \[nvarchar](max) NULL,

&nbsp;	\[DataNascimento] \[datetime] NULL,

&nbsp;	\[Sexo] \[nvarchar](max) NULL,

&nbsp;	\[EstadoCivil] \[nvarchar](max) NULL,

&nbsp;	\[CEP] \[nvarchar](max) NULL,

&nbsp;	\[Logradouro] \[nvarchar](max) NULL,

&nbsp;	\[Numero] \[nvarchar](max) NULL,

&nbsp;	\[Complemento] \[nvarchar](max) NULL,

&nbsp;	\[Bairro] \[nvarchar](max) NULL,

&nbsp;	\[Cidade] \[nvarchar](max) NULL,

&nbsp;	\[UF] \[nvarchar](max) NULL,

&nbsp;CONSTRAINT \[PK\_dbo.Clientes] PRIMARY KEY CLUSTERED 

(

&nbsp;	\[CPF] ASC

)WITH (PAD\_INDEX = OFF, STATISTICS\_NORECOMPUTE = OFF, IGNORE\_DUP\_KEY = OFF, ALLOW\_ROW\_LOCKS = ON, ALLOW\_PAGE\_LOCKS = ON, OPTIMIZE\_FOR\_SEQUENTIAL\_KEY = OFF) ON \[PRIMARY]

) ON \[PRIMARY] TEXTIMAGE\_ON \[PRIMARY]

GO



/\*CRIAÇÃO DA PROCEDORES RESPONSAVEL PELA EXECUÇÃO NO BANCO DE DADOS\*/

/\*CRIADOR: GILBERTO ARAUJO\*/

/\*DATA:10/07/2024\*/



-- Inserir cliente

CREATE OR ALTER PROCEDURE spIncluirCliente

&nbsp;   @CPF VARCHAR(14),

&nbsp;   @Nome VARCHAR(100),

&nbsp;   @RG VARCHAR(20),

&nbsp;   @DataExpedicao DATETIME,

&nbsp;   @OrgaoExpedicao VARCHAR(50),

&nbsp;   @UF\_Expedicao VARCHAR(2),

&nbsp;   @DataNascimento DATETIME,

&nbsp;   @Sexo VARCHAR(10),

&nbsp;   @EstadoCivil VARCHAR(20),

&nbsp;   @CEP VARCHAR(10),

&nbsp;   @Logradouro VARCHAR(100),

&nbsp;   @Numero VARCHAR(10),

&nbsp;   @Complemento VARCHAR(50),

&nbsp;   @Bairro VARCHAR(50),

&nbsp;   @Cidade VARCHAR(50),

&nbsp;   @UF VARCHAR(2)

AS

BEGIN

&nbsp;   INSERT INTO Clientes VALUES (@CPF,

&nbsp;   @Nome,

&nbsp;   @RG,

&nbsp;   @DataExpedicao ,

&nbsp;   @OrgaoExpedicao ,

&nbsp;   @UF\_Expedicao ,

&nbsp;   @DataNascimento ,

&nbsp;   @Sexo ,

&nbsp;   @EstadoCivil ,

&nbsp;   @CEP ,

&nbsp;   @Logradouro ,

&nbsp;   @Numero,

&nbsp;   @Complemento ,

&nbsp;   @Bairro ,

&nbsp;   @Cidade ,

&nbsp;   @UF )

END

GO



-- Atualizar cliente

CREATE OR ALTER PROCEDURE spAlterarCliente

&nbsp;@CPF VARCHAR(14),

&nbsp;    @Nome VARCHAR(100),

&nbsp;   @RG VARCHAR(20),

&nbsp;   @DataExpedicao DATETIME,

&nbsp;   @OrgaoExpedicao VARCHAR(50),

&nbsp;   @UF\_Expedicao VARCHAR(2),

&nbsp;   @DataNascimento DATETIME,

&nbsp;   @Sexo VARCHAR(10),

&nbsp;   @EstadoCivil VARCHAR(20),

&nbsp;   @CEP VARCHAR(10),

&nbsp;   @Logradouro VARCHAR(100),

&nbsp;   @Numero VARCHAR(10),

&nbsp;   @Complemento VARCHAR(50),

&nbsp;   @Bairro VARCHAR(50),

&nbsp;   @Cidade VARCHAR(50),

&nbsp;   @UF VARCHAR(2)

AS

BEGIN

&nbsp;   UPDATE Clientes SET 

&nbsp;   Nome=@Nome,

&nbsp;   RG=@RG,

&nbsp;   DataExpedicao =@DataExpedicao ,

&nbsp;   OrgaoExpedicao =@OrgaoExpedicao ,

&nbsp;   UF\_Expedicao =@UF\_Expedicao ,

&nbsp;   DataNascimento =@DataNascimento ,

&nbsp;   Sexo =@Sexo ,

&nbsp;   EstadoCivil =@EstadoCivil ,

&nbsp;   CEP =@CEP ,

&nbsp;   Logradouro =@Logradouro ,

&nbsp;   Numero=@Numero,

&nbsp;   Complemento =@Complemento ,

&nbsp;   Bairro =@Bairro ,

&nbsp;   Cidade =@Cidade ,

&nbsp;   UF=@UF

&nbsp;	

&nbsp;	WHERE CPF = @CPF

END

GO



-- Excluir cliente

CREATE OR ALTER PROCEDURE spExcluirCliente

&nbsp;   @CPF VARCHAR(14)

AS

BEGIN

&nbsp;   DELETE FROM Clientes WHERE CPF = @CPF

END

GO



-- Buscar por CPF

CREATE OR ALTER PROCEDURE spBuscarClientePorCPF

&nbsp;   @CPF VARCHAR(14)

AS

BEGIN

&nbsp;   SELECT \* FROM Clientes WHERE CPF = @CPF

END



-- Buscar por Listar Todos

CREATE OR ALTER PROCEDURE spBuscarClienteListarTodos  

AS

BEGIN

&nbsp;   SELECT \* FROM Clientes 

END

GO/\*CRIAÇÃO DA PROCEDORES RESPONSAVEL PELA EXECUÇÃO NO BANCO DE DADOS\*/

/\*CRIADOR: GILBERTO ARAUJO\*/

/\*DATA:10/07/2024\*/



-- Inserir cliente

CREATE OR ALTER PROCEDURE spIncluirCliente

&nbsp;   @CPF VARCHAR(14),

&nbsp;   @Nome VARCHAR(100),

&nbsp;   @RG VARCHAR(20),

&nbsp;   @DataExpedicao DATETIME,

&nbsp;   @OrgaoExpedicao VARCHAR(50),

&nbsp;   @UF\_Expedicao VARCHAR(2),

&nbsp;   @DataNascimento DATETIME,

&nbsp;   @Sexo VARCHAR(10),

&nbsp;   @EstadoCivil VARCHAR(20),

&nbsp;   @CEP VARCHAR(10),

&nbsp;   @Logradouro VARCHAR(100),

&nbsp;   @Numero VARCHAR(10),

&nbsp;   @Complemento VARCHAR(50),

&nbsp;   @Bairro VARCHAR(50),

&nbsp;   @Cidade VARCHAR(50),

&nbsp;   @UF VARCHAR(2)

AS

BEGIN

&nbsp;   INSERT INTO Clientes VALUES (@CPF,

&nbsp;   @Nome,

&nbsp;   @RG,

&nbsp;   @DataExpedicao ,

&nbsp;   @OrgaoExpedicao ,

&nbsp;   @UF\_Expedicao ,

&nbsp;   @DataNascimento ,

&nbsp;   @Sexo ,

&nbsp;   @EstadoCivil ,

&nbsp;   @CEP ,

&nbsp;   @Logradouro ,

&nbsp;   @Numero,

&nbsp;   @Complemento ,

&nbsp;   @Bairro ,

&nbsp;   @Cidade ,

&nbsp;   @UF )

END

GO



-- Atualizar cliente

CREATE OR ALTER PROCEDURE spAlterarCliente

&nbsp;@CPF VARCHAR(14),

&nbsp;    @Nome VARCHAR(100),

&nbsp;   @RG VARCHAR(20),

&nbsp;   @DataExpedicao DATETIME,

&nbsp;   @OrgaoExpedicao VARCHAR(50),

&nbsp;   @UF\_Expedicao VARCHAR(2),

&nbsp;   @DataNascimento DATETIME,

&nbsp;   @Sexo VARCHAR(10),

&nbsp;   @EstadoCivil VARCHAR(20),

&nbsp;   @CEP VARCHAR(10),

&nbsp;   @Logradouro VARCHAR(100),

&nbsp;   @Numero VARCHAR(10),

&nbsp;   @Complemento VARCHAR(50),

&nbsp;   @Bairro VARCHAR(50),

&nbsp;   @Cidade VARCHAR(50),

&nbsp;   @UF VARCHAR(2)

AS

BEGIN

&nbsp;   UPDATE Clientes SET 

&nbsp;   Nome=@Nome,

&nbsp;   RG=@RG,

&nbsp;   DataExpedicao =@DataExpedicao ,

&nbsp;   OrgaoExpedicao =@OrgaoExpedicao ,

&nbsp;   UF\_Expedicao =@UF\_Expedicao ,

&nbsp;   DataNascimento =@DataNascimento ,

&nbsp;   Sexo =@Sexo ,

&nbsp;   EstadoCivil =@EstadoCivil ,

&nbsp;   CEP =@CEP ,

&nbsp;   Logradouro =@Logradouro ,

&nbsp;   Numero=@Numero,

&nbsp;   Complemento =@Complemento ,

&nbsp;   Bairro =@Bairro ,

&nbsp;   Cidade =@Cidade ,

&nbsp;   UF=@UF

&nbsp;	

&nbsp;	WHERE CPF = @CPF

END

GO



-- Excluir cliente

CREATE OR ALTER PROCEDURE spExcluirCliente

&nbsp;   @CPF VARCHAR(14)

AS

BEGIN

&nbsp;   DELETE FROM Clientes WHERE CPF = @CPF

END

GO



-- Buscar por CPF

CREATE OR ALTER PROCEDURE spBuscarClientePorCPF

&nbsp;   @CPF VARCHAR(14)

AS

BEGIN

&nbsp;   SELECT \* FROM Clientes WHERE CPF = @CPF

END



-- Buscar por Listar Todos

CREATE OR ALTER PROCEDURE spBuscarClienteListarTodos  

AS

BEGIN

&nbsp;   SELECT \* FROM Clientes 

END

GO















# COMO EXECUTAR O PROJETO





Rodar primeiro o projeto das API para testar o projeto MVC que consome as API



Dentro do projeto da API Alterar a string de conexão que se encontra no arquivo WEB.CONFIG





\#NOME\_DO\_SEU\_SERVIDOR#

\#SENHA\_DO\_SEU\_SERVIDOR\_BANCO\_DE\_DADOS# 

\#USUARIO\_DO\_BANCO\_DE\_DADOS#



<connectionStrings>

&nbsp;	<add name="connectionGTI" 

&nbsp;       connectionString="Data Source=#NOME\_DO\_SEU\_SERVIDOR#;

&nbsp;       Initial Catalog=GTIBD; password=#SENHA\_DO\_SEU\_SERVIDOR\_BANCO\_DE\_DADOS#; 

&nbsp;       User ID=#USUARIO\_DO\_BANCO\_DE\_DADOS#; 

&nbsp;       Integrated Security=True" 

&nbsp;       providerName="System.Data.SqlClient"/>

</connectionStrings>



# RODANDO O PROJETO DA API PARA TER A PORTA



No projeto MVCWeb possui uma pasta chamada service dentro dela tem uma classe chamada ClienteService na linha 15

alterar para a porta que vai ser criada ao rodar o projeto da WEBAPI, vc vai pegar a porta da URL e alterar na classe.

Alterar #SUA\_PORTA#

exemplo:

http://localhost:51456/api/Cliente



http://localhost:#SUA\_PORTA#/api/Cliente





-------------------------------------------------------------------------------------------------









