use dotconect	
GO

create or alter procedure proPessoas
	@nome varchar(255),
	@email varchar(255)
as 
begin
	insert into pessoa (nome, email)
	values (@nome, @email);
end 

GO
create or alter procedure proGetPessoas
as
begin
	select * from pessoa 
end


go 
create or alter procedure proGetOnePessoas
	@ID int
as
begin
	select * from pessoa 
	where id = @ID;
end




CREATE OR ALTER PROCEDURE progetUpdate
	@ID INT,
	@Email VARCHAR(255),
	@Nome VARCHAR(255)
AS
BEGIN
	UPDATE pessoa
	SET
		nome = @Nome,
		email = @Email
	WHERE
		id = @ID;
END







