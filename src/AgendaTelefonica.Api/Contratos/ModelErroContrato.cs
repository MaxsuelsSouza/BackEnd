namespace AgendaTelefonica.Api.Contratos
{
    /// <summary>
    /// class para tratamento de erro, vai ser usada na BaseController
    /// </summary>
    public class ModelErroContrato
    {
        public int StatusCode { get; set; }
        public string TituloErro { get; set; }
        public string MensageErro { get; set; }

    }
}