using Locadora.TemTudo.Api.Models;

namespace Locadora.TemTudo.Api.Data.Repositories
{
    public class LogErroRepository
    {
        private LocadoraContext _ctx;

        public LogErroRepository(LocadoraContext ctx)
        {
            _ctx = ctx;
        }

        public void Adicionar(Exception ex)
        {
            var logBase = new LogErro();
            
            logBase.InnerException = ex.InnerException?.ToString();
            logBase.StackTrace = ex.StackTrace;
            logBase.Mensagem = ex.Message;
            logBase.DataHoraRegistro = DateTime.Now;

            _ctx.LogsErros.Add(logBase);
            _ctx.SaveChanges();
        }
    }
}
