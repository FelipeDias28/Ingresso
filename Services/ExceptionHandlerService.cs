namespace Ingresso.Services
{
    public static class ExceptionHandlerService
    {
        public static string ExceptionMessage(string error)
        {
            switch (error)
            {
                case "user-not-found":
                    return "Usuário não encontrado.";

                case "event-not-found":
                    return "Evento não encontrado.";

                case "ticket-sold-out":
                    return "Este evento não possui mais ingresso disponível.";

                case "do-not-have-enough-tickets":
                    return "Este evento não possui a quantidade total de ingresso que foi requisitado.";

                case "event-has-passed-date":
                    return "Este evento já passou da data de encerramento.";

                case "event-already-finalized":
                    return "Este evento já foi finalizado.";

                case "status-event-not-found":
                    return "O status do evento não foi encontrado.";

                case "type-event-not-found":
                    return "O tipo de evento não foi encontrado.";

                case "address-not-found":
                    return "O endereço não foi encontrado.";

                case "ticket-not-found":
                    return "O Ingresso não foi encontrado.";

                case "user-already-exists":
                    return "Usuário já existe";

                default:
                    return null;
            }
        }
    }
}
