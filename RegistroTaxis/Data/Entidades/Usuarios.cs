namespace RegistroTaxis.Data.Entidades
{
	public class Usuarios
	{
		public Guid UsuarioId { get; set; }
		public string NombreUsuario { get; set; }
		public string Contraseña { get; set; }

		public bool Eliminado { get; set; }
		public Guid CreatedBy { get; set; }
		public DateTime CreatedDate { get; set; }
		public DateTime ModifiedDate { get; set; }
		public Guid ModifiedBy { get; set; }



	}
}
