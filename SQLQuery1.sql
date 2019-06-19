create procedure [dbo].[AgregarMascota]
(
	@Nombre nvarchar(50),
	@Edad nvarchar(10),
	@Descripcion nvarchar (100),
	@Correo nvarchar (30),
	@Adoptado bit
)
as
begin
	Insert into mascota values(@Nombre,@Edad,@Descripcion,@Correo,@Adoptado)
End