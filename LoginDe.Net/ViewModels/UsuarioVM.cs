namespace LoginDe.Net.ViewModels
{
    public class UsuarioVM
    {
        public int IdUsuario { get; set; }
        public required string Nombre_Usuario { get; set; }
        public required string Password { get; set; }
        public required string ConfirmarPassword { get; set; }
        public required string Nombre { get; set; }
        public required string Apellido_Paterno { get; set; }
        public required string Apellido_Materno { get; set; }
        public required string Correo { get; set; }

    }
}

